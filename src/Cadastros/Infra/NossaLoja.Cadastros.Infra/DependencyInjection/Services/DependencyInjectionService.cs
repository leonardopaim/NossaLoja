using NossaLoja.Cadastros.Infra.DependencyInjection.Interfaces;

namespace NossaLoja.Cadastros.Infra.DependencyInjection.Services;

public static class DependencyInjectionService
{
    private static IMeuContainer _container = new Container();

    public static void Inicializa(IMeuContainer container)
    {
        _container = container;
    }

    public static T Resolve<T>() => _container.Resolve<T>();

    public static T Resolve<T>(Type type) => _container.Resolve<T>(type);

    public static T Resolve<T>(string name) => _container.Resolve<T>(name);
}
