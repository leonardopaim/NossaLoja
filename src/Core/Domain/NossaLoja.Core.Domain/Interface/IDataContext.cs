namespace NossaLoja.Core.Domain.Interface;

public interface IDataContext : IDisposable
{
    string MySqlConnectionString { get; }

    void BeginTransaction(string connectionString);
    void BeginTransaction();
    object ExecuteScalar(dynamic command);
    int ExecuteCommand(dynamic command);
    void ExecuteReader(dynamic command, dynamic dataTable);
    void Commit();
    void Rollback();
    void Finally();
}
