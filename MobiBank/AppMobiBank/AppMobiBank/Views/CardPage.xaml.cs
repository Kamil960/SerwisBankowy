using AppMobiBank.Models;
using AppMobiBank.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobiBank.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CardPage : ContentPage
    {
        CardViewModel _viewModel;
        public CardPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new CardViewModel();
            background.Source = new Uri("https://cdn.wallpapersafari.com/47/41/x2RTiN.jpg");

        }
        protected override void OnAppearing()
        {
            _viewModel.LoadItemsCommand.Execute(true);
            CardsPicker.ItemsSource = _viewModel.Items.Select((Card c) => c.CardNumber).ToList();
            CardsPicker.SelectedIndex = 0;
            ItemsListView.ItemsSource = _viewModel.Items.Where((Card c) => c.CardNumber == CardsPicker.SelectedItem);
        }
        private void Changed(object sender, EventArgs e)
        {
            ItemsListView.ItemsSource = null;
            ItemsListView.ItemsSource = _viewModel.Items.Where((Card c) => c.CardNumber == CardsPicker.SelectedItem);           
        }

        private void Disable(object sender, EventArgs e)
        {
            Main.IsVisible = false;
            DisCard.IsVisible = true;
        }
        private void AddCard(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopAsync();
            Application.Current.MainPage.Navigation.PushAsync(new NewCardPage(), true);
        }

        private void Reson(object sender, CheckedChangedEventArgs e)
        {
            if (Other.IsChecked == true)
            {
                Other1.IsVisible = true;
                Other2.IsVisible = true;
            }
            else
            {
                Other1.IsVisible = false;
                Other2.IsVisible = false;
            }
        }

        private void Disactive(object sender, EventArgs e)
        {
            var disCard = (
            from c in _viewModel.Items
            where c.CardNumber == CardsPicker.SelectedItem
            select c
            ).First();
            _viewModel.SelectedItem = disCard;
            if (_viewModel.SelectedItem != null)
                _viewModel.DisCardCommand.Execute(_viewModel.SelectedItem);
            DisCard.IsVisible = false;
            Main.IsVisible = true;
        }

        private void Cancel(object sender, EventArgs e)
        {
            Main.IsVisible = true;
            DisCard.IsVisible = false;
        }
    }
}