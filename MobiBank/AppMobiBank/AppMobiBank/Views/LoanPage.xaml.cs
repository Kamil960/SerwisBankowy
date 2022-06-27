using AppMobiBank.Models;
using AppMobiBank.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobiBank.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoanPage : ContentPage
    {
        LoanViewModel _loans;
        OperationViewModel _operation;
        public LoanPage()
        {
            InitializeComponent();
            background.Source = new Uri("https://s-trojmiasto.pl/zdj/c/n/9/1751/3000x0/1751965.jpg");
            BindingContext = _loans = new LoanViewModel();
            _operation = new OperationViewModel();

        }
        protected override void OnAppearing()
        {
            _loans.OnAppearing();
            _loans.LoadItemsCommand.Execute(true);
            _operation.LoadItemsCommand.Execute(true);
            LoansPicker.ItemsSource = _loans.Items.Select((Loan l) => l.Name).ToList();
            LoansPicker.SelectedIndex = 0;
            AccNumber.Text = SelectedAccountNumber();
            LoansListView.ItemsSource = _loans.Items.Where((Loan l) => l.Name == LoansPicker.SelectedItem);
        }
        private void Changed(object sender, EventArgs e)
        {
            LoansListView.ItemsSource = null;
            LoansListView.ItemsSource = _loans.Items.Where((Loan l) => l.Name == LoansPicker.SelectedItem);
            AccNumber.Text = SelectedAccountNumber();
        }
        private void CheckOffers(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopAsync();
            Application.Current.MainPage.Navigation.PushAsync(new NewItemPage(), true);
        }
        #region Linq
        private int SelectedOperationId()
        {
            var id =
            (
                from l in _loans.Items
                where l.Name == LoansPicker.SelectedItem
                select l.IdOperation
            ).FirstOrDefault();
            return id;
        }
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
        #endregion
    }
}