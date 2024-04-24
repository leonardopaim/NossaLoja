using NossaLoja.Cadastros.Domain.Entities;
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

    public int SomaUmMaisUm()
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

    public void Add(Cliente cliente)
    {
        try
        {
            _dataContext.BeginTransaction();

            _clienteRepository.Add(_dataContext, cliente);

            _dataContext.Commit();
        }
        catch
        {
            _dataContext.Rollback();
        }
        finally
        {
            _dataContext.Finally();
        }
    }

    public int Update()
    {
        try
        {
            _dataContext.BeginTransaction();

            var resultado = _clienteRepository.Update();

            _dataContext.Commit();

            return resultado;
        }
        catch
        {
            _dataContext.Rollback();

            return 0;
        }
        finally
        {
            _dataContext.Finally();
        }
    }

    public int Delete()
    {
        try
        {
            _dataContext.BeginTransaction();

            var resultado = _clienteRepository.Delete();

            _dataContext.Commit();

            return resultado;
        }
        catch
        {
            _dataContext.Rollback();

            return 0;
        }
        finally
        {
            _dataContext.Finally();
        }
    }
}
