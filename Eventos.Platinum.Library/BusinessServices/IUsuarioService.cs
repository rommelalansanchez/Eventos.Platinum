namespace Eventos.Platinum.Library.BusinessServices
{
    public interface IUsuarioService
    {
        //Task DeleteAsync(int id);
        Task<IEnumerable<Usuario>> GetAllAsync();
        //Task<Usuario> GetByIdAsync(int usuarioId);
        Task SaveAsync(Usuario model);
        //Task CambiarPasswordAsync(Usuario model);
    }
}