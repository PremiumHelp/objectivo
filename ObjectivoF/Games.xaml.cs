using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class Games : ContentPage
    {
        public Games()
        {
            InitializeComponent();
        }
                async void Participate(object sender, EventArgs e)         {             await Navigation.PushAsync(new Participate());         }
        async void Flippo(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Flippo());
        }
    }
}
