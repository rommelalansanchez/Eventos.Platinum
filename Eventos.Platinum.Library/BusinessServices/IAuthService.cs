using Eventos.Platinum.Library.Models;

namespace Eventos.Platinum.Library.BusinessServices
{
    public interface IAuthService
    {
        Task<string> Login(Login model, string configurationToken);
    }
}