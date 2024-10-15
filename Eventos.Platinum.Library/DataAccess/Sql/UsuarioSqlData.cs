using Eventos.Platinum.Library.DataServices;

namespace Eventos.Platinum.Library.DataAccess.Sql
{
    public class UsuarioSqlData : IUsuarioData
    {
        private readonly IDataAccess _dataAccess;

        public UsuarioSqlData(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public async Task<int> CreateAsync(Usuario model)
        {
            var res = await _dataAccess.SaveDataAsync(SqlQueries.UsuarioInsertSPName, new { UsuarioId = (int?)null, model.NombreUsuario, Password = model.PasswordHash, model.Salt, model.Activo, model.FechaUltimoIngreso, model.UsuarioTipoId });
            return (int)res;
        }

        //public async Task DeleteAsync(int id)
        //{
        //    await _dataAccess.SaveDataAsync(SqlQueries.DeleteUsuarioSPName, new { UsuarioId = id });
        //}

        public async Task<List<Usuario>> GetAllAsync()
        {

            return (await _dataAccess.LoadDataAsync<Usuario, dynamic>(SqlQueries.UsuarioGetSPName, new { })).ToList();
        }

        //public async Task<UsuarioModel> GetByIdAsync(int id)
        //{
        //    return (await _dataAccess.LoadDataAsync<UsuarioModel, dynamic>(SqlQueries.GetUsuarioSPName, new { UsuarioId = id })).FirstOrDefault();
        //}

        //public async Task UpdateAsync(UsuarioModel model)
        //{
        //    await _dataAccess.SaveDataAsync(SqlQueries.UpdateUsuarioSmarterSPName, new { model.UsuarioId, SmarterId = (model.SmarterId == 0 ? null : model.SmarterId), model.UsuarioTipoId });
        //}

        //public async Task UpdatePasswordAsync(UsuarioModel model)
        //{
        //    await _dataAccess.SaveDataAsync(SqlQueries.UpdateUsuarioPasswordSPName, new { model.UsuarioId, Password = model.PasswordHash, model.Salt });
        //}
    }
}
