namespace AppSlider.Infrastructure.Modules
{
    using Autofac;
    using System;

    public class WebApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //
            // Register all Types in AppSlider.WebApi
            //

            Type startup = Type.GetType("AppSlider.WebApi.Startup, AppSlider.WebApi");

            builder.RegisterAssemblyTypes(startup.Assembly)
                .AsSelf()
                .SingleInstance();
        }
    }
}
