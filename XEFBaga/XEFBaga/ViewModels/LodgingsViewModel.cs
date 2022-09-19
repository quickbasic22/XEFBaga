using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XEFBaga.Models;
using XEFBaga.Views;

namespace XEFBaga.ViewModels
{
    public class LodgingsViewModel : BaseViewModel
    {
        private Lodging _selectedItem;
        public ObservableCollection<Lodging> Items { get; }
        public Command LoadItemsCommand { get; }
        public Command AddItemCommand { get; }
        public Command<Lodging> ItemTapped { get; }
        public Command<Lodging> DeleteCommand { get; set; }

        public LodgingsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Lodging>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            ItemTapped = new Command<Lodging>(OnItemSelected);

            AddItemCommand = new Command(OnAddItem);
            DeleteCommand = new Command<Lodging>(OnDeleteItem);
        }

        private async void OnDeleteItem(object obj)
        {
            var lodging = obj as Lodging;
            Items.Remove(lodging);
            await DataStore.DeleteItemAsync(lodging.lodgingId);
        }

        async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;

            try
            {
                Items.Clear();
                var items = await LodgingDataStore.GetLodgingsAsync();
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = null;
        }

        public Lodging SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnItemSelected(value);
            }
        }

        private async void OnAddItem(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewLodgingPage));
        }

        async void OnItemSelected(Lodging item)
        {
            if (item == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(LodgingDetailPage)}?{nameof(LodgingDetailViewModel.ItemId)}={item.lodgingId}");
        }
    }
}