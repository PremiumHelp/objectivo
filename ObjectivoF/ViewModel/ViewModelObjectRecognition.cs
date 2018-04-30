using System;
using Xamarin.Forms;
using ObjectivoF.Models;
using Newtonsoft.Json;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using ObjectivoF.Services;

namespace ObjectivoF.ViewModel
{
    public class ViewModelObjectRecognition : ViewModelBase
    {
        private ObjectRecognitionModel.MainResult model = new ObjectRecognitionModel.MainResult();
       

        private string metaData;
        private string captionText;
        private string tags;
        private string selectedPhoto;

        private bool isVisible;

      


        public bool IsVisible
        { get => isVisible;
            set => SetProperty(ref isVisible, value);
             

        }

        public string MetaData
        { get => metaData; 
            set => SetProperty(ref metaData,value);

            
        }

        public string CaptionText
        { get => captionText;
            set => SetProperty(ref captionText, value);
            } 

        public string Tags
        { get => tags;
            set => SetProperty(ref tags, value);
        }

        public string SelectedPhoto
        { get => selectedPhoto;
            set => SetProperty(ref selectedPhoto, value);
        }

        public ICommand TakePhoto
        {
            set; get; }

        public ICommand SelectPhoto
        {
            set; get; }

        public ViewModelObjectRecognition()
        {
            TakePhoto = new Command(OnTakePhoto);
            SelectPhoto = new Command(OnSelectPhoto);
        }

        private async void OnTakePhoto()
        {

            try
            {
                var media = CrossMedia.Current;
                if (!media.IsTakePhotoSupported)
                    await Application.Current.MainPage.DisplayAlert("Error", "Camera not available!", "OK");

                var img = await media.TakePhotoAsync(new StoreCameraMediaOptions());
                if (img != null)
                {

                    var manager = new ObjectRecognitionService();
                    var result = await manager.Request(img.GetStream());
                    model = JsonConvert.DeserializeObject<ObjectRecognitionModel.MainResult>(result);
                    IsVisible = true;
                    BindData();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Message: " + ex.Message, "OK");
            }
        }

        private async void OnSelectPhoto()
        {
          
            await CrossMedia.Current.Initialize();

            var media = CrossMedia.Current;
            try
            {
               
                MediaFile photo;

                if (!media.IsPickPhotoSupported)
                    await Application.Current.MainPage.DisplayAlert("Error", "File directory is not found!", "OK");

                photo = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "Invoices",
                    Name = "Invoice.jpg"
                });     


                if (photo != null)
                {
                    var manager = new ObjectRecognitionService();
                    var result = await manager.Request(photo.GetStream());
                    model = JsonConvert.DeserializeObject<ObjectRecognitionModel.MainResult>(result);

                    SelectedPhoto = photo.Path + " is selected.";
                    IsVisible = true;
                    BindData();
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Message: " + ex.Message, "OK");
            }
        }

        private void BindData()
        {
            if (model != null)
            {
                MetaData = "Meta\n";
                CaptionText = "Description\n";
                Tags = "Tags\n";

                MetaData = string.Format($"H: {model.metadata.height}\n" +
                                         $"W: {model.metadata.width}\n" +
                                         $"Format: {model.metadata.format}");

                for (int i = 0; i < model.description.captions.Length; i++)
                {
                    CaptionText += model.description.captions[i].text;
                    if (i != model.description.captions.Length)
                        CaptionText += ", ";
                }

                for (int i = 0; i < model.description.tags.Length; i++)
                {
                    Tags += model.description.tags[i];
                    if (i != model.description.tags.Length)
                        Tags += ", ";
                }
            }
        }

    }
}
