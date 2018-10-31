using System;
using System.Collections.Generic;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace ObjectivoF
{
    public class AppSettings
    {
        public const int QUESTIONS_COUNT = 3;
        public static int CurrentQuestion = 1;
        public static int Score = 0;
        public static string Username = "";

        private static MobileServiceClient mobileServiceClient;

        public static MobileServiceClient MobileService
        {
            get
            {
                if (mobileServiceClient == null;
                   
                    mobileServiceClient = new MobileServiceClient("https://objectivoquiz.azurewebsites.net");
              
                    return mobileServiceClient;
            }
        }
    }

    public partial class Quiz : ContentPage
    {
        // int _choice = 0;
        int score = 100;

        public Quiz()
        {
            InitializeComponent();
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


            IMobileServiceTable<XamarinQuiz> xamarinQuizTable = AppSettings.MobileService.GetTable<XamarinQuiz>();

            xamarinQuizTable.InsertAsync(item);
            xamarinQuizTable.InsertAsync(item2);
            xamarinQuizTable.InsertAsync(item3);

            ((QuestionViewModel)BindingContext).LoadQuestions();

            btnAnswerOne.Clicked += (sender, ea) =>
            {
                if (((QuestionViewModel)BindingContext).CheckIfCorrect(1)) DoAnswer();
                else
                {
                    score = score / 2;
                }
            };

            btnAnswerTwo.Clicked += (sender, ea) =>
            {
                if (((QuestionViewModel)BindingContext).CheckIfCorrect(2)) DoAnswer();
                else
                {
                    score = score / 2;
                }
            };

            btnAnswerThree.Clicked += (sender, ea) =>
            {
                if (((QuestionViewModel)BindingContext).CheckIfCorrect(3))
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
            AppSettings.Score += score;
            if (AppSettings.CurrentQuestion < AppSettings.QUESTIONS_COUNT)
            {
                AppSettings.CurrentQuestion++;
                ((QuestionViewModel)BindingContext).ChooseNewQuestion();
            }
            else
            {
                NavigateToEndPage();
            }
        }

        private void NavigateToEndPage()
        {
            Application.Current.MainPage = new ThanksForPlaying();
        }
    }
}
