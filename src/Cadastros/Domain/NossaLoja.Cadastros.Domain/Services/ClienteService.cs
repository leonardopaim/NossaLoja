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

    public int SomaUmMaisUm()
    {
        try
        {
            _dataContext.BeginTransaction();

            var valor1 = _clienteRepository.GetNumeroUm(_dataContext);
            var valor2 = _clienteRepository.GetNumeroUm(_dataContext);

            var resultado = valor1 + valor2;

            ResponseService.SetResponse(StatusCodeEnum.Ok);

            return resultado;
        }
        catch (Exception ex)
        {
            ResponseService.SetResponse(StatusCodeEnum.InternalServerError, "Erro ao somar os números.", ex);

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

            _clienteValidation.Validar(cliente);

            _clienteRepository.Add(_dataContext, cliente);

            _dataContext.Commit();

            ResponseService.SetResponse(StatusCodeEnum.Created);
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
}
