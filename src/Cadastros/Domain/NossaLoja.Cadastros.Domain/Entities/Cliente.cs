namespace NossaLoja.Cadastros.Domain.Entities;

public class Cliente
{
    public int Id { get; set; }
    public bool Ativo { get; set; }
    public bool Excluido { get; set; }

    private string _nome = "";
    public string Nome 
    { 
        get => _nome ?? ""; 
        set => _nome = value; 
    }

    private string _cpf = "";
    public string Cpf
    {
        get => _cpf ?? "";
        set => _cpf = value;
    }

    private string _identidade = "";
    public string Identidade
    {
        get => _identidade ?? "";
        set => _identidade = value;
    }

    private string _cnpj = "";
    public string Cnpj
    {
        get => _cnpj ?? "";
        set => _cnpj = value;
    }

    private string _inscricaoEstadual = "";
    public string InscricaoEstadual
    {
        get => _inscricaoEstadual ?? "";
        set => _inscricaoEstadual = value;
    }
}
