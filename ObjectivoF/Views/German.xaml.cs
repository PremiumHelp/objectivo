using System;
using System.Collections.Generic;
using System.Reflection;
using System.IO;
using ObjectivoF.Data;
using System.Xml.Serialization;

using Xamarin.Forms;

namespace ObjectivoF
{
    public partial class German : ContentPage
    {
        public German()
        {
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(LoadResourceText)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("ObjectivoF.Data.GermanPhraseBook.xml");
            List<Phrases> phrases;
            using (var reader = new System.IO.StreamReader(stream))
            {
                var serializer = new XmlSerializer(typeof(List<Phrases>));
                phrases = (List<Phrases>)serializer.Deserialize(reader);
            }
            var listView = new ListView();
            listView.ItemsSource = phrases;
            var image = new Image { Source = "german.jpg" };

            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                VerticalOptions = LayoutOptions.StartAndExpand,
                Children = {
                    new Image { Source="german.jpg"
                    },
                 listView
                }
            };

        }
    }
}
