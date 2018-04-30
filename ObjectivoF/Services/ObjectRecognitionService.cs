using Xamarin.Forms;
using Plugin.Media;
using System.Net.Http;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace ObjectivoF.Services
{
    public class ObjectRecognitionService
    {



        public ObjectRecognitionService() {}

        public async Task<string> Request(Stream stream)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress =new Uri(Constants.ObjectRecognitionEndpoint);
                    client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", Constants.ObjectRecognitionApi);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/octet-stream"));

                    HttpContent content = new StreamContent(stream);
                    content.Headers.ContentType = new MediaTypeWithQualityHeaderValue("application/octet-stream");

                    var response = await client.PostAsync(Constants.ObjectRecognitionEndpoint, content);
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                return "Task failed.\nDetails: " + ex.Message;
            }
            }
      


    }

}
