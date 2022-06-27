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
        CardViewModel _cards;

        public CardPage()
        {
            InitializeComponent();
            BindingContext = _cards = new CardViewModel();
            background.Source = new Uri("https://cdn.galleries.smcloud.net/t/galleries/gf-w6Jh-L3h7-HFiz_czerwone-pomarancze-z-sycylii-co-to-za-odmiana-jak-je-wykorzystac-664x442-nocrop.jpg");

        }
        protected override void OnAppearing()
        {
            _cards.LoadItemsCommand.Execute(true);
            CardsPicker.ItemsSource = _cards.Items.Select((Card c) => c.CardNumber).ToList();
            CardsPicker.SelectedIndex = 0;
            ItemsListView.ItemsSource = _cards.Items.Where((Card c) => c.CardNumber == CardsPicker.SelectedItem);         
        }
        private void Changed(object sender, EventArgs e)
        {
            ItemsListView.ItemsSource = null;
            ItemsListView.ItemsSource = _cards.Items.Where((Card c) => c.CardNumber == CardsPicker.SelectedItem);
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

            _cards.SelectedItem = SelectedCard();
            if (_cards.SelectedItem != null)
                _cards.DisCardCommand.Execute(_cards.SelectedItem);
            DisCard.IsVisible = false;
            Main.IsVisible = true;
        }

        private void Cancel(object sender, EventArgs e)
        {
            Main.IsVisible = true;
            DisCard.IsVisible = false;
        }
        #region Linq
        private Card SelectedCard()
        {
            var card = (
            from c in _cards.Items
            where c.CardNumber == CardsPicker.SelectedItem
            select c
            ).First();
            return card;
        }

        #endregion
    }
}