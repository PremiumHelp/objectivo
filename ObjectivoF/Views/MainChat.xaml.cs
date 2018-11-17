using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace ObjectivoF.Views
{
    public partial class MainChat : ContentPage
    {
        Firebase db = new Firebase();
        Group gm = new Group();
        public MainChat()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<GroupPage, Group>(this, "GroupProp", (page, data) =>
            {
                gm = data;

                _lstChat.BindingContext = db.subChat(data.Key);

                MessagingCenter.Unsubscribe<GroupPage, Group>(this, "GroupProp");

            });
        }

        async void Handle_Clicked(object sender, System.EventArgs e)
        {


            var chatOBJ = new Chat { UserMessage = _etMessage.Text, UserName = Users.UserName };
            await db.saveMessage(chatOBJ, gm.Key);


        }
    }
}
