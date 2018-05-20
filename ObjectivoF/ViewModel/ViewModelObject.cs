using System;
using System.Collections.Generic;
using ObjectivoF.Services;
using Xamarin.Forms;
using ObjectivoF.ViewModel;
using Microsoft.ProjectOxford.Vision;
using Microsoft.ProjectOxford.Vision.Contract;
using Plugin.Connectivity;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.IO;
using System.Threading.Tasks;
using ObjectivoF;
using System.Windows.Input;

namespace ObjectivoF.ViewModel
{
    public class ViewModelObject: ViewModelBase
    {
        public ICommand TakePictureButtonClicked { get; set; }
        public ICommand UploadPictureButtonClicked { get; set; }

        private readonly VisionServiceClient visionClient;
       
        private ImageSource image1;

        public ImageSource Image1{
            get => image1;
            set => SetProperty(ref image1, value);
        }

       

        private string translatedDescription;

        public string TranslatedDescription{ 
            get => translatedDescription;
            set => SetProperty(ref translatedDescription,value );
        
        }

        private string description;

        public string Description{

            get => description;
            set => SetProperty(ref description, value);
        }


        TextTranslationService textTranslationService;



        public ViewModelObject()
        {
            this.visionClient =
                    new VisionServiceClient("8f832eedec7846e9870d5c5e7401480c", "https://westeurope.api.cognitive.microsoft.com/vision/v1.0");

            textTranslationService = new TextTranslationService(new AuthenticationService(Constants.TextTranslatorApiKey));
            TakePictureButtonClicked = new Command(TakePicture);
            UploadPictureButtonClicked = new Command(UploadPicture);



        }

        private async void TakePicture(){
           
            await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
              
                return;
            }

            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                SaveToAlbum = true,
                Name = "test.jpg"
            });

            if (file == null)
                return;
            


            Image1 = ImageSource.FromStream(() => file.GetStream());
            await AnalyzePictureAsync(file.GetStream());

        }
        private async void UploadPicture(){
           
            if (!CrossMedia.Current.IsPickPhotoSupported)
            {
                return;
            }

            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;

           
            Image1 = ImageSource.FromStream(() => file.GetStream());

            await AnalyzePictureAsync(file.GetStream());
           
           
        }
        private async Task<AnalysisResult> AnalyzePictureAsync(Stream inputFile)
        {
           

            VisualFeature[] visualFeatures = new VisualFeature[] {
                VisualFeature.Description
                 };


            AnalysisResult analysisResult = await visionClient.AnalyzeImageAsync(inputFile,visualFeatures);

            Description = analysisResult.Description.Captions[0].Text;
           
            if (!string.IsNullOrWhiteSpace(description))
            {
                TranslatedDescription = await textTranslationService.TranslateTextAsync(description);


            }

            return analysisResult;
        }

     
    }
}
