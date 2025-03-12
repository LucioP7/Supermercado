using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using SupermercadoServices.Models;
using SupermercadoServices.Services;
using System.Net;
using System.Net.Http.Headers;
namespace SupermercadoApp.ViewModels
{
    public partial class RegistrarseViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _clientAuth;
        private const string FirebaseApiKey = "AIzaSyAK6_Z5_mHTtKyG4eF8hGgcx0F5Y7Wl2Ps";
        private const string RequestUri = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=" + FirebaseApiKey;

        public IRelayCommand RegistrarseCommand { get; }

        [ObservableProperty] private string nombre;
        [ObservableProperty] private string apellido;
        [ObservableProperty] private string dni;
        [ObservableProperty] private string mail;
        [ObservableProperty] private string telefonos;
        [ObservableProperty] private string password;
        [ObservableProperty] private string verifyPassword;

        public RegistrarseViewModel()
        {
            RegistrarseCommand = new RelayCommand(Registrarse);
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyAK6_Z5_mHTtKyG4eF8hGgcx0F5Y7Wl2Ps",
                AuthDomain = "supermercadop7.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
        }

        private async void Registrarse()
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellido) ||
                string.IsNullOrWhiteSpace(Dni) || string.IsNullOrWhiteSpace(Mail) ||
                string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(VerifyPassword)
                || string.IsNullOrWhiteSpace(telefonos))
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Todos los campos son obligatorios", "OK");
                return;
            }

            if (Password != VerifyPassword)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Las contraseñas no coinciden", "OK");
                return;
            }

            try
            {
                var userCredential = await _clientAuth.CreateUserWithEmailAndPasswordAsync(Mail, Password, Nombre);
                string firebaseUid = userCredential.User.Uid;

                await SendVerificationEmailAsync(await userCredential.User.GetIdTokenAsync());

                var clienteService = new ClienteService();
                var nuevoCliente = new Cliente
                {
                    FirebaseUid = firebaseUid,
                    Nombre = Nombre,
                    Apellido = Apellido,
                    DNI = Dni,
                    Telefonos = Telefonos,
                    PuntosFidelizacion = 0,
                    FechaNacimiento = DateTime.Now,
                    LocalidadId = null,
                    Eliminado = false
                };

                await clienteService.CrearClienteAsync(nuevoCliente);

                await Application.Current.MainPage.DisplayAlert("Registro", "Cuenta creada correctamente", "OK");
                await Application.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", $"No se pudo registrar: {ex.Message}", "OK");
            }
        }

        public static async Task SendVerificationEmailAsync(string idToken)
        {
            using var client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new StringContent("{\"requestType\":\"VERIFY_EMAIL\",\"idToken\":\"" + idToken + "\"}");
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await client.PostAsync(RequestUri, content);
            response.EnsureSuccessStatusCode();
        }
    }
}