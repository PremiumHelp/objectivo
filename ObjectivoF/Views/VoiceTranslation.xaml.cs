using System;
using System.Collections.Generic;
using ObjectivoF.ViewModel;

using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class VoiceTranslation : ContentPage
    {
        public VoiceTranslation()
        {
            InitializeComponent();
            BindingContext = new ViewModelVoice();

        }
    }
}
