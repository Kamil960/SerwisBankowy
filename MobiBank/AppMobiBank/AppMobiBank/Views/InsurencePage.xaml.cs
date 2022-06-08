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
    public partial class InsurencePage : ContentPage
    {
        InsurenceViewModel _viewModel;
        OperationViewModel _operation;
        public InsurencePage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new InsurenceViewModel();
            _operation = new OperationViewModel();
            background.Source = new Uri("https://cdn.wallpapersafari.com/47/41/x2RTiN.jpg");
        }

        protected override void OnAppearing()
        {
            _viewModel.OnAppearing();
            _viewModel.LoadItemsCommand.Execute(true);
            _operation.LoadItemsCommand.Execute(true);
            InsurencesPicker.ItemsSource = _viewModel.Items.Select((Insurence i) => i.Kind).ToList();
            InsurencesPicker.SelectedIndex = 0;
            InsurenceListView.ItemsSource = _viewModel.Items.Where((Insurence i) => i.Kind == InsurencesPicker.SelectedItem);
            AccNumber.Text = SelectedOperation().AccountNumber;
        }
        private void Changed(object sender, EventArgs e)
        {
            InsurenceListView.ItemsSource = null;
            InsurenceListView.ItemsSource = _viewModel.Items.Where((Insurence i) => i.Kind == InsurencesPicker.SelectedItem);
            AccNumber.Text = SelectedOperation().AccountNumber;
        }

        private void CheckOffers(object sender, EventArgs e)
        {

        }
        #region Linq
        private int SelectedOperationId()
        {
            var id = 
            (
                from i in _viewModel.Items
                where i.Kind == InsurencesPicker.SelectedItem
                select i.IdOperation
            ).FirstOrDefault();
            return id;
        }
        private Operation SelectedOperation()
        {
            var op = 
            (
                from o in _operation.Items
                where o.IdOperation == SelectedOperationId()
                select o
            ).FirstOrDefault();
            return op;
        }
        #endregion
    }
}