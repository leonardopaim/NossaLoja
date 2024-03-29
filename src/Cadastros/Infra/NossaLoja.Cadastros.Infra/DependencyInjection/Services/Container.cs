using Autofac;
using NossaLoja.Cadastros.Data.ADO.Repositories;
using NossaLoja.Cadastros.Domain.Interfaces.Repositories;
using NossaLoja.Cadastros.Infra.DependencyInjection.Interfaces;
using Unity;
using Unity.Lifetime;

namespace NossaLoja.Cadastros.Infra.DependencyInjection.Services;

public class Container : IMeuContainer
{
    private readonly IUnityContainer _unityContainer;

    public Container()
    {
        _unityContainer = new UnityContainer();
        RegisterTypes();
    }

    public static Container GetContainer() => new Container();

    public T Resolve<T>() => _unityContainer.Resolve<T>();

    public T Resolve<T>(Type type) => (T)_unityContainer.Resolve(type);

    public T Resolve<T>(string name) => _unityContainer.Resolve<T>(name);

    private void RegisterTypes()
    {
        _unityContainer
            .Scoped<IClienteRepository, ClienteRepository>();
    }
}

public static class RegisterTypeExtension
{
    public static IUnityContainer Transient<TInterface, TImplementation>(this IUnityContainer container) where TImplementation : TInterface
    {
        container.RegisterType<TInterface, TImplementation>(new TransientLifetimeManager());
        return container;
    }
    
    public static IUnityContainer Scoped<TInterface, TImplementation>(this IUnityContainer container) where TImplementation : TInterface
    {
        container.RegisterType<TInterface, TImplementation>(new HierarchicalLifetimeManager());
        return container;
    }
    
    public static IUnityContainer Singleton<TInterface, TImplementation>(this IUnityContainer container) where TImplementation : TInterface
    {
        container.RegisterType<TInterface, TImplementation>(new ContainerControlledLifetimeManager());
        return container;
    }
}
