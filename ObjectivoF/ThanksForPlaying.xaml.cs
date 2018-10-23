using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class ThanksForPlaying : ContentPage
    {
        public ThanksForPlaying()
        {
            InitializeComponent();
            insertUser();
            lblScore.Text = AppSettings.Score.ToString();
            lblUsername.Text = AppSettings.Username;
        }
        public async void insertUser()
        {
            UserScore item = new UserScore()
            {
                Username = AppSettings.Username,
                Score = AppSettings.Score
            };
            if (AppSettings.MobileService != null)
            {
                await AppSettings.MobileService.GetTable<UserScore>().InsertAsync(item);

            }
        }
        public void Cancel(object sender, EventArgs args)
        {

            Application.Current.MainPage = new TabbedPages.Home();
        }

    }
}
