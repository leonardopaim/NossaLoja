using MySql.Data.MySqlClient;
using NossaLoja.Cadastros.Domain.Entities;
using NossaLoja.Cadastros.Domain.Interfaces.Repositories;
using NossaLoja.Core.Domain.Interfaces.Repositories;

namespace NossaLoja.Cadastros.Data.ADO.Repositories;

public class ClienteRepository : IClienteRepository
{
    public int GetNumeroUm(IDataContext dataContext)
    {
        var query = "SELECT 1";

        var mySqlCommand = new MySqlCommand(query);

        var retorno = Convert.ToInt32(dataContext.ExecuteScalar(mySqlCommand));

        return retorno;
    }

    public void Add(IDataContext dataContext, Cliente cliente)
    {
        var query = @"
            INSERT INTO cliente 
            (
                cliente_id,
                nome,
                cpf,
                identidade,
                cnpj,
                inscricao_estadual,
                ativo,
                excluido
            )
            VALUES
            (
                ?ClienteId,
                ?Nome,
                ?Cpf,
                ?Identidade,
                ?Cnpj,
                ?InscricaoEstadual,
                ?Ativo,
                ?Excluido
            );

            SELECT LAST_INSERT_ID();
        ";

        var mySqlCommand = new MySqlCommand(query);
        mySqlCommand.Parameters.AddWithValue("?ClienteId", cliente.Id);
        mySqlCommand.Parameters.AddWithValue("?Nome", cliente.Nome);
        mySqlCommand.Parameters.AddWithValue("?Cpf", cliente.Cpf);
        mySqlCommand.Parameters.AddWithValue("?Identidade", cliente.Identidade);
        mySqlCommand.Parameters.AddWithValue("?Cnpj", cliente.Cnpj);
        mySqlCommand.Parameters.AddWithValue("?InscricaoEstadual", cliente.InscricaoEstadual);
        mySqlCommand.Parameters.AddWithValue("?Ativo", cliente.Ativo);
        mySqlCommand.Parameters.AddWithValue("?Excluido", cliente.Excluido);

        var id = dataContext.ExecuteScalar(mySqlCommand);

        cliente.Id = Convert.ToInt32(id);
    }

    public int Update()
    {
        return 1;
    }

    public int Delete()
    {
        return 1;
    }
}
