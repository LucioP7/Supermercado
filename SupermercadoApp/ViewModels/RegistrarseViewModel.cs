using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using SupermercadoServices.Services;
using SupermercadoServices.Models;
using System.Collections.ObjectModel;
using System.Net.Http.Headers;
using Firebase.Auth.Providers;

namespace SupermercadoApp.ViewModels
{
    public partial class RegistrarseViewModel : ObservableObject
    {
        private readonly FirebaseAuthClient _clientAuth;
        private readonly ClienteService _clienteService;
        private readonly LocalidadService _localidadService;

        private const string FirebaseApiKey = "TU_FIREBASE_API_KEY";
        private const string RequestUri = "https://identitytoolkit.googleapis.com/v1/accounts:sendOobCode?key=" + FirebaseApiKey;

        public IRelayCommand RegistrarseCommand { get; }

        [ObservableProperty] private string nombre;
        [ObservableProperty] private string apellido;
        [ObservableProperty] private string dni;
        [ObservableProperty] private string telefonos;
        [ObservableProperty] private string mail;
        [ObservableProperty] private string password;
        [ObservableProperty] private string verifyPassword;

        [ObservableProperty] private ObservableCollection<Localidad> localidades;
        [ObservableProperty] private Localidad localidadSeleccionada;

        public RegistrarseViewModel()
        {
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = FirebaseApiKey,
                AuthDomain = "supermercadop7.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });

            _clienteService = new ClienteService();
            _localidadService = new LocalidadService();

            Localidades = new ObservableCollection<Localidad>();
            CargarLocalidades();

            RegistrarseCommand = new RelayCommand(Registrarse);
        }

        private async void CargarLocalidades()
        {
            var lista = await _localidadService.ObtenerTodasLocalidadesAsync();
            if (lista != null)
            {
                foreach (var localidad in lista)
                {
                    Localidades.Add(localidad);
                }
            }
        }

        private async void Registrarse()
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Apellido) ||
                string.IsNullOrWhiteSpace(Dni) || string.IsNullOrWhiteSpace(Mail) ||
                string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(VerifyPassword) ||
                LocalidadSeleccionada == null)
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

                var nuevoCliente = new Cliente
                {
                    FirebaseUid = firebaseUid,
                    Nombre = Nombre,
                    Apellido = Apellido,
                    DNI = Dni,
                    Telefonos = Telefonos,
                    PuntosFidelizacion = 0,
                    FechaNacimiento = DateTime.Now,
                    LocalidadId = LocalidadSeleccionada.Id,  // Guarda la Localidad seleccionada
                    Eliminado = false
                };

                await _clienteService.CrearClienteAsync(nuevoCliente);

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
