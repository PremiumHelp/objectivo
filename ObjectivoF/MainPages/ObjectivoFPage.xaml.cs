using Xamarin.Forms;
using System;

namespace ObjectivoF
{
    public partial class ObjectivoFPage : ContentPage
    {
        const string uri = "http://localhost:4200/user/";
        public string email { get; set; }
        public string password { get; set; }

        public ObjectivoFPage()
        {
            InitializeComponent();
            BindingContext = this;
        }
       

        async void TabControl(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabControl());
        }

        async void SignUp(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUp());
        }

     



        async void Login(object sender, EventArgs e)
        {
            //TODO send warning if one of the email or passowrd is empty
            System.Diagnostics.Debug.WriteLine(email , password);
            var response = await HttpService.Login(uri + "signIn", email, password);
            System.Diagnostics.Debug.WriteLine(response);
            //TODO IF StatusCode == 200 go to the main page and take the userId and save it in session
        }
    }
}
