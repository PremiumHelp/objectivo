using System;
using System.Collections.Generic;
using ObjectivoF.ViewModel;
using Xamarin.Forms;
using ObjectivoF.Models;
namespace ObjectivoF
{
    public partial class FinalScore : ContentPage
    {
        public FinalScore(FinalScoreModel finalScore)
        {
            InitializeComponent();

            BindingContext = new ViewModelScore(finalScore);


        }

        async void CancelGame(object sender, EventArgs e){

            await Navigation.PushAsync(new TabbedPages.Home());
        }
    }
}
