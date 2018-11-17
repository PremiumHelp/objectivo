using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace ObjectivoF.Pops
{
    public partial class MyPopups : PopupPage
    {
        public MyPopups()
        {
            InitializeComponent();
        }
       
        void Handle_Clicked(object sender, System.EventArgs e)
        {
            Users.UserName = _username.Text;
            Navigation.PopPopupAsync();
        }
    }
}
