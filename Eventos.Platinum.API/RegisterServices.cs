using Eventos.Platinum.Library.BusinessServices;
using Eventos.Platinum.Library.BusinessServices.Implementations;
using Eventos.Platinum.Library.DataAccess;
using Eventos.Platinum.Library.DataAccess.Sql;
using Eventos.Platinum.Library.DataServices;
using Eventos.Platinum.Library.HelperServices;

namespace Eventos.Platinum.API
{
    public static class RegisterServices
    {
        public static void ConfigureServices(this WebApplicationBuilder builder)
        {
            // Add services to the container.
            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            //builder.Services.AddSingleton<IApplicationContextAccessor, ApplicationHttpContextAccessor>();
            //builder.Services.AddSingleton<ICacheService, CacheService>();

            builder.Services.AddSingleton<IDatabaseConfiguration, DatabaseConfiguration>();
            builder.Services.AddSingleton<IDataAccess, SqlDataAccess>();
            //builder.Services.AddSingleton<IEmailSender, EmailSender>();
            builder.Services.AddSingleton<IEncryptorService, EncryptorService>();

            builder.Services.AddScoped<ISalaData, SalaSqlData>();
            builder.Services.AddScoped<IUsuarioData, UsuarioSqlData>();

            builder.Services.AddScoped<ISalaService, SalaService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IAuthService, AuthService>();


        }
    }
}
