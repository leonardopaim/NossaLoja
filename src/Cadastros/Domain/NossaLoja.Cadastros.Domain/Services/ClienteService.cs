using NossaLoja.Cadastros.Domain.Interfaces.Repositories;
using System.Diagnostics;

namespace NossaLoja.Cadastros.Domain.Services;

public class ClienteService : BaseService
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public int TotalDeClientes()
    {
        try
        {
            var quantidade = _clienteRepository.TotalDeClientes();

            Resposta = "Sucesso";

            return quantidade;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);

            Resposta = "Falha";

            return 0;
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
