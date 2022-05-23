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
    public partial class LoanPage : ContentPage
    {
        private LoanViewModel _viewModel;
        public LoanPage()
        {
            InitializeComponent();
            BindingContext = _viewModel = new LoanViewModel();
            background.Source = new Uri("https://cdn.wallpapersafari.com/47/41/x2RTiN.jpg");
        }
        protected override void OnAppearing()
        {
            _viewModel.OnAppearing();
            _viewModel.LoadItemsCommand.Execute(true);
            LoansPicker.ItemsSource = _viewModel.Items.Select((Loan l) => l.Name).ToList();
            LoansPicker.SelectedIndex = 0;
            LoansListView.ItemsSource = _viewModel.Items.Where((Loan l) => l.Name == LoansPicker.SelectedItem);
        }
        private void Changed(object sender, EventArgs e)
        {
            LoansListView.ItemsSource = null;
            LoansListView.ItemsSource = _viewModel.Items.Where((Loan l) => l.Name == LoansPicker.SelectedItem);
        }
        private void CheckOffers(object sender, EventArgs e)
        {

        }
    }
}