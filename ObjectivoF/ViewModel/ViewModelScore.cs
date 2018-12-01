using System;
using ObjectivoF.Models;

using Xamarin.Forms;

namespace ObjectivoF.ViewModel
{
    public class ViewModelScore : ViewModelBase
    {
        private const string path = "/game/";
      
        private int currentuserScore;
        private FinalScoreModel currentScore;

        public int CurrentUserScore
        {
            get => currentuserScore;
            set => SetProperty(ref currentuserScore, value);
        }
     
        private int otheruserscore;


        public int OtherUserScore
        {
            get => otheruserscore;
            set => SetProperty(ref otheruserscore, value);
        }
       
        private string currentuser;


        public string CurrentUser
        {
            get => currentuser;
            set => SetProperty(ref currentuser, value);
        }

        private string otheruser;


        public string OtherUser
        {
            get => otheruser;
            set => SetProperty(ref otheruser, value);
        }

        public ViewModelScore(FinalScoreModel finalScore)
        {
            currentScore = finalScore;
            // binding here 
            currentuser = currentScore.currentUser;

           currentuserScore = currentScore.currentUserScore;
            otheruser = currentScore.otherUser;
            otheruserscore = currentScore.otherUserScore;
            
        }

    }
}

