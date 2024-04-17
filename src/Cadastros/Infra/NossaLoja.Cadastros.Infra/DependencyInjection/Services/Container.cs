using NossaLoja.Cadastros.Data.ADO.Repositories;
using NossaLoja.Cadastros.Domain.Interfaces.Repositories;
using NossaLoja.Cadastros.Infra.DependencyInjection.Interfaces;
using NossaLoja.Core.Domain.Interfaces.Repositories;
using NossaLoja.Core.Infra.DataContext.ADO;
using Unity;
using Unity.Injection;

namespace NossaLoja.Cadastros.Infra.DependencyInjection.Services;

public class Container : IDependencyInjection
{
    private static Container _container;
    private IUnityContainer _unityContainer;

    private Container()
    {
        _unityContainer = new UnityContainer();
        RegisterTypes();
    }

    public static Container GetContainer() => _container ?? new Container();

    public T Resolve<T>() => _unityContainer.Resolve<T>();

    public T Resolve<T>(string name) => _unityContainer.Resolve<T>(name);

    public T Resolve<T>(Type type) => (T)_unityContainer.Resolve(type);

    private void RegisterTypes()
    {
        _unityContainer
            .RegisterType<IDataContext, DataContext>(new InjectionConstructor())
            .RegisterType<IClienteRepository, ClienteRepository>(new InjectionConstructor());
    }
}
