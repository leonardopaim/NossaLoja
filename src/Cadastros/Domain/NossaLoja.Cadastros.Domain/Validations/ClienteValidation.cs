using NossaLoja.Cadastros.Domain.Entities;
using NossaLoja.Core.Domain.Services;
using NossaLoja.Core.Domain.Validations;

namespace NossaLoja.Cadastros.Domain.Validations;

public class ClienteValidation : BaseValidation
{
    public ClienteValidation(ResponseService responseService) 
        : base(responseService) { }

    public void Validar(Cliente cliente)
    {
        if (string.IsNullOrEmpty(cliente.Nome))
            ResponseService.AddError("ClienteNome", "O nome não pode ser vazio.");

        if (string.IsNullOrEmpty(cliente.Cpf) && string.IsNullOrEmpty(cliente.Cnpj))
        {
            ResponseService.AddError("ClienteCpf", "Deve ser preenchido o CPF ou o CNPJ.");
            ResponseService.AddError("ClienteCnpj", "Deve ser preenchido o CPF ou o CNPJ.");
        }

        if (!string.IsNullOrEmpty(cliente.Cpf) && string.IsNullOrEmpty(cliente.Identidade))
            ResponseService.AddError("ClienteIdentidade", "Para pessoa física precisa informar a Identidade.");

        if (!string.IsNullOrEmpty(cliente.Cnpj) && string.IsNullOrEmpty(cliente.InscricaoEstadual))
            ResponseService.AddError("ClienteInscricaoEstadual", "Para pessoa jurídica precisa informar a Inscrição Estadual.");
        
        VerificarErros();
    }
}
