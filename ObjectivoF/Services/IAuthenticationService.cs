using System;
using System.Threading.Tasks;

namespace ObjectivoF.Services
{
    public interface IAuthenticationService
    {
        Task InitializeAsync();
        string GetAccessToken();
    }
}
