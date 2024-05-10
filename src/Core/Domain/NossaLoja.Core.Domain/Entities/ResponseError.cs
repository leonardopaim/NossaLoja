namespace NossaLoja.Core.Domain.Entities;

public class ResponseError
{
    private string _field = "";
    public string Field 
    { 
        get => _field ?? ""; 
        set => _field = value; 
    }

    private string _message = "";
    public string Message 
    {
        get => _message ?? "";
        set => _message = value;
    }
}
