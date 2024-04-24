using NossaLoja.Cadastros.Application.Application;
using NossaLoja.Cadastros.Application.ViewModels;

namespace NossaLoja.Cadastros.Application.Test.Application;

[TestClass]
public class ClienteApplicationTest : BaseApplicationTest
{
    private ClienteApplication ClienteApplication { get; set; }

    public ClienteApplicationTest()
    {
        ClienteApplication = new ClienteApplication();
    }

    [TestMethod]
    public void Clientes_SomaUmMaisUm_Sucesso()
    {
        var resultado = ClienteApplication.SomaUmMaisUm();

        Assert.AreEqual(2, resultado);
    }

    [TestMethod]
    public void Clientes_Add_Sucesso()
    {
        var clienteVM = new ClienteVM
        {
            Nome = "Leonardo Paim",
            Cpf = "12345678909",
            Identidade = "123456789",
            Ativo = true,
            Excluido = false,
        };

        ClienteApplication.Add(clienteVM);

        Assert.IsTrue(clienteVM.Id > 0);
    }

    [TestMethod]
    public void Clientes_Update_Sucesso()
    {
        var resultado = ClienteApplication.Update();

        Assert.AreEqual(1, resultado);
    }

    [TestMethod]
    public void Clientes_Delete_Sucesso()
    {
        var resultado = ClienteApplication.Delete();

        Assert.AreEqual(1, resultado);
    }
}
