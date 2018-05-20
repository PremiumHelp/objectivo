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
		private const string path = "/vocab/";
		public  ObservableCollection<vocabElement> vocabs{ get; set; }
         public static ObservableCollection<vocabElement> allFav { get; set; }
		private List<Vocab> vocabsdb = new List<Vocab>();


        public ViewModelVocab()
        {
			allFav = new ObservableCollection<vocabElement>();
			//vocabs = allFav;
			Task.Run(async () => { await getVocabs(); });
        }
	
		private async Task getVocabs()
        {
            try
            {
                var response = await HttpService.GetAllVocab(Constants.uri + path + App.UserId);
                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    System.Diagnostics.Debug.WriteLine("Bad reponse from the backend");

                }
                else if (response.StatusCode == HttpStatusCode.OK)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var results = JObject.Parse(data);

					vocabsdb = JObject.Parse(data)["vocabs"].ToObject<List<Vocab>>();
					GetAllPhrases();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }

		private void GetAllPhrases()
        {

            foreach (var vocab in vocabsdb)
            {
				if (vocabs != null)
				{
					vocabElement newPhrase = new vocabElement();
					newPhrase.original = vocab.Original;
					newPhrase.translated = vocab.Translated;
					allFav.Add(newPhrase);
				}
            }
			//vocabs = allFav;
			string a = "Sihana";
        }

    }
}
