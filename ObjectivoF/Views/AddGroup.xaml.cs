using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ObjectivoF.Views
{
    public partial class AddGroup : ContentPage
    {
        public AddGroup()
        {
            InitializeComponent();
        }
        async void Handle_Clicked(object sender, System.EventArgs e)
        {
            var db = new Firebase();
            await db.saveGroup(new Group() { Name = _rootName.Text });
            await Navigation.PopToRootAsync();

        }
    }
}
