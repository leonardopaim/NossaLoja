using NossaLoja.Cadastros.Infra.DependencyInjection.Services;

namespace NossaLoja.Cadastros.Application.Test.Applications;

public class BaseApplicationTest
{
    public BaseApplicationTest()
    {
        var container = Container.GetContainer();
        
        DependencyInjectionService.Inicializa(container);
    }
}
