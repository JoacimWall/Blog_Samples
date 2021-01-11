using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GrpcDemo
{
    public partial class App : Application
    {
        public static Services.GreeterService GreeterService;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            GreeterService = new Services.GreeterService();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
            GreeterService = new Services.GreeterService();
        }
    }
}
