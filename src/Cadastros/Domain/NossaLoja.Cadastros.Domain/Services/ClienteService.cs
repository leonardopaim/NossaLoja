using NossaLoja.Cadastros.Domain.Entities;
using NossaLoja.Cadastros.Domain.Interfaces.Repositories;
using NossaLoja.Cadastros.Domain.Validations;
using NossaLoja.Core.Domain.Enums;
using NossaLoja.Core.Domain.Exceptions;
using NossaLoja.Core.Domain.Interfaces.Repositories;
using NossaLoja.Core.Domain.Services;

namespace NossaLoja.Cadastros.Domain.Services;

public class ClienteService : BaseService
{
    private readonly IClienteRepository _clienteRepository;
    private readonly ClienteValidation _clienteValidation;

    public ClienteService(IDataContext dataContext, IClienteRepository clienteRepository)
        : base(dataContext)
    {
        _clienteRepository = clienteRepository;

        _clienteValidation = new ClienteValidation(ResponseService);
    }

    public void Add(Cliente cliente)
    {
        try
        {
            _dataContext.BeginTransaction();

            _clienteValidation.Validar(cliente);

            _clienteRepository.Add(_dataContext, cliente);

            _dataContext.Commit();

            ResponseService.SetResponse(StatusCodeEnum.Created, "Cliente cadastrado com sucesso!");
        }
        catch (ValidacaoException)
        {
            ResponseService.SetResponse(StatusCodeEnum.UnprocessableEntity, "Dados inválidos.");
        }
        catch (Exception ex)
        {
            _dataContext.Rollback();

            ResponseService.SetResponse(StatusCodeEnum.InternalServerError, "Erro ao cadastrar o cliente.", ex);
        }
        finally
        {
            _dataContext.Finally();
        }
    }

    public void Update(Cliente cliente)
    {
        try
        {
            _dataContext.BeginTransaction();

            _clienteValidation.Validar(cliente);

            _clienteRepository.Update(_dataContext, cliente);

            _dataContext.Commit();

            ResponseService.SetResponse(StatusCodeEnum.Ok);
        }
        catch (ValidacaoException)
        {
            ResponseService.SetResponse(StatusCodeEnum.UnprocessableEntity, "Dados inválidos.");
        }
        catch (Exception ex)
        {
            _dataContext.Rollback();

            ResponseService.SetResponse(StatusCodeEnum.InternalServerError, "Erro ao atualizar o cliente.", ex);
        }
        finally
        {
            _dataContext.Finally();
        }
    }

    public void Delete(int clienteId)
    {
        try
        {
            _dataContext.BeginTransaction();

            _clienteRepository.Delete(_dataContext, clienteId);

            _dataContext.Commit();

            ResponseService.SetResponse(StatusCodeEnum.Ok);
        }
        catch (Exception ex)
        {
            _dataContext.Rollback();

            ResponseService.SetResponse(StatusCodeEnum.InternalServerError, "Erro ao excluir o cliente.", ex);
        }
        finally
        {
            _dataContext.Finally();
        }
    }

    public List<Cliente> GetAll()
    {
        try
        {
            _dataContext.BeginTransaction();

            var clientes = _clienteRepository.GetAll(_dataContext);

            ResponseService.SetResponse(StatusCodeEnum.Ok);

            return clientes;
        }
        catch (Exception ex)
        {
            ResponseService.SetResponse(StatusCodeEnum.InternalServerError, "Erro ao recuperar a lista de clientes.", ex);

            return new List<Cliente>();
        }
        finally
        {
            _dataContext.Finally();
        }
    }

    public Cliente Get(int clienteId)
    {
        try
        {
            _dataContext.BeginTransaction();

            var cliente = _clienteRepository.Get(_dataContext, clienteId);

            if (cliente.Id == 0)
            {
                ResponseService.SetResponse(StatusCodeEnum.NotFound);
                return new Cliente();
            }

            ResponseService.SetResponse(StatusCodeEnum.Ok);

            return cliente;
        }
        catch (Exception ex)
        {
            ResponseService.SetResponse(StatusCodeEnum.InternalServerError, "Erro ao recuperar o cliente.", ex);

            return new Cliente();
        }
        finally
        {
            _dataContext.Finally();
        }
    }
}
