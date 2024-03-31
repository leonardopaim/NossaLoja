using System.Data;

namespace NossaLoja.Core.Domain.Interface;

public interface IDataContext : IDisposable
{
    /// <summary>
    /// String de conexão com o banco de dados da aplicação. <br/><br/>
    /// Ex: <i>"Server=HOST;Port=PORTA;Database=DATABASE;Uid=USER;Pwd=PASSWORD;"</i>
    /// </summary>
    string MySqlConnectionString { get; }

    /// <summary>
    /// Este método é usado para iniciar uma transação no banco de dados.<br/>
    /// Ele cria uma nova conexão MySQL usando a string de conexão fornecida, abre a conexão e inicia uma nova transação.
    /// </summary>
    void BeginTransaction();

    /// <summary>
    /// Utilizado quando se espera que o comando SQL retorne um único valor. <br/>
    /// </summary>
    /// <param name="command"></param>
    /// <returns>Valor da primeira coluna da primeira linha do resultado da consulta.</returns>
    object ExecuteScalar(dynamic command);

    /// <summary>
    /// Executa comandos SQL que não restornam resultados. É utilizado em <b>INSERT</b>, <b>UPDATE</b> e <b>DELETE</b>.
    /// </summary>
    /// <param name="command"></param>
    /// <returns>A quantidade de linhas afetadas pelo comando.</returns>
    int ExecuteCommand(dynamic command);

    /// <summary>
    /// Executa comandos SQL que restornam um conjunto de resultados. É utilizado em <b>SELECT's</b>. <br/>
    /// Os resultados da consulta são carregados em um <see cref="DataTable"/> fornecido como argumento.
    /// </summary>
    /// <param name="command"></param>
    /// <param name="dataTable"></param>
    void ExecuteReader(dynamic command, dynamic dataTable);

    /// <summary>
    /// Este método é usado para confirmar uma transação pendente. 
    /// Quando chamado, ele confirma todas as operações realizadas durante a transação atual, 
    /// aplicando as alterações permanentemente no banco de dados.
    /// </summary>
    void Commit();

    /// <summary>
    /// Este método é usado para reverter uma transação pendente. <br/>
    /// Se ocorrer um erro durante a execução das operações dentro da transação ou 
    /// se a transação for cancelada manualmente, chamando este método, todas as operações 
    /// realizadas até o momento são revertidas, deixando o banco de dados 
    /// no estado em que estava antes do início da transação.
    /// </summary>
    void Rollback();

    /// <summary>
    /// Este método é usado para finalizar a transação e liberar os recursos associados (como conexão e transação). <br/>
    /// Ele verifica se a transação e a conexão não são nulas e, se não forem, as descarta.
    /// </summary>
    void Finally();
}
