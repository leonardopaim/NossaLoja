using NossaLoja.Cadastros.Domain.Entities;
using NossaLoja.Core.Domain.Interfaces.Repositories;

namespace NossaLoja.Cadastros.Domain.Interfaces.Repositories;

public interface IClienteRepository
{
    int GetNumeroUm(IDataContext dataContext);
    void Add(IDataContext dataContext, Cliente cliente);
    int Update();
    int Delete();
}
