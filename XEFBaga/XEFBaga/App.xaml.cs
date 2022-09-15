using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XEFBaga.Data;
using XEFBaga.Services;
using XEFBaga.Views;

namespace XEFBaga
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            BagaContext context = new BagaContext();
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
