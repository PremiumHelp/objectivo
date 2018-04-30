using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Text;

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
            /* ask the teacher   */
            user.Email = email;
            user.Password = password;
            string json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri);
            request.Method = HttpMethod.Post;
            request.Content = content;
            //TODO don't crash if there is an error
             return await httpClient.SendAsync(request);
        }
      
        public static async Task<HttpResponseMessage> SignUp(string uri,User newUser)
        {          
            string json = JsonConvert.SerializeObject(newUser);
            var content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage();
            request.RequestUri = new Uri(uri);
            request.Method = HttpMethod.Post;
            request.Content = content;
            System.Diagnostics.Debug.WriteLine(content);

            //TODO don't crahs if there is an error
            return await httpClient.SendAsync(request);
        }
    }
}