using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;

namespace ObjectivoF.ViewModel
{
    public class TwoQuestionViewModel : INotifyPropertyChanged
    {
        private int _correctAnswer = 0;
        public int CorrectAnswer
        {
            get { return this._correctAnswer; }
            set
            {
                this._correctAnswer = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("CorrectAnswer"));
            }
        }
        private string _question;
        public string Question
        {
            get { return this._question; }
            set
            {
                this._question = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Question"));
            }
        }

        private string _answer1;
        public string Answer1
        {
            get { return this._answer1; }
            set
            {
                this._answer1 = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer1"));
            }
        }

        private bool _answer1Enabled;
        public bool Answer1Enabled
        {
            get { return this._answer1Enabled; }
            set
            {
                this._answer1Enabled = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer1Enabled"));
            }
        }

        private string _answer2;
        public string Answer2
        {
            get { return this._answer2; }
            set
            {
                this._answer2 = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer2"));
            }
        }

        private bool _answer2Enabled;
        public bool Answer2Enabled
        {
            get { return this._answer2Enabled; }
            set
            {
                this._answer2Enabled = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer2Enabled"));
            }
        }

        private string _answer3;
        public string Answer3
        {
            get { return this._answer3; }
            set
            {
                this._answer3 = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer3"));
            }
        }

        private bool _answer3Enabled;
        public bool Answer3Enabled
        {
            get { return this._answer3Enabled; }
            set
            {
                this._answer3Enabled = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer3Enabled"));
            }
        }

        private string _answer4;
        public string Answer4
        {
            get { return this._answer4; }
            set
            {
                this._answer4 = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer4"));
            }
        }

        private bool _answer4Enabled;
        public bool Answer4Enabled
        {
            get { return this._answer4Enabled; }
            set
            {
                this._answer4Enabled = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer4Enabled"));
            }
        }
        private string _answer5;
        public string Answer5
        {
            get { return this._answer5; }
            set
            {
                this._answer5 = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer5"));
            }
        }

        private bool _answer5Enabled;
        public bool Answer5Enabled
        {
            get { return this._answer5Enabled; }
            set
            {
                this._answer5Enabled = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer5Enabled"));
            }
        }

        private string _answer6;
        public string Answer6
        {
            get { return this._answer6; }
            set
            {
                this._answer6 = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer6"));
            }
        }

        private bool _answer6Enabled;
        public bool Answer6Enabled
        {
            get { return this._answer6Enabled; }
            set
            {
                this._answer6Enabled = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Answer6Enabled"));
            }
        }





        private List<XamarinQuiz> _questionList;

        List<XamarinQuiz> QuestionList
        {
            get { return this._questionList; }
            set
            {
                this._questionList = value;
                PropertyChanged(this, new PropertyChangedEventArgs("QuestionList"));
            }
        }

        Random rnd = new Random();

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isLoading;
        public bool IsLoading
        {
            get { return this._isLoading; }
            set
            {
                this._isLoading = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("IsLoading"));
            }
        }

        private string _message;
        public string Message
        {
            get
            {
                return this._message;
            }
            set
            {
                this._message = value;
                PropertyChanged(this,
                    new PropertyChangedEventArgs("Message"));
            }
        }

        public TwoQuestionViewModel()
        {
            LoadQuestions();
        }

        public bool CheckIfCorrect(int correct)
        {
            if (CorrectAnswer == correct)
            {
                Message = "Correct answer!";

                return true;
            }
            Message = "False answer!";
            return false;
        }

        public async Task LoadQuestions()
        {
            IsLoading = true;

            MobileServiceClient client = Settings1.MobileService;

            IMobileServiceTable<XamarinQuiz> xamarinQuizTable = client.GetTable<XamarinQuiz>();

            try
            {
                QuestionList = await xamarinQuizTable.ToListAsync();
            }
            catch (Exception)
            {
            }


            IsLoading = false;
            ChooseNewQuestion();
        }

        public void ChooseNewQuestion()
        {
            IsLoading = true;

            int questionNumber = rnd.Next(0, QuestionList.Count);
           
            XamarinQuiz selectedItem = QuestionList[questionNumber];

            Answer1Enabled = true;
            Answer2Enabled = true;
            Answer3Enabled = true;
            Answer4Enabled = true;
            Answer5Enabled = true;
            Answer6Enabled = true;

            Question = selectedItem.Question;
            Answer1 = selectedItem.Answer1;
            Answer2 = selectedItem.Answer2;
            Answer3 = selectedItem.Answer3;
            Answer4 = selectedItem.Answer4;
            Answer5 = selectedItem.Answer5;
            Answer6 = selectedItem.Answer6;

            CorrectAnswer = selectedItem.CorrectAnswer;

            IsLoading = false;
        }
    }
    }


