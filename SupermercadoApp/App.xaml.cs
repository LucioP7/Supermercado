using CommunityToolkit.Mvvm.Messaging;
using SupermercadoApp.Class;
using SupermercadoApp.Views;

namespace SupermercadoApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new AppShell();
            MainPage = new AppShell();
           
        }

        
    }
}
