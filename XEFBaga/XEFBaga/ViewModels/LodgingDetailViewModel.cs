using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using XEFBaga.Models;

namespace XEFBaga.ViewModels
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
    public class LodgingDetailViewModel : BaseViewModel
    {
        private int itemId;
        private int id;
        private string name;
        private string owner;
        private bool isresort;
        public Command DeleteCommand { get; set; }

        public LodgingDetailViewModel()
        {
            DeleteCommand = new Command(OnDelete);
        }

        private async void OnDelete(object obj)
        {
            await LodgingDataStore.DeleteLodgingAsync(Id);
           await Shell.Current.GoToAsync("..");
        }

        public int Id { get; set; }

        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Owner
        {
            get => owner;
            set => SetProperty(ref owner, value);
        }
        public bool IsResort
        {
            get => isresort;
            set => SetProperty(ref isresort, value);
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
                var item = await LodgingDataStore.GetLodgingAsync(itemId);
                Id = item.lodgingId;
                Name = item.Name;
                Owner = item.Owner;
                IsResort = item.IsResort;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
