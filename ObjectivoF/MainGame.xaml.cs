using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class MainGame : ContentPage
    {
        public MainGame()
        {
            InitializeComponent();
        }

        async void Handle_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Participate());
        }
       

        async void Handle_Clicked_1(object sender,EventArgs e)
        {
            await Navigation.PushAsync(new TwoParticipate());
        }
    }
}
