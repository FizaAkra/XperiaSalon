using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XperiaApp.LoginSystem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            Task.Run(RotateImage);
        }
        private async void RotateImage()
        {
            while(true)
            {
                await parallax_20.RelRotateTo(300, 8000, Easing.Linear);
            }
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {

        }

        private async void btnGetStarted_Clicked(object sender, EventArgs e)
        { 
            App.Current.MainPage = new NavigationPage(new Login());
        }
    }
}