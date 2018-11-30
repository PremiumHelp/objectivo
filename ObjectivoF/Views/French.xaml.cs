using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Reflection;
using System.IO;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using ObjectivoF.Data;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;

namespace ObjectivoF
{
    public partial class French : ContentPage
    {
        public French()
        {
        
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("ObjectivoF.FrenchPhraseBook.xml");

            List<Phrases> phrases;
            using (var reader = new StreamReader(stream))
            {
                var serializer = new XmlSerializer(typeof(List<Phrases>));
                phrases = (List<Phrases>)serializer.Deserialize(reader);
            }
        
            var listView = new ListView();
          
            listView.ItemTemplate = new DataTemplate(() =>
            {
                var textCell = new TextCell();
                textCell.SetBinding(TextCell.TextProperty, "Name");

                return textCell;
            });
            listView.ItemsSource = phrases;
            var image = new Image { Source = "france.jpg" };

            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    new Image { Source="france.jpg"
                    },
                 listView
                }
            };

           
        }
    }
}






