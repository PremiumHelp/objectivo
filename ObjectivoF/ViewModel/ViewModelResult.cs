using System;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace ObjectivoF.ViewModel
{
    public class ViewModelResult : ViewModelBase
    {
        private const string path = "/game/";

        private string currentUser;


        public string CurrentUser
        {
            get => currentUser;
            set => SetProperty(ref currentUser, value);

        }

        private string otherUser;

        public string OtherUser
        {
            get => otherUser;
            set => SetProperty(ref otherUser, value);

        }

        public ViewModelResult()
        {

        }
        private async void GetResult(){

            Game newGame = new Game();

            var response = await HttpService.GetResults(Constants.uri + path + "getResults");
          
            var data = await response.Content.ReadAsStringAsync();
            var gameresults = JObject.Parse(data);



        }

    }
}

