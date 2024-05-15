namespace NossaLoja.Core.Domain.Exceptions;

public class ValidacaoException : Exception
{
    public ValidacaoException(string mensagem) : base(mensagem) { }
}
