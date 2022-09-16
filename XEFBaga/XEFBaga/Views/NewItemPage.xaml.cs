using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XEFBaga.Models;
using XEFBaga.ViewModels;

namespace XEFBaga.Views
{
    public partial class NewItemPage : ContentPage
    {
        public Destination Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}