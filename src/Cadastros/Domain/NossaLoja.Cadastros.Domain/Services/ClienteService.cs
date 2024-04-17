using NossaLoja.Cadastros.Domain.Interfaces.Repositories;
using NossaLoja.Core.Domain.Interfaces.Repositories;

namespace NossaLoja.Cadastros.Domain.Services;

public class ClienteService
{
    private readonly IDataContext _dataContext;
    private readonly IClienteRepository _clienteRepository;

    public ClienteService(IDataContext dataContext, IClienteRepository clienteRepository)
    {
        _dataContext = dataContext;
        _clienteRepository = clienteRepository;
    }

    public Int64 SomaUmMaisUm()
    {
        try
        {
            _dataContext.BeginTransaction();

            var valor1 = _clienteRepository.GetNumeroUm(_dataContext);
            var valor2 = _clienteRepository.GetNumeroUm(_dataContext);

            return valor1 + valor2;
        }
        catch
        {
            return 0;
        }
        finally
        {
            _dataContext.Finally();
        }
    }
}
