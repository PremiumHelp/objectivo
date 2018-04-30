using System;
using System.Collections.Generic; 
using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class StartPage : ContentPage
    {
        public StartPage()
        {
            InitializeComponent();


        }
        async void ObjectivoFPage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ObjectivoFPage());
        }
      
       
    }
}
