using NossaLoja.Core.Domain.Interfaces.Repositories;

namespace NossaLoja.Cadastros.Domain.Interfaces.Repositories;

public interface IClienteRepository
{
    Int64 GetNumeroUm(IDataContext dataContext);
}
