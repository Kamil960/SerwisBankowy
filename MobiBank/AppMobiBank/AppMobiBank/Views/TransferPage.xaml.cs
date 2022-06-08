﻿using AppMobiBank.Models;
using AppMobiBank.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            int filledFieldsCounter = 0;
            foreach (Label info in entryStack.Children.OfType<Label>())
            {
                if (info.IsVisible == false)
                    filledFieldsCounter++;
            }
            if(filledFieldsCounter == entryStack.Children.OfType<Label>().Count())
            {
                var operation = AddTransferOperation();
                var transfer = AddTransfer(operation.IdOperation);
                if (CheckPT.IsChecked)
                {
                    var pt = AddTransfer(transfer.IdTransfer);
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
        }

        private void ValidationForeignNumber(object sender, FocusEventArgs e)
        {
            if (!Regex.Match(ForeignNumber.Text, "^[0-9]{12}").Success)
            {
                ForeignNumberValidated.Text = "Numer konta powinien zawierać 12 cyfr";
                ForeignNumberValidated.IsVisible = true;
            }
            else
                ForeignNumberValidated.IsVisible = false;
        }
        private void ValidationName(object sender, FocusEventArgs e)
        {
            if (!Regex.Match(Name.Text, "[a-zA-Z]").Success)
            {
                NameValidated.Text = "Nazwa nie może zawierać cyfr i znaków specjalnych";
                NameValidated.IsVisible = true;
            }
            else  
                NameValidated.IsVisible = false;
        }
        private void ValidationTitle(object sender, FocusEventArgs e)
        {
            if (!Regex.Match(TransferTitle.Text, "^[a-zA-Z0-9]{0,50}").Success)
            {
                TitleValidated.Text = "Nazwa nie może zawierać cyfr i znaków specjalnych";
                TitleValidated.IsVisible = true;
            }
            else
                TitleValidated.IsVisible = false;
        }
        private void ValidationCashField(object sender, FocusEventArgs e)
        {
            if (!Regex.Match(Money.Text, "[0-9]").Success)
            {
                MoneyValidated.Text = "Nieprawidłowy format kwoty";
                MoneyValidated.IsVisible = true;
            }
            else
            {
                double temp = Math.Round(Double.Parse(Money.Text), 2);
                Money.Text = temp.ToString();
                MoneyValidated.IsVisible = false;
            }
        }

        #region Linq
        private Operation AddTransferOperation()
        {
            Operation operation = new Operation
            {
                IdOperation = _operation.Items.Select((Operation o) => o.IdOperation).Last() + 1,
                AccountNumber = Accounts.SelectedItem.ToString(),
                BeginingDate = DateTime.Now,
                Type = "przelew",
                Value = -Decimal.Parse(Money.Text),
                IsActive = true
            };
            return operation;
        }
        private Transfer AddTransfer(int id)
        {
            Transfer transfer = new Transfer
            {
                IdTransfer = _transfer.Items.Select((Transfer t) => t.IdTransfer).Last() + 1,
                IdOperation = id,
                ForeignNumber = ForeignNumber.Text,
                Title = TransferTitle.Text,
            };
            return transfer;
        }
        private PermamentTransfer AddPermamentTransfer(int id)
        {
            PermamentTransfer pt = new PermamentTransfer
            {
                IdPT = _permamentTransfer.Items.Select((PermamentTransfer p) => p.IdPT).Last() + 1,
                IdTransfer = id,
                Frecuency = Int32.Parse(Frecuency.Text),
                Term = LastTerm.Date
            };
            return pt;
        }
        #endregion
    }
}