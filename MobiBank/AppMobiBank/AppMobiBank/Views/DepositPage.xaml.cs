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
        decimal initial { get; set; }
        public DepositPage()
        {
            InitializeComponent();
            BindingContext = _deposit = new DepositViewModel();
            _operation = new OperationViewModel();
            background.Source = new Uri("https://cdn.wallpapersafari.com/47/41/x2RTiN.jpg");
        }
        protected override void OnAppearing()
        {
            _deposit.OnAppearing();
            _deposit.LoadItemsCommand.Execute(true);
            DepositPicker.ItemsSource = _deposit.Items.Select((Deposit c) => c.Name).ToList();
            DepositPicker.SelectedIndex = 0;
            DepositsListView.ItemsSource = _deposit.Items.Where((Deposit c) => c.Name == DepositPicker.SelectedItem).ToList();
        }
        private void Changed(object sender, EventArgs e)
        {
            DepositsListView.ItemsSource = null;
            DepositsListView.ItemsSource = _deposit.Items.Where((Deposit c) => c.Name == DepositPicker.SelectedItem).ToList();
        }
        private decimal DepositGain()
        {
            _operation.LoadItemsCommand.Execute(true);
            var startDate =
            (
                from op in _operation.Items
                join dep in _deposit.Items
                on op.IdOperation equals dep.IdOperation
                where dep.Name == DepositPicker.SelectedItem
                select op.BeginingDate
            ).FirstOrDefault();

            var endDate = DateTime.Now;
            var ratio =
            (
                from dep in _deposit.Items
                where dep.Name == DepositPicker.SelectedItem
                select dep.Percent
            ).FirstOrDefault();

            initial =
            (
                from dep in _deposit.Items
                where dep.Name == DepositPicker.SelectedItem
                select dep.InitialContribution
            ).FirstOrDefault();

            return Decimal.Round(initial * (decimal)((endDate - startDate).TotalDays/ 365) * ratio, 2);
            
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
        public void CheckOffers(object sender, EventArgs e)
        {

        }
    }
}