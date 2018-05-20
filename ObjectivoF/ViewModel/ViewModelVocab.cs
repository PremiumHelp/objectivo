using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Input;
using Newtonsoft.Json.Linq;
using ObjectivoF.Data;
using ObjectivoF.Models;
using Xamarin.Forms;
using ObjectivoF.ViewModel;

namespace ObjectivoF
{
	public class ViewModelVocab : ViewModelBase
    {
		
		public static ObservableCollection<vocabElement> vocabs{ get; set; }
	
      
        
        public ViewModelVocab()
        {
			vocabs = new ObservableCollection<vocabElement>() {
				new vocabElement("Flower", "Likes"),
				new vocabElement( "Bla ", ".."),
                
            };
		
        }

	


    }
}
