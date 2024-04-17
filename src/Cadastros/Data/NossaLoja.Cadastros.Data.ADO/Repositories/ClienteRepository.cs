using MySql.Data.MySqlClient;
using NossaLoja.Cadastros.Domain.Interfaces.Repositories;
using NossaLoja.Core.Domain.Interfaces.Repositories;

namespace NossaLoja.Cadastros.Data.ADO.Repositories;

public class ClienteRepository : IClienteRepository
{
    public Int64 GetNumeroUm(IDataContext dataContext)
    {
        var query = "SELECT 1";

        var mySqlCommand = new MySqlCommand(query);

        var retorno = Convert.ToInt32(dataContext.ExecuteScalar(mySqlCommand));

        return retorno;
    }
}
