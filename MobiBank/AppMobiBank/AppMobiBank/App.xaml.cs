using AppMobiBank.Services;
using AppMobiBank.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppMobiBank
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<CardDataStore>();
            DependencyService.Register<DepositDataStore>();
            DependencyService.Register<LoanDataStore>();
            DependencyService.Register<AccountDataStore>();
            DependencyService.Register<InsurenceDataStore>();
            DependencyService.Register<TransferDataStore>();
            DependencyService.Register<PermamentTransferDataStore>();
            DependencyService.Register<OperationDataStore>();
            DependencyService.Register<BankServiceReference.BankServiceClient>();

        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
