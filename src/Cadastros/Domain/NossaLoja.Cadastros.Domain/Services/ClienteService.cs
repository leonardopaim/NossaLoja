using NossaLoja.Cadastros.Domain.Interfaces;

namespace NossaLoja.Cadastros.Domain.Services;

public class ClienteService
{
    private IClienteRepository _clienteRepository;

    public int SomaUmMaisUm()
    {
        var valor1 = _clienteRepository.GetNumeroUm();
        var valor2 = _clienteRepository.GetNumeroUm();

        return valor1 + valor2;
    }
}
