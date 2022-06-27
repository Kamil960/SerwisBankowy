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
    public partial class DepositPage : ContentPage
    {
        DepositViewModel _deposit;
        OperationViewModel _operation;
        AccountViewModel _account;
        decimal initial { get; set; }
        public DepositPage()
        {
            InitializeComponent();
            BindingContext = _deposit = new DepositViewModel();
            _operation = new OperationViewModel();
            _account = new AccountViewModel();
            background.Source = new Uri("https://togethermagazyn.pl/wp-content/uploads/2018/02/pomara%C5%84cze-1050x520.jpg");
        }
        protected override void OnAppearing()
        {
            _deposit.OnAppearing();
            _deposit.LoadItemsCommand.Execute(true);
            _operation.LoadItemsCommand.Execute(true);
            _account.LoadItemsCommand.Execute(true);
            DepositPicker.ItemsSource = NameList();
            if (DepositPicker.ItemsSource.Count == 0)
                H2.Text = "Brak aktywnych lokat";
            DepositPicker.SelectedIndex = 0;
            AccNumber.Text = SelectedAccountNumber();
            DepositsListView.ItemsSource = _deposit.Items.Where((Deposit c) => c.Name == DepositPicker.SelectedItem).ToList();
            
        }
        private void Changed(object sender, EventArgs e)
        {
            AccNumber.Text = SelectedAccountNumber();
            DepositsListView.ItemsSource = null;
            DepositsListView.ItemsSource = _deposit.Items.Where((Deposit c) => c.Name == DepositPicker.SelectedItem).ToList();
        }
        private decimal DepositGain()
        {
            _operation.LoadItemsCommand.Execute(true);
            return Decimal.Round(Initial() * Ratio() / 100 * (decimal)((DateTime.Now - StartDate()).TotalDays / 365), 2);
        }
        public decimal DepositSum()
        {
            return Decimal.Round(initial + DepositGain(), 2);
        }
        public void CloseDeposit(object sender, EventArgs e)
        {
            Main.IsVisible = false;
            CloseDepositView.IsVisible = true;
            Gain.Text = DepositGain().ToString();
            Sum.Text = DepositSum().ToString();
        }
        public void ApproveCloseDeposit(object sender, EventArgs e)
        {

            _operation.SelectedItem = SelectedOperation();
            _operation.DissActiveOperationCommand.Execute(_operation.SelectedItem);
            _operation.AddItemCommand.Execute(CloseDepositOperation());
            var acc = _account.Items.Where((Account a) => a.AccountNumber == SelectedAccountNumber()).FirstOrDefault();
            _account.cash = decimal.Parse(Sum.Text);
            _account.account = acc;
            _account.UpdateBalanceCommand.Execute(true);
            DepositPicker.ItemsSource = NameList();
            DepositPicker.SelectedIndex = 0;
            Main.IsVisible = true;
            CloseDepositView.IsVisible = false;
        }
        public void Back(object sender, EventArgs e)
        {
            Main.IsVisible = true;
            CloseDepositView.IsVisible = false;
        }
        #region Linq
        private string SelectedAccountNumber()
        {
            var num =
           (
               from o in _operation.Items
               where o.IdOperation == SelectedOperationId()
               select o.AccountNumber
           ).FirstOrDefault();
            return num;
        }
        private int SelectedOperationId()
        {
            var id =
            (
                from d in _deposit.Items
                where d.Name == DepositPicker.SelectedItem
                select d.IdOperation
            ).FirstOrDefault();
            return id;
        }
        private Operation SelectedOperation()
        {
            Operation op =
            (
                from o in _operation.Items
                where o.IdOperation == SelectedOperationId()
                select o
            ).First();
            return op;
        }
        private DateTime StartDate()
        {
            var startDate =
            (
                from op in _operation.Items
                join dep in _deposit.Items
                on op.IdOperation equals dep.IdOperation
                where dep.Name == DepositPicker.SelectedItem
                select op.BeginingDate
            ).FirstOrDefault();
            return startDate;
        }
        private decimal Ratio()
        {
            var ratio =
            (
                from dep in _deposit.Items
                where dep.Name == DepositPicker.SelectedItem
                select dep.Percent
            ).FirstOrDefault();
            return ratio;
        }
        private decimal Initial()
        {
            initial =
            (
                from dep in _deposit.Items
                where dep.Name == DepositPicker.SelectedItem
                select dep.InitialContribution
            ).FirstOrDefault();
            return initial;
        }

        private Operation CloseDepositOperation()
        {
            Operation op = new Operation
            {
                IdOperation = _operation.Items.Select(x => x.IdOperation).Last() + 1,
                AccountNumber = SelectedAccountNumber(),
                Type = "zamknięcie lokaty",
                Value = DepositSum(),
                BeginingDate = DateTime.Now,
                FinishDate = DateTime.Now,
                IsActive = true
            };
            return op;
        }
        private List<string> NameList()
        {
            List<string> nameList =
            (
                from dep in _deposit.Items
                join op in _operation.Items
                on dep.IdOperation equals op.IdOperation
                where op.IsActive == true
                select dep.Name
            ).ToList();
            return nameList;
        }
        #endregion

    }
}