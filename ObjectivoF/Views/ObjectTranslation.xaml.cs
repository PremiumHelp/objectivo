using System;
using System.Collections.Generic;
using ObjectivoF.Services;
using Xamarin.Forms;
using ObjectivoF.ViewModel;
namespace ObjectivoF
{
    public partial class ObjectTranslation : ContentPage
    {
       // ObjectRecognitionService objectRecognition;
        
        public ObjectTranslation()
        {
            InitializeComponent();
            BindingContext = new ViewModelObjectRecognition();
        }
    }
}
