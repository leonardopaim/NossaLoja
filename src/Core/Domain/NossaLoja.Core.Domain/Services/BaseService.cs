using NossaLoja.Core.Domain.Interfaces.Repositories;

namespace NossaLoja.Core.Domain.Services;

public class BaseService
{
    public ResponseService ResponseService { get; set; }
    public IDataContext _dataContext { get; private set; }

    public BaseService()
    {
        ResponseService = new ResponseService();
    }

    public BaseService(IDataContext dataContext)
    {
        ResponseService = new ResponseService();
        _dataContext = dataContext;
    }
}
