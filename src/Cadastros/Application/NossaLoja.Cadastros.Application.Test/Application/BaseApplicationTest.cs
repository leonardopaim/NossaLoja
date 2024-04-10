using NossaLoja.Cadastros.Infra.DependencyInjection.Services;

namespace NossaLoja.Cadastros.Application.Test.Application;

public class BaseApplicationTest
{
    public BaseApplicationTest()
    {
        var container = Container.GetContainer();
        DependencyInjectionService.Inicializa(container);
    }
}
