using Firebase.Database.Query;
using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XperiaApp.Models;

namespace XperiaApp.LoginSystem
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            { 
            if(string.IsNullOrEmpty(txtName.Text)|| string.IsNullOrEmpty(txtPhone.Text)|| string.IsNullOrEmpty(txtEmail.Text)|| string.IsNullOrEmpty(txtPassword.Text))
            {
               await DisplayAlert("Error", "Please fill all required fields and try again","OK");
                return;
            }
            if(txtCPassword.Text!=txtPassword.Text)
            {
                await DisplayAlert("Error", "Password Do Not Match", "OK");
                return;
            }

                //App.db.CreateTable<Users>();
                //var check = App.db.Table<Users>().FirstOrDefault(x => x.Email == txtEmail.Text);

                //if (check != null)
                // {
                // await DisplayAlert("Error", "This Email Is Already Registered", "OK");
                // return;
                //}

                LoadingInd.IsRunning = true;

                int LastID, NewID = 1;

                var LastRecord = (await App.firebaseDatabase.Child("Users").OnceAsync<Users>()).FirstOrDefault();
                if (LastRecord != null)
                {
                    LastID = (await App.firebaseDatabase.Child("Users").OnceAsync<Users>()).Max(a => a.Object.UserId);
                    NewID = ++LastID;
                }
                Users u = new Users()
                {
                    UserId= NewID,
                    Name = txtName.Text,
                    Email = txtEmail.Text,
                    Password = txtPassword.Text,
                    Phone = txtPhone.Text,
                };

               


                await App.firebaseDatabase.Child("Users").PostAsync(u);

                LoadingInd.IsRunning = false ;


                //App.db.Insert(u);
                await DisplayAlert("Success", "Account Registered", "OK");
                await Navigation.PushAsync(new Login());

            }
            catch(Exception ex)
            
            {
                LoadingInd.IsRunning = false;
                await DisplayAlert("Error", "Something Went Wrong, PLease Try Again Later.\nError"+ ex.Message, "OK");
            }


        }
    }
}