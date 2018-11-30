using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;
using ObjectivoF.Models;

namespace ObjectivoF
{
    public class HttpService
    {
        static HttpClient httpClient = new HttpClient();
        public HttpService()
        {

        }



        public static async Task<HttpResponseMessage> Login(string uri, string email, string password)
        {
            User user = new User();
            user.Email = email;
            user.Password = password;
            string json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri);
            request.Method = HttpMethod.Post;
            request.Content = content;
            return await httpClient.SendAsync(request);
        }



        public static async Task<HttpResponseMessage> SignUp(string uri, User newUser)
        {
            string json = JsonConvert.SerializeObject(newUser);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri);
            request.Method = HttpMethod.Post;
            request.Content = content;
            System.Diagnostics.Debug.WriteLine(content);


            return await httpClient.SendAsync(request);
        }

        public static async Task<HttpResponseMessage> SaveVocab(string uri, Vocab newVocab)
        {
            string json = JsonConvert.SerializeObject(newVocab);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri);
            request.Method = HttpMethod.Post;
            request.Content = content;
            System.Diagnostics.Debug.WriteLine(content);

            return await httpClient.SendAsync(request);
        }
        public static async Task<HttpResponseMessage> GetAllVocab(string uri)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri);
            request.Method = HttpMethod.Get;
            var response = await httpClient.SendAsync(request);
            return response;
        }
        public static async Task<HttpResponseMessage> DeleteAllVocabs(string uri)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri);
            request.Method = HttpMethod.Delete;
            return await httpClient.SendAsync(request);
        }
        public static async Task<HttpResponseMessage> CreateGame(string uri, Game newGame)
        {
            string json = JsonConvert.SerializeObject(newGame);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri);
            request.Method = HttpMethod.Post;
            request.Content = content;
            return await httpClient.SendAsync(request);
        }

        public static async Task<HttpResponseMessage> GetResults(string uri)
        {
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri);
            request.Method = HttpMethod.Get;
            var response = await httpClient.SendAsync(request);
            return response;
        }

        public static async Task<HttpResponseMessage> ChangeResults(string uri,Game game)
        {
            string json = JsonConvert.SerializeObject(game);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri);
            request.Method = HttpMethod.Put;
            return await httpClient.SendAsync(request);
        }
    }
}