using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class FlashCard : ContentPage
    {
     

        public FlashCard()
        {
            InitializeComponent();
        }

        void Handle_Clicked_2(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Clothes());
        }

        void Handle_Clicked_4(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Animals());
        }

        void Handle_Clicked_3(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new School());
        }

        void Handle_Clicked_1(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Vegetables());
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new Fruit());
        }
    }
}
