using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using ObjectivoF.Data;
using ObjectivoF.Models;
using Xamarin.Forms;

namespace ObjectivoF.TabbedPages
{
	public partial class Favorites : ContentPage
	{
		private const string path = "/vocab/";
		//public ObservableCollection<Phrases> vocabPhrases { get; set; }
        
         
 		private List<Vocab> vocabs = new List<Vocab>();
		
        public Favorites()
        {
            InitializeComponent();
			//vocabPhrases = new ObservableCollection<Phrases>();
			//Task.Run(async () => { await getVocabs(); });
			BindingContext = new ViewModelVocab();
           
           
        }
	

		private async Task getVocabs()         {            try                 {
                 				var response = await HttpService.GetAllVocab(Constants.uri + path +App.UserId);                     if (response.StatusCode == HttpStatusCode.BadRequest)                     {                         System.Diagnostics.Debug.WriteLine("Bad reponse from the backend");                                              }                     else if (response.StatusCode == HttpStatusCode.OK)                     {                         var data = await response.Content.ReadAsStringAsync();                         var results = JObject.Parse(data);                          					vocabs = JObject.Parse(data)["vocabs"].ToObject<List<Vocab>>();
					//createUI();                     }                     else                     {                                             }                 }                 catch (Exception ex)                 {                     System.Diagnostics.Debug.WriteLine(ex.Message);                 }             }
		//private void createUI() {
			//GetAllPhrases();

			//var listView = new ListView();
			//listView.ItemsSource = vocabPhrases;
     //       var image = new Image { Source = "voc.png" };

     //       Content = new StackLayout
     //       {
     //           Padding = new Thickness(0, 20, 0, 0),
     //           VerticalOptions = LayoutOptions.StartAndExpand,
     //           Children = {
     //               new Image { Source="voc.png"
     //               },
					//new Button { Text="Delete All"
						
					//},
            //     listView
            //    }
            //};
            
		//private void GetAllPhrases()
        //{
        //    foreach (var vocab in vocabs)
        //    {
        //        Phrases newPhrase = new Phrases();
        //        newPhrase.Name = vocab.Original + "        " + vocab.Translated;
        //        vocabPhrases.Add(newPhrase);

        //    }
        //}

		}  
   }

