using Api.Servfy.Base.Data.Configurations;
using Api.Servfy.Base.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Servfy.Base.Data.Modules
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ServfyBaseContext>(options =>
            {
                DatabaseSettings databaseSetting = DatabaseSettings.Create(configuration);
                options.UseNpgsql(databaseSetting.ConnectionString, b => b.MigrationsAssembly("Api.Servfy.Base.Migrations"));
            });

            return services;
        }


        //private readonly DbContextOptions<ServfyBaseContext> _options;

        //public InfrastructureModule(IConfiguration configuration) : this(CreateDbOptions(configuration), configuration)
        //{
        //    Configuration = configuration;
        //}

        //public InfrastructureModule(DbContextOptions<ServfyBaseContext> options, IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //    _options = options;
        //}

        //protected override void Load(ContainerBuilder builder)
        //{
        //    builder.RegisterInstance(Options.Create(DatabaseSettings.Create(Configuration)));
        //    builder.RegisterType<ServfyBaseContext>()
        //        .AsSelf()
        //        .InstancePerRequest()
        //        .InstancePerLifetimeScope()
        //        .WithParameter(new NamedParameter("options", _options)).ExternallyOwned();

        //    builder.Register(ctx =>
        //    {
        //        return new MemoryCache(new MemoryCacheOptions());
        //    }).As<IMemoryCache>().SingleInstance();
        //}

        //private static DbContextOptions<ServfyBaseContext> CreateDbOptions(IConfiguration configuration)
        //{
        //    var databaseSettings = DatabaseSettings.Create(configuration);
        //    var builder = new DbContextOptionsBuilder<ServfyBaseContext>();
        //    builder.UseNpgsql(databaseSettings.ConnectionString, b => b.MigrationsAssembly("Api.Servfy.Base.Migrations"));
        //    return builder.Options;
        //}
    }
}
