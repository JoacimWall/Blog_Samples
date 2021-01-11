using System;
using System.Globalization;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MLDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            //sample of hard set language that not need to match language on device
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("fr-FR");
            Thread.CurrentThread.CurrentCulture = Thread.CurrentThread.CurrentUICulture;
            MLDemo.Resources.AppResources.Culture = Thread.CurrentThread.CurrentUICulture;
            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
