using NossaLoja.Cadastros.Application.Mappers;
using NossaLoja.Cadastros.Application.ViewModels;
using NossaLoja.Cadastros.Domain.Entities;
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

    public int SomaUmMaisUm()
    {
        var resultado = ServiceFactory().SomaUmMaisUm();
        
        return resultado;
    }

    public void Add(ClienteVM clienteVM)
    {
        var cliente = ClienteMap.Get(clienteVM);

        ServiceFactory().Add(cliente);

        clienteVM.Id = cliente.Id;
    }

    public int Update()
    {
        var resultado = ServiceFactory().Update();

        return resultado;
    }

    public int Delete()
    {
        var resultado = ServiceFactory().Delete();

        return resultado;
    }
}
