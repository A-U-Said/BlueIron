using App.Api.Configuration.MediatRConfig;
using App.Repository;
using App.Repository.Interfaces;
using SimpleInjector;
using SimpleInjector.Lifestyles;

namespace App.Api.Configuration
{
    public static class SimpleInjectorConfig
    {
        public static readonly Container container = new Container();
        public static void ConfigureSimpleInjector(this IServiceCollection services)
        {
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            container.Options.ResolveUnregisteredConcreteTypes = true;

            container.RegisterRepositoryMaps();
            container.RegisterMediatR(
                AppDomain.CurrentDomain.Load("App.Library"),
                AppDomain.CurrentDomain.Load("App.Repository")
            );

            services.AddSimpleInjector(container, options => {
                options
                    .AddAspNetCore()
                    .AddControllerActivation();
                options.AddLogging();
            });
        }

        public static void RegisterRepositoryMaps(this Container container)
        {
            container.Register<IUserRepository, UserRepository>();
        }
    }
}
