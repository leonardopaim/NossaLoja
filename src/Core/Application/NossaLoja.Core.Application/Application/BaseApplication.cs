using NossaLoja.Core.Application.ViewModels;
using System.Net;

namespace NossaLoja.Core.Application.Application;

public class BaseApplication
{
    public virtual HttpStatusCode StatusCode 
        => throw new NotImplementedException("Deve ser implementada na classe derivada.");
        
    public virtual string ResponseMessage
        => throw new NotImplementedException("Deve ser implementada na classe derivada.");

    public virtual List<string> FieldsInvalids
        => throw new NotImplementedException("Deve ser implementada na classe derivada.");

    public virtual List<ResponseErrorVM> Errors
        => throw new NotImplementedException("Deve ser implementada na classe derivada.");
}
