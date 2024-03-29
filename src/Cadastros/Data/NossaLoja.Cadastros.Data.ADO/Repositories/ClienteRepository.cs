using NossaLoja.Cadastros.Domain.Interfaces.Repositories;

namespace NossaLoja.Cadastros.Data.ADO.Repositories;

public class ClienteRepository : IClienteRepository
{
    public int TotalDeClientes()
    {
        return 10;
    }
}
