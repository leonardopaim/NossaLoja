using NossaLoja.Core.Domain.Interface;

namespace NossaLoja.Cadastros.Domain.Services;

public class BaseService
{
    public virtual string Resposta { get; set; }

    protected IDataContext _dataContext { get; private set; }

    public BaseService(IDataContext dataContext)
    {
        _dataContext = dataContext;
    }
}
