using NossaLoja.Cadastros.Application.Mappers;
using NossaLoja.Cadastros.Application.ViewModels;
using NossaLoja.Cadastros.Domain.Interfaces.Repositories;
using NossaLoja.Cadastros.Domain.Services;
using NossaLoja.Cadastros.Infra.DependencyInjection.Services;
using NossaLoja.Core.Application.Application;
using NossaLoja.Core.Domain.Interfaces.Repositories;
using System.Net;

namespace NossaLoja.Cadastros.Application.Application;

public class ClienteApplication : BaseApplication
{
    private ClienteService _clienteService;

    private ClienteService ServiceFactory()
    {
        _clienteService = new ClienteService(
            DependencyInjectionService.Resolve<IDataContext>(),
            DependencyInjectionService.Resolve<IClienteRepository>()
        );

        return _clienteService;
    }

    public override HttpStatusCode StatusCode => (HttpStatusCode)_clienteService.ResponseService.StatusCode;
    public override string ResponseMessage => _clienteService.ResponseService.Message;

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

    public void Update()
    {
        ServiceFactory().Update();
    }

    public void Delete()
    {
        ServiceFactory().Delete();
    }
}
