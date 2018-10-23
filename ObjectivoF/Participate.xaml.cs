using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class Participate : ContentPage
    {
        public Participate()
        {
            InitializeComponent();
            btnStart.IsEnabled = false;

            entryUsername.TextChanged += delegate
            {
                if (entryUsername.Text.Trim() != String.Empty) btnStart.IsEnabled = true;
                else btnStart.IsEnabled = false;
            };
        }
        public void NavigateToQuiz(object sender, EventArgs args)
        {
            AppSettings.Username = entryUsername.Text;
            Application.Current.MainPage = new Quiz();
        }
    }
}
