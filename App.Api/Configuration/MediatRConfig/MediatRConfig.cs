using MediatR.Pipeline;
using System.Reflection;
using SimpleInjector;
using MediatR;

namespace App.Api.Configuration.MediatRConfig
{
    public static class MediatRConfig
    {
        public static Container RegisterMediatR(this Container container, params Assembly[] assemblies)
        {
            return RegisterMediatR(container, (IEnumerable<Assembly>)assemblies);
        }

        public static Container RegisterMediatR(this Container container, IEnumerable<Assembly> assemblies)
        {
            var allAssemblies = GetAssemblies(assemblies);

            container.RegisterSingleton<IMediator, Mediator>();
            container.Register(typeof(IRequestHandler<,>), assemblies);

            RegisterHandlers(container, typeof(INotificationHandler<>), allAssemblies);
            RegisterHandlers(container, typeof(IRequestExceptionAction<,>), allAssemblies);
            RegisterHandlers(container, typeof(IRequestExceptionHandler<,,>), allAssemblies);

            //Pipeline
            container.Collection.Register(typeof(IPipelineBehavior<,>), new[]
            {
                typeof(RequestExceptionProcessorBehavior<,>),
                typeof(RequestExceptionActionProcessorBehavior<,>),
                typeof(RequestPreProcessorBehavior<,>),
                typeof(RequestPostProcessorBehavior<,>),
                typeof(EmptyPipelineBehavior<,>)
            });

            container.Collection.Register(typeof(IRequestPreProcessor<>), new[] { typeof(EmptyRequestPreProcessor<>) });
            container.Collection.Register(typeof(IRequestPostProcessor<,>), new[] { typeof(EmptyRequestPostProcessor<,>) });

            container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);

            return container;
        }

        private static void RegisterHandlers(Container container, Type collectionType, Assembly[] assemblies)
        {
            // we have to do this because by default, generic type definitions (such as the Constrained Notification Handler) won't be registered
            var handlerTypes = container.GetTypesToRegister(collectionType, assemblies, new TypesToRegisterOptions
            {
                IncludeGenericTypeDefinitions = true,
                IncludeComposites = false,
            });

            container.Collection.Register(collectionType, handlerTypes);
        }

        private static Assembly[] GetAssemblies(IEnumerable<Assembly> assemblies)
        {
            var allAssemblies = new List<Assembly> { typeof(IMediator).GetTypeInfo().Assembly };
            allAssemblies.AddRange(assemblies);

            return allAssemblies.ToArray();
        }

    }
}