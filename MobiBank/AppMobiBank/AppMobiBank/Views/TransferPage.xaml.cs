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
    public partial class TransferPage : ContentPage
    {
        AccountViewModel _account;
        OperationViewModel _operation;
        TransferViewModel _transfer;
        PermamentTransferViewModel _permamentTransfer;
        public TransferPage()
        {
            InitializeComponent();
            _account = new AccountViewModel();
            _operation = new OperationViewModel();
            _transfer = new TransferViewModel();
            _permamentTransfer = new PermamentTransferViewModel();
            background.Source = new Uri("https://cdn.wallpapersafari.com/47/41/x2RTiN.jpg");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _account.LoadItemsCommand.Execute(true);
            _operation.LoadItemsCommand.Execute(true);
            _transfer.LoadItemsCommand.Execute(true);
            _permamentTransfer.LoadItemsCommand.Execute(true);
            Accounts.ItemsSource = _account.Items.Select((Account a) => a.AccountNumber).ToList();
            Accounts.SelectedIndex = 0;
        }

        private void PTChanged(object sender, CheckedChangedEventArgs e)
        {
            if (CheckPT.IsChecked)
                FieldsPT.IsVisible = true;
            else
                FieldsPT.IsVisible = false;

        }

        private void Send(object sender, EventArgs e)
        {
            if (Money.Text != null)
            {
                Operation operation = new Operation
                {
                    IdOperation = _operation.Items.Select((Operation o) => o.IdOperation).Last() + 1,
                    AccountNumber = Accounts.SelectedItem.ToString(),
                    BeginingDate = DateTime.Now,
                    Type = "przelew",
                    Value = Decimal.Parse(Money.Text),
                    IsActive = true
                };
                Transfer transfer = new Transfer
                {
                    IdTransfer = _transfer.Items.Select((Transfer t) => t.IdTransfer).Last() + 1,
                    IdOperation = operation.IdOperation,
                    ForeignNumber = ForeignNumber.Text,
                    Title = Title.Text,
                };
                if (CheckPT.IsChecked)
                {
                    PermamentTransfer pt = new PermamentTransfer
                    {
                        IdPT = _permamentTransfer.Items.Select((PermamentTransfer p) => p.IdPT).Last() + 1,
                        IdTransfer = transfer.IdTransfer,
                        Frecuency = Int32.Parse(Frecuency.Text),
                        Term = LastTerm.Date
                    };
                    operation.Type = "przelew stały";
                    _permamentTransfer.AddItemCommand.Execute(pt);
                }
                _operation.AddItemCommand.Execute(operation);
                _transfer.AddItemCommand.Execute(transfer);
                _account.value = Decimal.Parse(Money.Text);
                _account.account = _account.Items.Where((Account a) => a.AccountNumber == Accounts.SelectedItem).First();
                _account.UpdateBalanceCommand.Execute(true);
                Application.Current.MainPage.Navigation.PopAsync();
                Application.Current.MainPage.Navigation.PushAsync(new AboutPage(), true);
            }
            else
                MoneyValidation.IsVisible = true;

        }
    }
}