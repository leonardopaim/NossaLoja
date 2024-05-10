using NossaLoja.Core.Domain.Entities;
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

    private List<string> _fieldsInvalids = new List<string>();
    public List<string> FieldsInvalids 
    { 
        get => _fieldsInvalids ?? new List<string>(); 
        set => _fieldsInvalids = value; 
    }

    private List<ResponseError> _errors = new List<ResponseError>();
    public List<ResponseError> Errors 
    { 
        get => _errors ?? new List<ResponseError>(); 
        set => _errors = value; 
    }

    public void SetResponse(StatusCodeEnum status, string message = "", Exception ex = null)
    {
        _status = status;
        _message = message;

        if (ex != null)
            _exception = ex;
    }

    public bool CheckIsValid() => Errors.Count == 0 && FieldsInvalids.Count == 0;

    public void AddError(string field, string message, bool addToField = false)
    {
        _errors.Add(new ResponseError { Field = field, Message = message });

        if (addToField)
            _fieldsInvalids.Add(field);
    }
}
