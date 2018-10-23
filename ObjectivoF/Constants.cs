using System;
namespace ObjectivoF
{
    public static class Constants
    {
		public static readonly string uri = "http://192.168.0.109:4200";

        public static readonly string AuthenticationTokenEndpoint = "https://api.cognitive.microsoft.com/sts/v1.0";

        public static  string BingSpeechApiKey = "35cc820387544657b948472b73b78e89";
        public static  string SpeechRecognitionEndpoint = "https://speech.platform.bing.com/speech/recognition/";
        public static  string AudioContentType = @"audio/wav; codec=""audio/pcm""; samplerate=16000";


        public static  string TextTranslatorApiKey = "6dfd5546bb9a4c67a9e93ce597ee188e";
        public static  string TextTranslatorEndpoint = "https://api.microsofttranslator.com/v2/http.svc/translate";
        public static  string AudioFilename = "ObjectivoF.wav";

        public static string TextAnalisesApiKey = "c3539dca52104da19d0af158cdd29142";
        public static string TextAnalisesEndpoint = "https://westeurope.api.cognitive.microsoft.com/text/analytics/v2.0";

     }
}
