using AppMobiBank.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace AppMobiBank.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}