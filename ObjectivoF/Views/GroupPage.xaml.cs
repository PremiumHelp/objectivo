using System;
using System.Collections.Generic;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace ObjectivoF.Views
{
    public partial class GroupPage : ContentPage
    {
        Firebase db = new Firebase();
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var list = await db.getGroupList();
            _lstx.BindingContext = list;
        }

        public GroupPage()
        {
            InitializeComponent();


            Device.BeginInvokeOnMainThread(() =>
            {

                Navigation.PushPopupAsync(new Pops.MyPopups());
            });
        }

        async void Handle_Refreshing(object sender, System.EventArgs e)
        {
            _lstx.BindingContext = await db.getGroupList();
            _lstx.IsRefreshing = false;
        }

        void Info_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Current User", Users.UserName, "Okey");
        }

        void Plus_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new AddGroup());

        }

        async void FbLogout(object sender, EventArgs e)
        {
            var result = await DependencyService.Get<IFacebookLogin>().SignOut();
            if (result.Status == FBStatus.Success)
            {
                  App.Current.MainPage = new NavigationPage(new ObjectivoFPage());
            }
            else
            {
                await DisplayAlert("Error", result.Message, "Ok");
            }
        }

        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {


            if (_lstx.SelectedItem != null)
            {
                var selectGroup = (Group)_lstx.SelectedItem;

                Navigation.PushAsync(new MainChat());
         
                MessagingCenter.Send<GroupPage, Group>(this, "GroupProp", selectGroup);




            }

        }
    }
}
