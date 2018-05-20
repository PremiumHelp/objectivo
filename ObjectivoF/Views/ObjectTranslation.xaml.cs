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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectivoF
{
    public partial class ObjectTranslation : ContentPage
    {
      public ObjectTranslation()
        {
            InitializeComponent();
            BindingContext = new ViewModelObject();
          

        }



    
    }
}
