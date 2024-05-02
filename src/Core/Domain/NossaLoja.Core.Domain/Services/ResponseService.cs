using NossaLoja.Core.Domain.Enums;

namespace NossaLoja.Core.Domain.Services;

public class ResponseService
{
    private StatusCodeEnum _status;
    public StatusCodeEnum StatusCode 
    { 
        get => _status; 
        set => _status = value; 
    }

    private string _message = "";
    public string Message 
    { 
        get => _message ?? ""; 
        set => _message = value; 
    }

    private Exception _exception = new Exception();
    public Exception Exception 
    { 
        get => _exception ?? new Exception(); 
        set => _exception = value; 
    }

    public void SetResponse(StatusCodeEnum status, string mensagem = "", Exception ex = null)
    {
        _status = status;
        _message = mensagem;

        if (ex != null) 
            _exception = ex;
    }
}
