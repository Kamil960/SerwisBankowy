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
    public class NewCardViewModel : CardViewModel
    {
        IDataStore<Card> DataStore => DependencyService.Get<IDataStore<Card>>();
        public Command AddItemCommand { get; }
        public Command GetLastId { get; }
        public Card card;
        public NewCardViewModel():base()
        {
            Title = "Dodaj karte płatnicza";
            AddItemCommand = new Command(AddItem);
            this.PropertyChanged +=
                (_, __) => AddItemCommand.ChangeCanExecute();
        }
    }
}

