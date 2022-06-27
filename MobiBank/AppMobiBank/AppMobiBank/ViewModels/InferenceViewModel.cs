using AppMobiBank.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppMobiBank.ViewModels
{
    public class InferenceViewModel : ItemViewModel<Inference>
    {
        public ICommand LoadSelectedItemsCommand { get; }
        public string type { get; set; }
        public InferenceViewModel() : base()
        {
            LoadSelectedItemsCommand = new Command(async () => await SelectedItems(type));
        }
        
        private async Task<List<Inference>> SelectedItems(string type)
        {
           return await Task.FromResult(Items.Where((Inference inf) => inf.Type.Equals(type)).ToList());
        }
    }
}
