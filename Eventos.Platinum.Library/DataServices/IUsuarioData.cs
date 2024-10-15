namespace Eventos.Platinum.Library.DataServices
{
    public interface IUsuarioData
    {
        //Task<Usuario> GetByIdAsync(int smarterId);
        Task<List<Usuario>> GetAllAsync();
        Task<int> CreateAsync(Usuario smarterModel);
        //Task UpdateAsync(Usuario smarterModel);
        //Task DeleteAsync(int id);
        //Task UpdatePasswordAsync(Usuario model);
    }
}
