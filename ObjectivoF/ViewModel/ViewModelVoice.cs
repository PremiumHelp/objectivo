using System;
using System.Diagnostics;
using System.Windows.Input;
using ObjectivoF.Services;
using Xamarin.Forms;

namespace ObjectivoF.ViewModel
{
    public class ViewModelVoice: ViewModelBase
    {
        private string image="record.png";
        public string Image{
            get => image ;
            set => SetProperty(ref image, value);
        }

        private string original;
        public string Original{
            get => original;
            set => SetProperty(ref original, value);
        }

        private string translated;
        public string Translated{
            get => translated;
            set => SetProperty(ref translated, value);
        }

        IVoiceTranslationService voiceTranslationService;
        public ICommand OnRecognizeButton { get; set; }
        TextTranslationService textTranslationService;

        bool isRecording = false;

        public ViewModelVoice()
        {
            voiceTranslationService = new VoiceTranslationService(new AuthenticationService(Constants.BingSpeechApiKey), Device.RuntimePlatform);
            textTranslationService = new TextTranslationService(new AuthenticationService(Constants.TextTranslatorApiKey));
            OnRecognizeButton = new Command(OnRecognizeSpeechButtonClicked);

        }

      private  async void OnRecognizeSpeechButtonClicked()
        {
                var audioRecordingService = DependencyService.Get<IAudioRecorderService>();
                if (!isRecording)
                {
                    audioRecordingService.StartRecording();

                Image = "recording.png" ;
                }
                else
                {
                    audioRecordingService.StopRecording();
                }

                isRecording = !isRecording;
                if (!isRecording)
                {
                    Image = "record.png";
                    var speechResult = await voiceTranslationService.RecognizeSpeechAsync(Constants.AudioFilename);
                    Debug.WriteLine("Name: " + speechResult.DisplayText);
                    Debug.WriteLine("Recognition Status: " + speechResult.RecognitionStatus);
                Original = speechResult.DisplayText;

                if (!string.IsNullOrWhiteSpace(original))
                    {
                   
                    Translated = await textTranslationService.TranslateTextAsync(original);

                    }
                }
         
        }
    }
}
