using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XEFBaga.Models;
using XEFBaga.ViewModels;

namespace XEFBaga.Views
{
    public partial class NewLodgingPage : ContentPage
    {
        public Lodging Lodging { get; set; }

        public NewLodgingPage()
        {
            InitializeComponent();
            BindingContext = new NewLodgingViewModel();
        }
    }
}