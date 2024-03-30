using NossaLoja.Cadastros.Domain.Interfaces.Repositories;
using NossaLoja.Cadastros.Domain.Services;
using NossaLoja.Cadastros.Infra.DependencyInjection.Services;
using NossaLoja.Core.Domain.Interface;

namespace NossaLoja.Cadastros.Application.Applications;

public class ClienteApplication : BaseApplication
{
    private readonly ClienteService _clienteService;

    public ClienteApplication()
    {
        _clienteService = new ClienteService(
            DependencyInjectionService.Resolve<IDataContext>(),
            DependencyInjectionService.Resolve<IClienteRepository>()
        );
    }

    public override string Resposta => _clienteService.Resposta;

    public int TotalDeClientes()
    {
        return _clienteService.TotalDeClientes();
    }

    public int SomaUmMaisUm()
    {
        return _clienteService.SomaUmMaisUm();
    }

    public int SomaUmMaisDois()
    {
        return _clienteService.SomaUmMaisDois();
    }
}
