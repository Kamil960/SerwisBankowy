using AppMobiBank.Models;
using AppMobiBank.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobiBank.ViewModels
{
    public class NewCardViewModel : ItemViewModel<Card>
    {
        public Command AddCardCommand { get; }
        public Command GetLastId { get; }
        public Card card;
        public NewCardViewModel():base()
        {
            Title = "Dodaj karte płatnicza";
            AddCardCommand = new Command(async () => await AddOperationExecute(SelectedItem));
        }
        public async Task AddOperationExecute(Card item)
        {
            await DataStore.AddItemAsync(item);
        }
    }
}

