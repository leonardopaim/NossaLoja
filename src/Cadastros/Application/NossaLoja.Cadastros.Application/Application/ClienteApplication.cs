using NossaLoja.Cadastros.Domain.Services;

namespace NossaLoja.Cadastros.Application.Application;

public class ClienteApplication
{
    public int SomaUmMaisUm()
    {
        var clienteService = new ClienteService();

        var resultado = clienteService.SomaUmMaisUm();
        
        return resultado;
    }
}
