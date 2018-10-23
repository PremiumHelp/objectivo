using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ObjectivoF.TabbedPages
{
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }
        async void VoiceTranslation(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new VoiceTranslation());
        }
        async void ObjectTranslation(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ObjectTranslation());
        }

		async void PhraseBook(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new PhraseBook());
		}
      
        async void Games(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Games());
        }
    }
}
