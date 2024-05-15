using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
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

    public void Update(IDataContext dataContext, Cliente cliente)
    {
        var query = @"
            UPDATE cliente

            SET nome = ?Nome,
	            cpf = ?Cpf,
	            identidade = ?Identidade,
	            cnpj = ?Cnpj,
	            inscricao_estadual = ?InscricaoEstadual,
	            ativo = ?Ativo,
	            excluido = ?Excluido

            WHERE cliente_id = ?ClienteId
        ";

        var mySqlCommand = new MySqlCommand(query);
        mySqlCommand.Parameters.AddWithValue("?Nome", cliente.Nome);
        mySqlCommand.Parameters.AddWithValue("?Cpf", cliente.Cpf);
        mySqlCommand.Parameters.AddWithValue("?Identidade", cliente.Identidade);
        mySqlCommand.Parameters.AddWithValue("?Cnpj", cliente.Cnpj);
        mySqlCommand.Parameters.AddWithValue("?InscricaoEstadual", cliente.InscricaoEstadual);
        mySqlCommand.Parameters.AddWithValue("?Ativo", cliente.Ativo);
        mySqlCommand.Parameters.AddWithValue("?Excluido", cliente.Excluido);
        mySqlCommand.Parameters.AddWithValue("?ClienteId", cliente.Id);

        dataContext.ExecuteCommand(mySqlCommand);
    }

    public void Delete(IDataContext dataContext, int clienteId)
    {
        var query = @"
            UPDATE cliente
            SET excluido = ?Excluido
            WHERE cliente_id = ?ClienteId
        ";

        var mySqlCommand = new MySqlCommand(query);
        mySqlCommand.Parameters.AddWithValue("?Excluido", true);
        mySqlCommand.Parameters.AddWithValue("?ClienteId", clienteId);

        dataContext.ExecuteCommand(mySqlCommand);
    }
}
