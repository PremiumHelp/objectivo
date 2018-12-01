using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using ObjectivoF.Models;
using ObjectivoF.ViewModel;
using Xamarin.Forms;

namespace ObjectivoF
{
    static public class Settings1
    {
        public const int qCount = 6;
        public static int currentQ = 1;
        public static int Score = 0;
        public static string Username = "";
        public static string otherUsername = "";
        public static int otherScore = 0;


        private static MobileServiceClient mobileServiceClient;

        public static MobileServiceClient MobileService
        {
            get
            {
                if (mobileServiceClient == null)

                    mobileServiceClient = new MobileServiceClient("https://objectivoquiz.azurewebsites.net");

                return mobileServiceClient;
            }
        }
    }


    public partial class TwoQuiz : ContentPage
    {
        int score = 100;
        
        public Game currentGame;

        private const string path = "/game/";

        public TwoQuiz(Game newGame)
        {
            InitializeComponent();

            currentGame = newGame;

            XamarinQuiz item = new XamarinQuiz()
            {
                Question = "a man",
                Answer1 = "eine Frau",
                Answer2 = "ein Mann",
                Answer3 = "ein Auto",
                CorrectAnswer = 2

            };

            XamarinQuiz item2 = new XamarinQuiz()
            {
                Question = "a child",
                Answer1 = "ein Kind",
                Answer2 = "ein Haus",
                Answer3 = "ein Brotchen",
                CorrectAnswer = 1
            };

            XamarinQuiz item3 = new XamarinQuiz()
            {
                Question = "the hospital",
                Answer1 = "der Kranke",
                Answer2 = "das Ungesunde",
                Answer3 = "das Krankenhaus",
                CorrectAnswer = 3
            };
            XamarinQuiz item4 = new XamarinQuiz()
            {
                Question = "to read",
                Answer1 = "Fahren",
                Answer2 = "Rennen",
                Answer3 = "Lesen",
                CorrectAnswer = 3

            };

            XamarinQuiz item5 = new XamarinQuiz()
            {
                Question = "the teacher",
                Answer1 = "der Lehrer",
                Answer2 = "der Mann",
                Answer3 = "die Lehrerin",
                CorrectAnswer = 3

            };

            XamarinQuiz item6 = new XamarinQuiz()
            {
                Question = "snow",
                Answer1 = "Schnee",
                Answer2 = "Wind",
                Answer3 = "Regen",
                CorrectAnswer = 1

            };
            XamarinQuiz item7 = new XamarinQuiz()
            {
                Question = "the desk",
                Answer1 = "die Sessel",
                Answer2 = "der Tisch",
                Answer3 = "die Kopfhohrer",
                CorrectAnswer = 2

            };
            XamarinQuiz item8 = new XamarinQuiz()
            {
                Question = "a bird",
                Answer1 = "ein Hund",
                Answer2 = "eine Vogel",
                Answer3 = "ein Krokodil",
                CorrectAnswer = 2

            };


            IMobileServiceTable<XamarinQuiz> xamarinQuizTable = Settings1.MobileService.GetTable<XamarinQuiz>();

            xamarinQuizTable.InsertAsync(item);
            xamarinQuizTable.InsertAsync(item2);
            xamarinQuizTable.InsertAsync(item3);
            xamarinQuizTable.InsertAsync(item4);
            xamarinQuizTable.InsertAsync(item5);
            xamarinQuizTable.InsertAsync(item6);
            xamarinQuizTable.InsertAsync(item7);
            xamarinQuizTable.InsertAsync(item8);


            ((TwoQuestionViewModel)BindingContext).LoadQuestions();



            btnAnswerOne.Clicked += (sender, ea) =>
            {
                if (((TwoQuestionViewModel)BindingContext).CheckIfCorrect(1)) DoAnswer();
                else
                {
                    score = score / 2;
                  
                }
            };

            btnAnswerTwo.Clicked += (sender, ea) =>
            {
                if (((TwoQuestionViewModel)BindingContext).CheckIfCorrect(2)) DoAnswer();
                else
                {
                    score = score / 2;

                }
            };

            btnAnswerThree.Clicked += (sender, ea) =>
            {
                if (((TwoQuestionViewModel)BindingContext).CheckIfCorrect(3))
                {
                    DoAnswer();
                }
                else
                {
                    score = score / 2;
                  
                }
            };
            btnAnswerFour.Clicked += (sender, ea) =>
            {
                if (((TwoQuestionViewModel)BindingContext).CheckIfCorrect(4))
                {
                    DoAnswer();
                }
                else
                {
                    score = score / 2;
                  
                }
            };
            btnAnswerFive.Clicked += (sender, ea) =>
            {
                if (((TwoQuestionViewModel)BindingContext).CheckIfCorrect(5))
                {
                    DoAnswer();
                }
                else
                {
                    score = score / 2;
                  
                }
            };
            btnAnswerSix.Clicked += (sender, ea) =>
            {
                if (((TwoQuestionViewModel)BindingContext).CheckIfCorrect(6))
                {
                    DoAnswer();
                }
                else
                { 

                    score = score / 2;


                }
            };
        }
       
  




        private void DoAnswer()
        {
            Settings1.Score += score;
            currentGame.FirstPlayerId = App.UserId;
            currentGame.FirstPlayerScore = score;
            var response = HttpService.ChangeResults(Constants.uri + path + currentGame.GameId, currentGame);
            if (Settings1.currentQ < Settings1.qCount)
            {
                Settings1.currentQ++;

                ((TwoQuestionViewModel)BindingContext).ChooseNewQuestion();
            }
            else
            {
                NavigateToEndPage();
            }
        }
       
          async void NavigateToEndPage()
        {
            currentGame.FirstPlayerId = App.UserId;
            currentGame.FirstPlayerScore = score;

            var response = await HttpService.GetResult(Constants.uri + path +"getResults/"+ currentGame.GameId, currentGame);


         

            FinalScoreModel finalScore = new FinalScoreModel();
          
            if (response.StatusCode == HttpStatusCode.OK)
            {


                var data = await response.Content.ReadAsStringAsync();
                var MongoResponse = JObject.Parse(data);
                finalScore.currentUser = MongoResponse["currentUser"].ToString();
                string temp1;
                string temp2;
                temp1 = MongoResponse["currentUserScore"].ToString();
                finalScore.otherUser = MongoResponse["otherUser"].ToString();
                temp2 =MongoResponse["otherUserScore"].ToString();
                finalScore.currentUserScore = int.Parse(temp1);
                finalScore.otherUserScore = int.Parse(temp2);

            }
            Application.Current.MainPage = new FinalScore(finalScore);
        }
    }
}
