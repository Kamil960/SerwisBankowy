using AppMobiBank.Models;
using AppMobiBank.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobiBank.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCardPage : ContentPage
    {
        NewCardViewModel _viewModel;
        Card card;
        string kind = "";
        string color = "";
        public NewCardPage()
        {
            InitializeComponent();
            background.Source = new Uri("https://cdn.wallpapersafari.com/47/41/x2RTiN.jpg");
            BindingContext = _viewModel = new NewCardViewModel();
            _viewModel.LoadItemsCommand.Execute(this);
        }
        private void Kind(object sender, EventArgs e)
        {
            if(Type1.IsChecked)
                kind = Type1.Value.ToString();
            else
                kind = Type2.Value.ToString();
        }
        private void Kolor(object sender, EventArgs e)
        {
            if (Color1.IsChecked)
                color = Color1.Value.ToString(); 
            if (Color2.IsChecked)
                color = Color2.Value.ToString();
            if (Color3.IsChecked)
                color = Color3.Value.ToString();
            if (Color4.IsChecked)
                color = Color4.Value.ToString();
        }
        private void Add(object sender, EventArgs e)
        {
            Random random = new Random();
            var id = _viewModel.Items.Last().IdCard;
            card = _viewModel.card = new Card { IdCard = id+1, CardNumber = random.Next(1000000, 9999999).ToString(), Kind = kind, Color = color, Activity = "Aktywna" };
            _viewModel.AddItemCommand.Execute(card);

            Application.Current.MainPage.Navigation.PopAsync();
            Application.Current.MainPage.Navigation.PushAsync(new CardPage(), true);
        }
        private void Cancel(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopAsync();
            Application.Current.MainPage.Navigation.PushAsync(new CardPage(), true);
        }
    }
}