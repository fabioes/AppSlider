namespace AppSlider.Infrastructure.Modules
{
    using Autofac;
    using AppSlider.Application;
    using AppSlider.Domain.Authentication;

    public class ApplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in AppSlider.Application
            //
            builder.RegisterType<LoggedUser>()
               .As<LoggedUser>()
               .SingleInstance();

            builder.RegisterAssemblyTypes(typeof(ApplicationException).Assembly)
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
}
