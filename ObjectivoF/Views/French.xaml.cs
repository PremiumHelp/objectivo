using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using ObjectivoF.Data;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;

namespace ObjectivoF
{
    public partial class French : ContentPage
    {
        ObservableCollection<PhrasebookElement> phraseBookList = new ObservableCollection<PhrasebookElement>();

        public French()
        {
            InitializeComponent();

        }
        private async void LoadXMLData()
        {
            List<PhrasebookElement> rawData = null;
            await Task.Factory.StartNew(delegate {
                
                XDocument doc = XDocument.Load("Data/FrenchPhraseBook.xml");
                IEnumerable<PhrasebookElement> phraseBookElements = from s in doc.Descendants("PhraseBookElement")
                                       select new PhrasebookElement
                                          {
                    Original = s.Attribute("Original").Value,
                    Translated = s.Attribute("Translated").Value,
                                             
                                          };
                rawData = phraseBookElements.ToList();
            });
            lst.ItemsSource = rawData;
        }
       

}
}

