using Eventos.Platinum.Library.DataServices;
using Eventos.Platinum.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventos.Platinum.Library.BusinessServices
{
    public class SalaService : ISalaService
    {
        private readonly ISalaData _salaData;

        public SalaService(ISalaData salaData)
        {
            _salaData = salaData;
        }

        public async Task<List<Sala>> GetSalas()
        {
            return await _salaData.GetAllAsync();
        }
    }
}
