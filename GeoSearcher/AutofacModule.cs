using Autofac;
using BusinessLogic;
using DataAccess;
using DataAccess.DB;
using Microsoft.Extensions.Configuration;

namespace GeoSearcher
{
    public class AutofacModule : Module
    {
        private readonly IConfiguration _configuration;

        public AutofacModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BusinessLogic.GeoSearcher>()
                   .As<IGeoSearcher>()
                   .InstancePerLifetimeScope();

            builder.RegisterType<GeoRepository>()
                   .As<IGeoRepository>()
                   .SingleInstance();

            var dbPath = _configuration.GetValue<string>("dbPath");
            builder.Register(r => new FileDbManager(dbPath))
                   .SingleInstance();
        }
    }
}