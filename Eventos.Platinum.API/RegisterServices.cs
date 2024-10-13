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

            //builder.Services.AddSingleton<IDatabaseConfiguration, DatabaseConfiguration>();
            //builder.Services.AddSingleton<IDataAccess, SqlDataAccess>();
            //builder.Services.AddSingleton<IEmailSender, EmailSender>();
            //builder.Services.AddSingleton<IEncryptorService, EncryptorService>();
            

            
        }
    }
}
