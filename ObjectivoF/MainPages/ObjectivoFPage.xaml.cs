using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
#if __ANDROID__
using Newtonsoft.Json;
#endif

namespace ObjectivoF
{
    public partial class ObjectivoFPage : ContentPage
    {
		private const string path = "/user/";
        public string email { get; set; }
        public string password { get; set; }       
        

       
         public ObjectivoFPage()
        {
           
            InitializeComponent();
            BindingContext = this;
        }


        async void SignUp(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new SignUp());
        }


     


        async void Login(object sender, EventArgs e)
        {
         
			if (!CheckEntries())
            {
                return;
            }
            User user = new User();
            user.Email = email;
            user.Password = password;
            try
           {

				var response = await HttpService.Login(Constants.uri  +path+  "signIn", email, password);
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    DisplayErrorAlert("Wrong email or password");
                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var UserId = JObject.Parse(data);
					App.UserId = UserId["userId"].ToString();

                   
					App.Current.MainPage = new NavigationPage(new TabControl());
                }
                else
                {
                    DisplayErrorAlert("Something went wrong!");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                DisplayErrorAlert("Something went wrong!");
            }
        }
		private bool CheckEntries()
        {
			if (!CheckEntryService.CheckEntry(EmailEntry,email) ||
			    !CheckEntryService.CheckEntry(PasswordEntry, password) ||
               !CheckEntryService.CheckEmailSyntax(email, EmailEntry))
            {
                return false;
            }
            return true;

        }
        private void DisplayErrorAlert(string message)
        {
            DisplayAlert("Alert", message, "OK");
        }


        private async void FbLogin(object sender, EventArgs e)
        {

            var result = await DependencyService.Get<IFacebookLogin>().SignIn();
            if (result.Status == FBStatus.Success)
            {


                App.Current.MainPage = new NavigationPage(new TabControl());

            }
            else
            {
                await DisplayAlert("Error", result.Message, "Ok");
            }

        }
       
        }
    }



