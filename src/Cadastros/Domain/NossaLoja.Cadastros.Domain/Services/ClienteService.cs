using NossaLoja.Cadastros.Domain.Interfaces.Repositories;
using NossaLoja.Core.Domain.Interface;
using System.Diagnostics;

namespace NossaLoja.Cadastros.Domain.Services;

public class ClienteService : BaseService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(
        IDataContext dataContext, 
        IClienteRepository clienteRepository
        ) : base(dataContext)
    {
        _clienteRepository = clienteRepository;
    }

    public int TotalDeClientes()
    {
        try
        {
            _dataContext.BeginTransaction();

            var quantidade = _clienteRepository.TotalDeClientes();

            Resposta = "Sucesso";

            return quantidade;
        }
        catch (Exception ex)
        {
            Resposta = "Falha";

            return 0;
        }
        finally
        {
            _dataContext.Finally();
        }
    }

    public int SomaUmMaisUm()
    {
        Resposta = "Sucesso 1";

        return 1 + 1;
    }

    public int SomaUmMaisDois()
    {
        Resposta = "Sucesso 2";

        return 1 + 2;
    }
}
