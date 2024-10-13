
using Microsoft.Extensions.Configuration;

namespace Eventos.Platinum.Library
{
    public class DatabaseConfiguration : IDatabaseConfiguration
    {
        private const string connectionStringName = "SmartAppDBConnectionString";

        public DatabaseConfiguration(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString(connectionStringName) ?? "";
        }
        public string ConnectionString { get; }
    }
}
