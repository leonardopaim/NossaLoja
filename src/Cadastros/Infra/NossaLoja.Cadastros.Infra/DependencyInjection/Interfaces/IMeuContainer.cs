namespace NossaLoja.Cadastros.Infra.DependencyInjection.Interfaces;

public interface IMeuContainer
{
    T Resolve<T>();
    T Resolve<T>(Type type);
    T Resolve<T>(string name);
}
