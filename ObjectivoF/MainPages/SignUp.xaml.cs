using System;
using System.Collections.Generic;
using Xamarin.Forms;


namespace ObjectivoF
{
    public partial class SignUp : ContentPage
    {
        public User newUser { get; set; }
        const string uri = "http://localhost:4200/user/";
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
            newUser = new User();
           
            newUser.Email = email;
            newUser.Name = name;
            newUser.Password = password;
            //TODO send warning  if the email name and password are empty 
            var response = await HttpService.SignUp(uri + "signUp", newUser);
            System.Diagnostics.Debug.WriteLine(response);

        }
       
    }
}
