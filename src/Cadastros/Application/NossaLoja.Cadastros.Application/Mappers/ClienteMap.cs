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

    private static IMapper ConfigurationClienteVMToCliente()
    {
        return new MapperConfiguration(x =>
        {
            x.CreateMap<ClienteVM, Cliente>();
        }).CreateMapper();
    }
}
