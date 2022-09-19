using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using XEFBaga.Models;

namespace XEFBaga.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private int itemId;
        private string name;
        private string country;
        private string description;
        public Command DeleteCommand { get; set; }

        public ItemDetailViewModel()
        {
            DeleteCommand = new Command(OnDelete);
        }

        private async void OnDelete(object obj)
        {
           await DataStore.DeleteItemAsync(Id);
           await Shell.Current.GoToAsync("..");
        }

        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Country
        {
            get => country;
            set => SetProperty(ref country, value);
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public int ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(int itemId)
        {
            try
            {
                var item = await DataStore.GetItemAsync(itemId);
                Id = item.DestinationId;
                Name = item.Name;
                Country = item.Country;
                Description = item.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
