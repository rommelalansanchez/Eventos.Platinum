
namespace Eventos.Platinum.Library.DataServices
{
    public interface ISalaData
    {
        Task CreateAsync(Sala model);
        Task<List<Sala>> GetAllAsync();
        Task<Sala> GetByIdAsync(int id);
        Task UpdateAsync(Sala model);
    }
}