using System;
using System.Collections.Generic;
using Xamarin.Forms;
using XEFBaga.ViewModels;
using XEFBaga.Views;

namespace XEFBaga
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(LodgingDetailPage), typeof(LodgingDetailPage));
            Routing.RegisterRoute(nameof(NewLodgingPage), typeof(NewLodgingPage));
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
