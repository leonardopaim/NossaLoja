using MySql.Data.MySqlClient;
using NossaLoja.Core.Domain.Interfaces.Repositories;
using System.Data;

namespace NossaLoja.Core.Infra.DataContext.ADO;

public class DataContext : IDataContext
{
    private MySqlConnection MySqlConnection {  get; set; }
    private MySqlTransaction MySqlTransaction {  get; set; }

    public void BeginTransaction()
    {
        var connectionString = "Server=localhost;Database=nossa_loja;Uid=root;Pwd=root;Port=3307;Allow Zero Datetime=true;";

        MySqlConnection = new MySqlConnection(connectionString);
        MySqlConnection.Open();
        MySqlTransaction = MySqlConnection.BeginTransaction();
    }

    public void Commit()
    {
        MySqlTransaction.Commit();
    }

    public void Rollback()
    {
        MySqlTransaction.Rollback();
    }

    public void Finally()
    {
        if (MySqlTransaction != null)
            MySqlTransaction.Dispose();

        if(MySqlConnection != null)
        {
            MySqlConnection.Close();
            MySqlConnection.Dispose();
        }
    }

    public int ExecuteCommand(dynamic command)
    {
        var mySqlCommand = (command as MySqlCommand);
        mySqlCommand.Connection = MySqlConnection;
        mySqlCommand.Transaction = MySqlTransaction;
        return mySqlCommand.ExecuteNonQuery();
    }

    public void ExecuteReader(dynamic command, dynamic dataTable)
    {
        var mySqlCommand = (command as MySqlCommand);
        mySqlCommand.Connection = MySqlConnection;
        mySqlCommand.Transaction = MySqlTransaction;
        (dataTable as DataTable).Load(mySqlCommand.ExecuteReader());
    }

    public object ExecuteScalar(dynamic command)
    {
        var mySqlCommand = (command as MySqlCommand);
        mySqlCommand.Connection = MySqlConnection;
        mySqlCommand.Transaction = MySqlTransaction;
        return mySqlCommand.ExecuteScalar();
    }
}
