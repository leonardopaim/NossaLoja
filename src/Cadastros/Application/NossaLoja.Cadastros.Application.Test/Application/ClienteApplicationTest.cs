using NossaLoja.Cadastros.Application.Application;

namespace NossaLoja.Cadastros.Application.Test.Application;

[TestClass]
public class ClienteApplicationTest : BaseApplicationTest
{
    [TestMethod]
    public void Clientes_SomaUmMaisUm_Sucesso()
    {
        var clienteApplication = new ClienteApplication();

        var resultado = clienteApplication.SomaUmMaisUm();

        Assert.AreEqual(2, resultado);
    }
}
