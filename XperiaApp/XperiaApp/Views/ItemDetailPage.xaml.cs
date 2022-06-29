using System.ComponentModel;
using Xamarin.Forms;
using XperiaApp.ViewModels;

namespace XperiaApp.Views
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