using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Xml.Linq;
using ObjectivoF;
using ObjectivoF.Services;

namespace ObjectivoF.Services
{
    public class TextTranslationService 
    {
        IAuthenticationService authenticationService;
        HttpClient httpClient;
        private string from;
        private string to;

        public string From
        {
            get { return from; }
            set { from = value; }
        }
        public string To
        {
            get { return to; }
            set { to = value; }
        }

       /// <summary>
       /// Initializes a new instance of the <see cref="T:ObjectivoF.Services.TextTranslationService"/> class.
       /// </summary>
       /// <param name="authService">Auth service.</param>

        public TextTranslationService(IAuthenticationService authService)
        {
            authenticationService = authService;
            from = "en";
            to = "de";

        }

        /// <summary>
        /// Translates the text async.
        /// </summary>
        /// <returns>The text async.</returns>
        /// <param name="text">Text.</param>
        public async Task<string> TranslateTextAsync(string text)
        {
            if (string.IsNullOrWhiteSpace(authenticationService.GetAccessToken()))
            {
                await authenticationService.InitializeAsync();
            }

            string requestUri = GenerateRequestUri(Constants.TextTranslatorEndpoint, text, from, to);
            string accessToken = authenticationService.GetAccessToken();
            var response = await SendRequestAsync(requestUri, accessToken);
            var xml = XDocument.Parse(response);
            return xml.Root.Value;
        }

        /// <summary>
        /// Generates the request URI.
        /// </summary>
        /// <returns>The request URI.</returns>
        /// <param name="endpoint">Endpoint.</param>
        /// <param name="text">Text.</param>
        /// <param name="from">From.</param>
        /// <param name="to">To.</param>
        string GenerateRequestUri(string endpoint, string text, string from, string to)
        {
            string requestUri = endpoint;
            requestUri += string.Format("?text={0}", Uri.EscapeUriString(text));
            requestUri += string.Format("&from={0}", from);
            requestUri += string.Format("&to={0}", to);
            return requestUri;
        }
        // This is the method for building the Get Request 
        // It goes to the translation Api and we get the language from-to the other language 
        /// <summary>
        /// Sends the request async.
        /// </summary>
        /// <returns>The request async.</returns>
        /// <param name="url">URL.</param>
        /// <param name="bearerToken">Bearer token.</param>
        async Task<string> SendRequestAsync(string url, string bearerToken)
        {
            if (httpClient == null)
            {
                httpClient = new HttpClient();
            }
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

            var response = await httpClient.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
