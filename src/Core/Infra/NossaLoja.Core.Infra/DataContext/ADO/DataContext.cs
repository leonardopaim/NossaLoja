using MySql.Data.MySqlClient;
using NossaLoja.Core.Domain.Interface;
using System.Data;
using System.Diagnostics;

namespace NossaLoja.Core.Infra.DataContext.ADO;

[DebuggerDisplay("{MySqlConnectionString}")]
public class DataContext : IDataContext
{
    public string MySqlConnectionString { get; private set; }
    public MySqlConnection MySqlConnection { get; set; }
    private MySqlTransaction MySqlTransaction { get; set; }

    public void BeginTransaction(string connectionString)
    {
        MySqlConnection = new MySqlConnection(connectionString);
        MySqlConnectionString = MySqlConnection.ConnectionString;
        MySqlConnection.Open();
        MySqlTransaction = MySqlConnection.BeginTransaction();
    }

    public void BeginTransaction()
    {
        var connectionString = "Server=localhost;Port=3309;Database=nossa_loja;Uid=root;Pwd=root;";
        MySqlConnection = new MySqlConnection(connectionString);
        MySqlConnectionString = MySqlConnection.ConnectionString;
        MySqlConnection.Open();
        MySqlTransaction = MySqlConnection.BeginTransaction();
    }

    public void Commit() => MySqlTransaction.Commit();

    public void Rollback() => MySqlTransaction.Rollback();

    public void Finally()
    {
        if (MySqlTransaction != null)
            MySqlTransaction.Dispose();
        
        if (MySqlConnection != null)
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

    public void Dispose() => GC.SuppressFinalize(this);
}
