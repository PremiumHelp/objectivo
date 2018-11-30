using System;
using System.Collections.Generic;
using System.Net;
using Newtonsoft.Json.Linq;
using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class TwoParticipate : ContentPage
    {
        private const string path = "/game/";

         public TwoParticipate()
        {
            InitializeComponent();



        }
        async void StartNewGame(object sender, EventArgs args)
        {
            Game newGame = new Game();
            newGame.FirstPlayerId = App.UserId;
            try
            {
                var response = await HttpService.CreateGame(Constants.uri + path + "newGame", newGame);
                if (response.StatusCode == HttpStatusCode.InternalServerError)
                {
                    DisplayErrorAlert("No new game created");
                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var MongoResponse = JObject.Parse(data);
                    newGame.SecondPlayerId = MongoResponse["secondPlayerId"].ToString();
                    newGame.GameId = MongoResponse["_id"].ToString();

                    // send the new game variable with the navigation
                    var gameid = new Game
                    {

                        GameId = ""
                
                };
                    var twoquiz = new TwoQuiz(newGame);
                    await Navigation.PushAsync(twoquiz);
                }
                else
                {

                    DisplayErrorAlert("Something went wrong!");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
                DisplayErrorAlert("Something went wrong!");
            }

          
        }
        private void DisplayErrorAlert(string message)
        {
            DisplayAlert("Alert", message, "OK");
        }
    }
}


