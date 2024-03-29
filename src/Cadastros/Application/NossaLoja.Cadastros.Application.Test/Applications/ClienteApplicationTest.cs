using NossaLoja.Cadastros.Application.Applications;

namespace NossaLoja.Cadastros.Application.Test.Applications;

[TestClass]
public class ClienteApplicationTest
{
    private readonly ClienteApplication _clienteApplication;

    public ClienteApplicationTest()
    {
        _clienteApplication = new ClienteApplication();
    }

    [TestMethod]
    public void Cadastros_TotalDeClientes_Sucesso()
    {
        var quantidade = _clienteApplication.TotalDeClientes();
        Assert.AreEqual(10, quantidade);
        Assert.AreEqual("Sucesso", _clienteApplication.Resposta);
    }

    [TestMethod]
    public void Cadastros_SomaUmMaisUm_Sucesso()
    {
        var resultado1 = _clienteApplication.SomaUmMaisUm();
        Assert.AreEqual(2, resultado1);
        Assert.AreEqual("Sucesso 1", _clienteApplication.Resposta);
    }

    [TestMethod]
    public void Cadastros_SomaUmMaisDois_Sucesso() 
    {
        var resultado2 = _clienteApplication.SomaUmMaisDois();
        Assert.IsTrue(resultado2 == 3);
        Assert.IsTrue(_clienteApplication.Resposta == "Sucesso 2");
    }
}
