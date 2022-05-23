using AppMobiBank.Models;
using AppMobiBank.Services;
using AppMobiBank.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppMobiBank.ViewModels
{
    public class CardViewModel : ItemViewModel<Card>
    {
        public Command DisCardCommand { get; } 
        public CardViewModel():base()
        {
            Title = "Karty płatnicze";
            DisCardCommand = new Command(async () => await ExecuteDisCardCommand(SelectedItem));
            
        }
        public async Task ExecuteDisCardCommand(Card item)
        {   
            item.IsActive = false;
            item.Activity = "Nieaktywna";
            await DataStore.UpdateItemAsync(item);
        }  
    }
}
