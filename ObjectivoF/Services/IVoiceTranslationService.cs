using System;
using System.Threading.Tasks;
using ObjectivoF.Models;

namespace ObjectivoF.Services
{
    public interface IVoiceTranslationService
    {
        Task<VoiceResult> RecognizeSpeechAsync(string filename);
    }
}
