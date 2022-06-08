using AppMobiBank.Models;
using AppMobiBank.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppMobiBank.ViewModels
{
    public class OperationViewModel : ItemViewModel<Operation>
    {
        private OperationDataStore OPD;
        public Command DissActiveOperationCommand { get; }
        public Command AddOperationCommand { get; }
        public Command FindTypeCommand { get; }
        public string Type { get; set; }
        public List<Operation> Operations { get; set; }
        public OperationViewModel() :base() 
        {
            OPD = new OperationDataStore();
            AddOperationCommand = new Command(async () => await AddOperationExecute(SelectedItem));
            DissActiveOperationCommand = new Command(async () => await DissActiveExecute(SelectedItem));
            FindTypeCommand = new Command(async () => await FindTypeExecute(Type));
        }
        public async Task AddOperationExecute(Operation item)
        {
            await DataStore.AddItemAsync(item);
        }
        public async Task DissActiveExecute(Operation item)
        {
            item.IsActive = false;
            await DataStore.UpdateItemAsync(item);
        }
        public async Task FindTypeExecute(string type)
        {
            Operations = await OPD.FindType(type);
        }
    }
}
