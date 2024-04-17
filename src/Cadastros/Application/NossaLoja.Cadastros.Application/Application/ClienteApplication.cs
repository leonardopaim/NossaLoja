using NossaLoja.Cadastros.Domain.Interfaces.Repositories;
using NossaLoja.Cadastros.Domain.Services;
using NossaLoja.Cadastros.Infra.DependencyInjection.Services;
using NossaLoja.Core.Domain.Interfaces.Repositories;

namespace NossaLoja.Cadastros.Application.Application;

public class ClienteApplication
{
    private ClienteService ServiceFactory()
    {
        var clienteService = new ClienteService(
            DependencyInjectionService.Resolve<IDataContext>(),
            DependencyInjectionService.Resolve<IClienteRepository>()
        );

        return clienteService;
    }

    public Int64 SomaUmMaisUm()
    {
        var resultado = ServiceFactory().SomaUmMaisUm();
        
        return resultado;
    }
}
