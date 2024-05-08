using System.Net;

namespace NossaLoja.Core.Application.Application;

public class BaseApplication
{
    public virtual HttpStatusCode StatusCode 
        => throw new NotImplementedException("Deve ser implementada na classe derivada.");
        
    public virtual string ResponseMessage
        => throw new NotImplementedException("Deve ser implementada na classe derivada.");
}
