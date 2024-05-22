using AutoMapper;
using NossaLoja.Cadastros.Application.ViewModels;
using NossaLoja.Cadastros.Domain.Entities;

namespace NossaLoja.Cadastros.Application.Mappers;

public static class ClienteMap
{
    public static Cliente Get(ClienteVM clienteVM)
    {
        return ConfigurationClienteVMToCliente()
            .Map<ClienteVM, Cliente>(clienteVM);
    }

    public static List<ClienteVM> Get(List<Cliente> clientes)
    {
        return ConfigurationClienteToClienteVM()
            .Map<List<Cliente>, List<ClienteVM>>(clientes);
    }

    public static ClienteVM Get(Cliente cliente)
    {
        return ConfigurationClienteToClienteVM()
            .Map<Cliente, ClienteVM>(cliente);
    }

    private static IMapper ConfigurationClienteVMToCliente()
    {
        return new MapperConfiguration(x =>
        {
            x.CreateMap<ClienteVM, Cliente>();
        }).CreateMapper();
    }

    private static IMapper ConfigurationClienteToClienteVM()
    {
        return new MapperConfiguration(x => 
        {
            x.CreateMap<Cliente, ClienteVM>();
        }).CreateMapper();
    }
}
