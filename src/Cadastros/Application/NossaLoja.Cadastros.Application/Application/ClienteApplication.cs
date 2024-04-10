using NossaLoja.Cadastros.Domain.Interfaces;
using NossaLoja.Cadastros.Domain.Services;
using NossaLoja.Cadastros.Infra.DependencyInjection.Services;

namespace NossaLoja.Cadastros.Application.Application;

public class ClienteApplication
{
    private ClienteService ServiceFactory()
    {
        var clienteService = new ClienteService(
            DependencyInjectionService.Resolve<IClienteRepository>()
        );

        return clienteService;
    }

    public int SomaUmMaisUm()
    {
        var resultado = ServiceFactory().SomaUmMaisUm();
        
        return resultado;
    }
}
