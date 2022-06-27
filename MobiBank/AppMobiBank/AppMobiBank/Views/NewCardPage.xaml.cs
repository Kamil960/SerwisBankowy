using AppMobiBank.Models;
using AppMobiBank.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobiBank.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewCardPage : ContentPage
    {
        NewCardViewModel _viewModel;
        OperationViewModel _operation;
        AccountViewModel _account;
        Card card;
        string kind = "";
        string color = "";
        public NewCardPage()
        {
            InitializeComponent();
            background.Source = new Uri("https://zasoby.ekologia.pl/artykulyNew/21032/xxl/shutterstock-1239738199_800x600.jpg");
            BindingContext = _viewModel = new NewCardViewModel();
            _operation = new OperationViewModel();
            _account = new AccountViewModel();  

        }
        protected override void OnAppearing()
        {
            _viewModel.LoadItemsCommand.Execute(this);
            _operation.LoadItemsCommand.Execute(this);
            _account.LoadItemsCommand.Execute(this);
            AccountsPicker.ItemsSource = _account.Items.Select((Account a) => a.AccountNumber).ToList();
            AccountsPicker.SelectedIndex = 0;
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
            card = _viewModel.card = new Card{AccountNumber = AccountsPicker.SelectedItem.ToString(), CardNumber = random.Next(1000000, 9999999).ToString(), Kind = kind, Color = color, Activity = "Aktywna" };
            var operation = AddCardOperation();
            _viewModel.AddItemCommand.Execute(card);
            _operation.AddItemCommand.Execute(operation);
            Application.Current.MainPage.Navigation.PopAsync();
            Application.Current.MainPage.Navigation.PushAsync(new CardPage(), true);
        }

        private Operation AddCardOperation()
        {
            Operation op = new Operation
            {
                IdOperation = _operation.Items.Select(x => x.IdOperation).Last() + 1,
                AccountNumber = AccountsPicker.SelectedItem.ToString(),
                Type = "dodanie karty płatniczej",
                BeginingDate = DateTime.Now,
                FinishDate = DateTime.Now,
                IsActive = true
            };
            return op;
        }
    }
}