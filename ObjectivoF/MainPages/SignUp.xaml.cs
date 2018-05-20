using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;


namespace ObjectivoF
{
    public partial class SignUp : ContentPage
    {

		private const string path = "/user/";

        public User newUser { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string name { get; set; }

        public SignUp()
        {
            InitializeComponent();
            BindingContext = this;
        }

        async void SigningUp(object sender, EventArgs e)
        {
  
			if (!CheckEntries())
            {
                return;
            }
            User user = new User();
            user.Email = email;
            user.Password = password;
			user.Name = name;
            try
            {
				var response = await HttpService.SignUp(Constants.uri +path+ "signUp", user);
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    DisplayErrorAlert("Email already exist!");
                }
                else if (response.StatusCode == HttpStatusCode.Created)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var userId = JObject.Parse(data);
					App.UserId = userId["userId"].ToString();
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
            if (!CheckEntryService.CheckEntry(EmailEntry, email) ||
                !CheckEntryService.CheckEntry(PasswordEntry, password) ||
			    !CheckEntryService.CheckEntry(NameEntry, name) ||
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
    }
}
