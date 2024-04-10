using NossaLoja.Cadastros.Infra.DependencyInjection.Interfaces;

namespace NossaLoja.Cadastros.Infra.DependencyInjection.Services;

public static class DependencyInjectionService
{
    private static IDependencyInjection _dependencyInjection;

    public static void Inicializa(IDependencyInjection dependencyInjection)
    {
        _dependencyInjection = dependencyInjection;
    }

    public static T Resolve<T>() => _dependencyInjection.Resolve<T>();

    public static T Resolve<T>(string name) => _dependencyInjection.Resolve<T>(name);

    public static T Resolve<T>(Type type) => _dependencyInjection.Resolve<T>(type);
}
