namespace NossaLoja.Cadastros.Application.ViewModels;

public class ClienteVM
{
    public int Id { get; set; }
    public bool Ativo { get; set; }
    public bool Excluido { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public string Identidade { get; set; }
    public string Cnpj { get; set; }
    public string InscricaoEstadual { get; set; }
}
