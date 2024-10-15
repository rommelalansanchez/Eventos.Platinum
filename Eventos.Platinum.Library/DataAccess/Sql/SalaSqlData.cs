using Eventos.Platinum.Library.DataServices;

namespace Eventos.Platinum.Library.DataAccess.Sql
{
    public class SalaSqlData : ISalaData
    {
        private readonly IDataAccess _sqlDataAccess;

        public SalaSqlData(IDataAccess sqlDataAccess)
        {
            _sqlDataAccess = sqlDataAccess;
        }

        public async Task CreateAsync(Sala model)
        {
            await _sqlDataAccess.SaveDataAsync("", model);
        }
        public async Task UpdateAsync(Sala model)
        {
            await _sqlDataAccess.SaveDataAsync(SqlQueries.SalaGetSPName, model);
        }

        public async Task<List<Sala>> GetAllAsync()
        {
            return (await _sqlDataAccess.LoadDataAsync<Sala, dynamic>(SqlQueries.SalaGetSPName, new { })).ToList();
        }

        public async Task<Sala> GetByIdAsync(int id)
        {
            return (await _sqlDataAccess.LoadDataAsync<Sala, dynamic>(SqlQueries.SalaGetSPName, new { MembresiaId = id })).FirstOrDefault();
        }
    }
}
