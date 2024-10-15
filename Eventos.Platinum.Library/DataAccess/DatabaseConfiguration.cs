
using Microsoft.Extensions.Configuration;

namespace Eventos.Platinum.Library.DataAccess
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        private const string connectionStringName = "EventAppDBConnectionString";

        public DatabaseConfiguration(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString(connectionStringName) ?? "";
        }
        public string ConnectionString { get; }
    }
}
