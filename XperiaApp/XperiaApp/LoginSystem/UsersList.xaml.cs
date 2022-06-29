using Firebase.Database.Query;
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
    public partial class UsersList : ContentPage
    {
        public UsersList()
        {
            InitializeComponent();
            
        }



        protected async override void OnAppearing()
        {
            base.OnAppearing();
            try
            {
                LoadingInd.IsRunning = true;
                LoadData();
                LoadingInd.IsRunning = false;
            }
            catch (Exception ex)
            {
                LoadingInd.IsRunning = false;
               await DisplayAlert("Error", "Something Went Wrong, PLease Try Again Later.\nError" + ex.Message, "OK");
            }
            

        }

        async void LoadData()
        {
            DataList.ItemsSource = (await App.firebaseDatabase.Child("Users").OnceAsync<Users>()).Select(x => new Users
            {
                UserId = x.Object.UserId,
                Name = x.Object.Name,
                Email = x.Object.Email,
                Phone = x.Object.Phone,
                Password = x.Object.Password

            }).ToList();
        }






        private async void DataList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selected = e.Item as Users;

            var item = (await App.firebaseDatabase.Child("Users").OnceAsync<Users>()).FirstOrDefault(a => a.Object.UserId == selected.UserId);


            var choice= await DisplayActionSheet("Options", "Close", "Delete", "View", "Edit", "Favourite", "Archieved");
            if(choice=="View")
            {
                await DisplayAlert("Details", ""+
                    "\nUserId:"+item.Object.UserId+
                    "\nName:"+item.Object.Name+
                    "\nPassword: ****"+item.Object.Password+
                    "\nContact:"+item.Object.Phone+
                    "", "OK");
            }
            if (choice == "Delete")
            {
                bool q = await DisplayAlert("Confirmation", "Are You Sure You Want To Delete" + item.Object.Name, "Yes", "No");
                if(q)
                {
                    await App.firebaseDatabase.Child("Users").Child(item.Key).DeleteAsync();
                    LoadData();
                    await DisplayAlert("Confirmation", "Deleted Permanently" + item.Object.Name, "OK");
                }
              
            }
            if (choice == "Edit")
            {

            }

        }
    }
}