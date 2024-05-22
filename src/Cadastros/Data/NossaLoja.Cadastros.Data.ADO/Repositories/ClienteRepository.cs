using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using NossaLoja.Cadastros.Domain.Entities;
using NossaLoja.Cadastros.Domain.Interfaces.Repositories;
using NossaLoja.Core.Domain.Interfaces.Repositories;
using System.Data;

namespace NossaLoja.Cadastros.Data.ADO.Repositories;

public class ClienteRepository : IClienteRepository
{
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

    public List<Cliente> GetAll(IDataContext dataContext)
    {
        var query = @"
            SELECT cliente_id, 
                   nome, 
                   cpf, 
                   identidade, 
                   cnpj, 
                   inscricao_estadual, 
                   ativo, 
                   excluido
            FROM cliente
        ";

        var mySqlCommand = new MySqlCommand(query);

        var dataTable = new DataTable();

        dataContext.ExecuteReader(mySqlCommand, dataTable);

        var clientes = new List<Cliente>();

        foreach (DataRow row in dataTable.Rows)
        {
            var cliente = new Cliente
            {
                Id = Convert.ToInt32(row["cliente_id"]),
                Nome = Convert.ToString(row["nome"]),
                Cpf = row["cpf"].ToString(),
                Identidade = Convert.ToString(row["identidade"]),
                Cnpj = Convert.ToString(row["cnpj"]),
                InscricaoEstadual = Convert.ToString(row["inscricao_estadual"]),
                Ativo = Convert.ToBoolean(row["ativo"]),
                Excluido = Convert.ToBoolean(row["excluido"]),
            };

            clientes.Add(cliente);
        }

        return clientes;
    }

    public Cliente Get(IDataContext dataContext, int clienteId)
    {
        var query = @"
            SELECT cliente_id, 
                   nome, 
                   cpf, 
                   identidade, 
                   cnpj, 
                   inscricao_estadual, 
                   ativo, 
                   excluido
            FROM cliente
            WHERE cliente_id = ?ClienteId
        ";

        var mySqlCommand = new MySqlCommand(query);
        mySqlCommand.Parameters.AddWithValue("?ClienteId", clienteId);

        var dataTable = new DataTable();

        dataContext.ExecuteReader(mySqlCommand, dataTable);

        if (dataTable.Rows.Count == 0)
            return new Cliente();

        var row = dataTable.Rows[0];

        var cliente = new Cliente
        {
            Id = Convert.ToInt32(row["cliente_id"]),
            Nome = Convert.ToString(row["nome"]),
            Cpf = row["cpf"].ToString(),
            Identidade = Convert.ToString(row["identidade"]),
            Cnpj = Convert.ToString(row["cnpj"]),
            InscricaoEstadual = Convert.ToString(row["inscricao_estadual"]),
            Ativo = Convert.ToBoolean(row["ativo"]),
            Excluido = Convert.ToBoolean(row["excluido"]),
        };

        return cliente;
    }
}
