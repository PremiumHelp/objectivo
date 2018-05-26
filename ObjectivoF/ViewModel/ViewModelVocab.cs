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
        public static ObservableCollection<vocabElement> allFav { get; set; }
        private List<vocabElement> vocabsdb = new List<vocabElement>();

        public ICommand DeleteCommand { get; set; }

        private ObservableCollection<vocabElement> _vocabs;

        public ObservableCollection<vocabElement> vocabs
        {
            get => _vocabs;
            set => SetProperty(ref _vocabs, value);
        }

        public ViewModelVocab()
        {
            DeleteCommand = new Command(DeleteAll);
            Task.Run(async () => { await getVocabs(); }).ContinueWith((arg) => {

                allFav = new ObservableCollection<vocabElement>(vocabsdb);
                vocabs = allFav;
            });

        }
        private async void DeleteAll()
        {

            var response = await HttpService.DeleteAllVocabs(Constants.uri + path + "deleteAll/" + App.UserId);
            allFav.Clear();
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

                    vocabsdb = JObject.Parse(data)["vocabs"].ToObject<List<vocabElement>>();

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

    }
}