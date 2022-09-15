using System.ComponentModel;
using Xamarin.Forms;
using XEFBaga.ViewModels;

namespace XEFBaga.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}