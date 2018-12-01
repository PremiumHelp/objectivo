using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class TwoThanks : ContentPage
    {
        public TwoThanks()
        {
            InitializeComponent();
            insertUser();
            lblScore.Text = Settings1.Score.ToString();
            lblUsername.Text = Settings1.Username;
           
        }
       
        public async void insertUser()
        {

            UserScore item = new UserScore()
          {
                Username = Settings1.Username,
                Score = Settings1.Score,
                

            };
            if (Settings1.MobileService != null)
            {
                await Settings1.MobileService.GetTable<UserScore>().InsertAsync(item);

            }
        }
        public void Cancel(object sender, EventArgs args)
        {

            Application.Current.MainPage = new TabbedPages.Home();
        }
    }
}
