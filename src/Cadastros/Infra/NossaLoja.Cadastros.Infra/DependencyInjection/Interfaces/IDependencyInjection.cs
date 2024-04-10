namespace NossaLoja.Cadastros.Infra.DependencyInjection.Interfaces;

public interface IDependencyInjection
{
    T Resolve<T>();
    T Resolve<T>(string name);
    T Resolve<T>(Type type);
}
