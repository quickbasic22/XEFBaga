using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XEFBaga.Models;
using XEFBaga.ViewModels;
using XEFBaga.Views;

namespace XEFBaga.Views
{
    public partial class LodgingsPage : ContentPage
    {
        LodgingsViewModel _viewModel;

        public LodgingsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new LodgingsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }

        
    }
}