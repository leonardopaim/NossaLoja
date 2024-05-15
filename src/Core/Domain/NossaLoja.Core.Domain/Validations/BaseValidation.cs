using NossaLoja.Core.Domain.Exceptions;
using NossaLoja.Core.Domain.Services;

namespace NossaLoja.Core.Domain.Validations;

public class BaseValidation
{
    public ResponseService ResponseService { get; private set; }

    public BaseValidation(ResponseService responseService)
    {
        ResponseService = responseService;
    }

    public void VerificarErros()
    {
        if (!ResponseService.CheckIsValid())
            throw new ValidacaoException("O objeto não foi validado.");
    }
}
