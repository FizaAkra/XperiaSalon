using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XperiaApp.Models;

namespace XperiaApp.LoginSystem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            
            if(string.IsNullOrEmpty(txtEmail.Text)|| string.IsNullOrEmpty(txtPassword.Text))
            {
                await DisplayAlert("Error", "Please Fill All Required Field", "OK");
                return;
            }

            try
            {
                LoadingInd.IsRunning = true;
                var check = (await App.firebaseDatabase.Child("Users").OnceAsync<Users>()).FirstOrDefault(x => x.Object.Email == txtEmail.Text && x.Object.Password == txtPassword.Text);

                if (check == null)
                {
                    LoadingInd.IsRunning = false;
                    await DisplayAlert("Error", "Email Or Password are Incoreect", "OK");
                    return;
                }
                else
                {
                    await Navigation.PushAsync(new UsersList());
                }
            }
            catch (Exception ex)

            {
                LoadingInd.IsRunning = false;
                await DisplayAlert("Error", "Something Went Wrong, PLease Try Again Later.\nError" + ex.Message, "OK");
            }

        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Register());
            
        }
    }
}