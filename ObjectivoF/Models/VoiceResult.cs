using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ObjectivoF.Models
{
    [JsonObject("result")]
    public class VoiceResult
    {
        public string RecognitionStatus { get; set; }
        public string DisplayText { get; set; }
        public string Offset { get; set; }
        public string Duration { get; set; }
    }
}

