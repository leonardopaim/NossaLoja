using NossaLoja.Cadastros.Domain.Entities;
using NossaLoja.Core.Domain.Interfaces.Repositories;

namespace NossaLoja.Cadastros.Domain.Interfaces.Repositories;

public interface IClienteRepository
{
    int GetNumeroUm(IDataContext dataContext);
    void Add(IDataContext dataContext, Cliente cliente);
    void Update(IDataContext dataContext, Cliente cliente);
    void Delete(IDataContext dataContext, int clienteId);
}
