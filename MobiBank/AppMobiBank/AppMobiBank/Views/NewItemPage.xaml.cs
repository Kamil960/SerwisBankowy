using AppMobiBank.Models;
using AppMobiBank.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobiBank.Views
{
    public partial class NewItemPage : ContentPage
    {
        public InferenceViewModel inferenceViewModel;

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = inferenceViewModel = new InferenceViewModel();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            inferenceViewModel.LoadItemsCommand.Execute(this);
            inferenceViewModel.type = "kredyt";
            inferenceViewModel.LoadSelectedItemsCommand.Execute(this);

        }

        private void CancelEvent(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PopAsync();
            Application.Current.MainPage.Navigation.PushAsync(new LoanPage(), true);
        }
    }
}