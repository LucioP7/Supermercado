using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Microsoft.Maui.ApplicationModel.Communication;
using Microsoft.Maui.Storage;
using SupermercadoServices.Models;
using SupermercadoServices.Services;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SupermercadoApp.ViewModels
{
    public partial class IniciarSesionViewModel : ObservableObject
    {
        public readonly FirebaseAuthClient _clientAuth;
        private FileUserRepository _userRepository;
        private UserInfo _userInfo;
        private FirebaseCredential _firebaseCredential;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string mail;

        [ObservableProperty]
        [NotifyCanExecuteChangedFor(nameof(IniciarSesionCommand))]
        private string password;

        [ObservableProperty]
        private bool recordarContraseña;

        public IRelayCommand IniciarSesionCommand { get; }
        public IRelayCommand RegistrarseCommand { get; }

        public IniciarSesionViewModel()
        {
            _clientAuth = new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyAK6_Z5_mHTtKyG4eF8hGgcx0F5Y7Wl2Ps",
                AuthDomain = "supermercadop7.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                }
            });
            _userRepository = new FileUserRepository("Supermercado");
            CheckStoredUser();
            IniciarSesionCommand = new RelayCommand(IniciarSesion, PermitirIniciarSesion);
            RegistrarseCommand = new RelayCommand(Registrarse);
        }

        private async void Registrarse()
        {
            await Shell.Current.GoToAsync("Registrarse");
        }

        private async void CheckStoredUser()
        {
            if (_userRepository.UserExists())
            {
                (_userInfo, _firebaseCredential) = _userRepository.ReadUser();

                var shellKiosco = (AppShell)App.Current.MainPage;
                shellKiosco.EnableAppAfterLogin();
            }
        }

        public bool PermitirIniciarSesion()
        {
            return !string.IsNullOrEmpty(Mail) && !string.IsNullOrEmpty(Password);
        }

        private async void IniciarSesion()
        {
            try
            {
                if (_clientAuth == null)
                {
                    if (Application.Current?.MainPage != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Error", "El cliente de autenticación no está inicializado.", "Ok");
                    }
                    return;
                }

                var userCredential = await _clientAuth.SignInWithEmailAndPasswordAsync(Mail, Password);
                string firebaseUid = userCredential.User.Uid;

                if (userCredential.User.Info.IsEmailVerified == false)
                {
                    if (Application.Current?.MainPage != null)
                    {
                        await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Debe verificar su correo electrónico", "Ok");
                    }
                    return;
                }

                if (RecordarContraseña)
                {
                    _userRepository.SaveUser(userCredential.User);
                }
                else
                {
                    _userRepository.DeleteUser();
                }

                //var clienteService = new ClienteService();
                //var clienteExistente = await clienteService.ObtenerClientePorUidAsync(firebaseUid);

                //if (clienteExistente == null)
                //{
                //    // Si no existe
                //    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Esta cuenta no existe", "Ok");
                //}

                if (App.Current?.MainPage is AppShell shellKiosco)
                {
                    shellKiosco.EnableAppAfterLogin();
                }
            }
            catch (FirebaseAuthException error)
            {
                if (Application.Current?.MainPage != null)
                {
                    await Application.Current.MainPage.DisplayAlert("Inicio de sesión", "Ocurrió un problema: " + error.Reason, "Ok");
                }
            }
        }
    }
}