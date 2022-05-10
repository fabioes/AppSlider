namespace AppSlider.Infrastructure.EntityFrameworkDataAccess
{
    using AppSlider.Infrastructure.DataAccess;
    using Autofac;
    using Microsoft.EntityFrameworkCore;

    public class Module : Autofac.Module
    {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DbContext>();

            optionsBuilder.UseLazyLoadingProxies().UseMySql(ConnectionString);
            //optionsBuilder.UseSqlServer(ConnectionString);
            optionsBuilder.EnableSensitiveDataLogging(true);

            builder.RegisterType<Context>()
              .WithParameter(new TypedParameter(typeof(DbContextOptions), optionsBuilder.Options))
              .InstancePerRequest();
            
            //
            // Register all Types in MongoDataAccess namespace
            //
            builder.RegisterAssemblyTypes(typeof(InfrastructureException).Assembly)
                .Where(type => type.Namespace.Contains("EntityFrameworkDataAccess"))
                .AsImplementedInterfaces()
                .InstancePerRequest();
        }
    }
}
