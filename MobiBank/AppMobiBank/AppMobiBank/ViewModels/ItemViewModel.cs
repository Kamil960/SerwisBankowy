using AppMobiBank.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobiBank.ViewModels
{
    public abstract class ItemViewModel<T> : BaseViewModel
    {
        #region Properties
        public IDataStore<T> DataStore => DependencyService.Get<IDataStore<T>>();
        private T _selectedItem;
        public T SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
                OnSelectedItem(value);
            }
        }
        public ObservableCollection<T> Items { get; }
        public Command AddItemCommand { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command UpdateItemCommand { get; set; }
        #endregion
        #region Constructor
        public ItemViewModel()
        {
            Items = new ObservableCollection<T>();
            AddItemCommand = new Command(AddItem);
            LoadItemsCommand = new Command(async () => await LoadItems());
        }
        #endregion
        #region Helpers
        public async Task LoadItems()
        {
            Items.Clear();
            var items = await DataStore.GetItemsAsync(true);
            foreach(var item in items)
                Items.Add(item);
        }
        public async void AddItem(object obj) 
        {
            await DataStore.AddItemAsync((T)obj);
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedItem = default(T);
        }
        public void OnSelectedItem(T item)
        {
            if (item == null)
                return;
        }
        #endregion
    }
}
