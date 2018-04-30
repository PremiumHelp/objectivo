using System;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using ObjectivoF.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;

namespace ObjectivoF.ViewModel
{
    public class ViewModelTranslate : ViewModelBase
    {
        public List<PickerChoice> LanguageList { get; set; }

        public ICommand OnTranslateButtonClickedCommand { get; set; }
        TextTranslationService textTranslationService;

        private string translated;

      
        public string Translated {
            get => translated;
            set => SetProperty(ref translated,value);
             }
        private string toBeTranslated;
        public string ToBeTranslated
        {
            get => toBeTranslated;
            set => SetProperty(ref toBeTranslated, value);
        }

        public  ViewModelTranslate()
        { 
            textTranslationService = new TextTranslationService(new AuthenticationService(Constants.TextTranslatorApiKey));
            OnTranslateButtonClickedCommand = new Command(Translate);
            LanguageList = GetLanguage().OrderBy(t => t.Value).ToList();
           
          
        }

        private async void  Translate()
       {

                if (!string.IsNullOrWhiteSpace(toBeTranslated))
                {
                    Translated = await textTranslationService.TranslateTextAsync(toBeTranslated);
              

                }


       }
        public List<PickerChoice> GetLanguage()
        {
            var languages = new List<PickerChoice>()
            {
                new PickerChoice(){Shortcut=  "de", Value= "German"},
                new PickerChoice(){Shortcut =  "en", Value= "English"},
                new PickerChoice(){Shortcut =  "zh-Hant", Value= "Chinese"},
                new PickerChoice(){Shortcut =  "ar", Value= "Arabic"},
                new PickerChoice(){Shortcut =  "af", Value= "African"},
                new PickerChoice(){Shortcut =  "bs", Value= "Bosnian"},
                new PickerChoice(){Shortcut =  "hu", Value= "Hungarian"}
              
            };

            return languages;
        }

      
        private PickerChoice _pickerChoiceFrom { get; set; }
       
        public PickerChoice PickerChoiceFrom
        {
            get { return _pickerChoiceFrom; }
            set
            {
                if (_pickerChoiceFrom != value)
                {
                    _pickerChoiceFrom = value;
                  
                    textTranslationService.From = _pickerChoiceFrom.Shortcut;
               
                }
            }
        }
        private PickerChoice _pickerChoiceTo { get; set; }
        public PickerChoice PickerChoiceTo
        {
            get { return _pickerChoiceTo; }
            set
            {
                if (_pickerChoiceTo != value)
                {
                    _pickerChoiceTo = value;
                   
                    textTranslationService.To = _pickerChoiceTo.Shortcut;

                }
            }
        }
       
           
    }
    public class PickerChoice
    {
     
        public string Value { get; set; }
        public string Shortcut { get; set;}
    }
}
