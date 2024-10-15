using Eventos.Platinum.Library.Models;

namespace Eventos.Platinum.Library.BusinessServices
{
    public interface ISalaService
    {
        Task<List<Sala>> GetSalas();
    }
}