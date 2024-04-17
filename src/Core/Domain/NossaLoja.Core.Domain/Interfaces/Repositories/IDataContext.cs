namespace NossaLoja.Core.Domain.Interfaces.Repositories;

public interface IDataContext
{
    void BeginTransaction();
    void Commit();
    void Rollback();
    void Finally();

    /// <summary>
    /// Utilizado para executar comandos que não retornam nada no banco de dados como INSERT, DELETE, UPDATE.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>A quantidade de linhas afetadas pelo comando.</returns>
    int ExecuteCommand(dynamic command);

    /// <summary>
    /// Utilizado para executar comandos que retornam um conjunto de resultados como SELECT.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="dataTable"></param>
    void ExecuteReader(dynamic command, dynamic dataTable);

    /// <summary>
    /// Utilizado para executar comandos onde se espera apenas um valor, como em uma consulta que retorna apenas uma coluna de uma única linha.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>O valor da primeira coluna da primeira linha do comando.</returns>
    object ExecuteScalar(dynamic command);
}
