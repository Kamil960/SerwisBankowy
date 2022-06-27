using AppMobiBank.Models;
using AppMobiBank.Models.ModelForView;
using AppMobiBank.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobiBank.Views
{
    public partial class AboutPage : ContentPage
    {
        AccountViewModel _accounts;
        OperationViewModel _operations;
        public AboutPage()
        {
            InitializeComponent();
            BindingContext = _accounts = new AccountViewModel();
            BindingContext = _operations = new OperationViewModel();
            background.Source = new Uri("https://media.istockphoto.com/vectors/dot-and-line-consisting-of-abstract-graphics-vector-id546763916");
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _accounts.OnAppearing();
            _operations.OnAppearing();
            _accounts.LoadItemsCommand.Execute(true);
            _operations.LoadItemsCommand.Execute(true);
            Accounts.ItemsSource = _accounts.Items.Select((Account a) => a.AccountNumber).ToList();
            Accounts.SelectedIndex = 0;
            History.ItemsSource = OrderedOperations();
            Balance.Text = GetBalance();
        }
        private void Changed(object sender, EventArgs e)
        {
            History.ItemsSource = null;
            History.ItemsSource = OrderedOperations();
            Balance.Text = GetBalance();
        }
        private string GetBalance()
        {
            if (Accounts.SelectedItem != null)
            {
                var balance =
                (
                    from acc in _accounts.Items
                    where acc.AccountNumber == Accounts.SelectedItem
                    select acc.AccountBalance
                ).First();
                return balance.ToString();
            }
            else
                return string.Empty;
        }

        private void Search(object sender, EventArgs e)
        {
            _operations.Type = SearchBar.Text;
            _operations.FindTypeCommand.Execute(true);
            History.ItemsSource = _operations.Operations.OrderByDescending(o => o.BeginingDate);
        }

        #region Linq
        private List<Operation> OrderedOperations()
        {
            var op =
            (
                from o in _operations.Items
                where o.AccountNumber == Accounts.SelectedItem
                orderby o.BeginingDate descending
                select o
            ).ToList();
            return op;
        }
        #endregion

    }
}