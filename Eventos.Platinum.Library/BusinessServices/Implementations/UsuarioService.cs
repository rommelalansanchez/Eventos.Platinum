using Eventos.Platinum.Shared.Models;
using Eventos.Platinum.Library.DataServices;

namespace Eventos.Platinum.Library.BusinessServices.Implementations
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioData _usuarioData;

        public UsuarioService(IUsuarioData usuarioData) => _usuarioData = usuarioData;

        public async Task<IEnumerable<Usuario>> GetAllAsync()
        {
            var usuarios = (await _usuarioData.GetAllAsync()).OrderBy(x => x.NombreUsuario);

            return usuarios;
        }

        //public async Task<Usuario> GetByIdAsync(int usuarioId)
        //{
        //    var usuario = await _usuarioData.GetByIdAsync(usuarioId);
        //    return usuario;
        //}

        public async Task SaveAsync(Usuario model)
        {
            if (model.UsuarioId != 0)
            {
                //await _usuarioData.UpdateAsync(model);
            }
            else
            {
                var usuarios = await _usuarioData.GetAllAsync();

                if (usuarios.Any(x => string.Equals(x.NombreUsuario, model.NombreUsuario, StringComparison.InvariantCultureIgnoreCase)))
                {
                    throw new CustomException($"Ya existe un usuario con nombre \"{model.NombreUsuario}\".");
                }
                Helpers.CrearPassword(model.Password, out byte[] passwordHash, out byte[] salt);
                model.PasswordHash = passwordHash;
                model.Salt = salt;
                await _usuarioData.CreateAsync(model);
            }
        }

        //public async Task CambiarPasswordAsync(Usuario model)
        //{
        //    var usuario = await _usuarioData.GetByIdAsync(model.UsuarioId);
        //    if (usuario == null)
        //    {
        //        throw new CustomException("Usuario no existe.");
        //    }

        //    if (!AuthService.PasswordCorrecta(model.Password, usuario.PasswordHash, usuario.Salt))
        //    {
        //        throw new CustomException("Contraseña actual incorrecta.");
        //    }


        //    Helpers.CrearPassword(model.NuevoPassword, out byte[] passwordHash, out byte[] salt);
        //    model.PasswordHash = passwordHash;
        //    model.Salt = salt;
        //    await _usuarioData.UpdatePasswordAsync(model);
        //}

        //public async Task DeleteAsync(int id)
        //{
        //    await _usuarioData.DeleteAsync(id);
        //}
    }
}
