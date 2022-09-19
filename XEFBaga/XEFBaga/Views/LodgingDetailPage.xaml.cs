using System.ComponentModel;
using Xamarin.Forms;
using XEFBaga.ViewModels;

namespace XEFBaga.Views
{
    public partial class LodgingDetailPage : ContentPage
    {
        public LodgingDetailPage()
        {
            InitializeComponent();
            BindingContext = new LodgingDetailViewModel();
        }
    }
}