using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class PhraseBook : ContentPage
    {
        public PhraseBook()
        {
            InitializeComponent();
        }
        async void French(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new French());
        }
        async void German(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new German());
        }
        async void Italian(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Italian());
        }
        async void Spanish(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Spanish());
        }
       
    }
     
}
