using AppMobiBank.Models;
using AppMobiBank.ViewModels;
using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobiBank.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InsurencePage : ContentPage
    {
        InsurenceViewModel _insurences;
        OperationViewModel _operation;
        public InsurencePage()
        {
            InitializeComponent();
            BindingContext = _insurences = new InsurenceViewModel();
            _operation = new OperationViewModel();
            background.Source = new Uri("https://mmintafood.files.wordpress.com/2013/04/img_0515.jpg");
        }

        protected override void OnAppearing()
        {
            _insurences.OnAppearing();
            _insurences.LoadItemsCommand.Execute(true);
            _operation.LoadItemsCommand.Execute(true);
            InsurencesPicker.ItemsSource = _insurences.Items.Select((Insurence i) => i.Kind).ToList();
            if (InsurencesPicker.ItemsSource.Count == 0)
                H2.Text = "Brak aktywnych polis ubezpieczeniowych";
            InsurencesPicker.SelectedIndex = 0;
            AccNumber.Text = SelectedAccountNumber();
            InsurenceListView.ItemsSource = _insurences.Items.Where((Insurence i) => i.Kind == InsurencesPicker.SelectedItem);
        }
        private void Changed(object sender, EventArgs e)
        {
            InsurenceListView.ItemsSource = null;
            InsurenceListView.ItemsSource = _insurences.Items.Where((Insurence i) => i.Kind == InsurencesPicker.SelectedItem);
            AccNumber.Text = SelectedAccountNumber();
        }
        #region Linq
        private int SelectedOperationId()
        {
            var id = 
            (
                from i in _insurences.Items
                where i.Kind == InsurencesPicker.SelectedItem
                select i.IdOperation
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