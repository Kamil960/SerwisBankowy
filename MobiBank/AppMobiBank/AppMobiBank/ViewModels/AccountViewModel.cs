using AppMobiBank.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobiBank.ViewModels
{
    public class AccountViewModel : ItemViewModel<Account>
    {
        public Command UpdateBalanceCommand;
        public decimal cash { get; set; }
        public Account account;
        public AccountViewModel():base()
        {
            UpdateBalanceCommand = new Command(async () => await UpdateBalance(account, cash));
        }
        public async Task UpdateBalance(Account acc, decimal money)
        {
            acc.AccountBalance = acc.AccountBalance - money;
            await DataStore.UpdateItemAsync(acc);
        }
    }
}
