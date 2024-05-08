using NossaLoja.Cadastros.Application.Application;
using NossaLoja.Cadastros.Application.ViewModels;
using System.Net;

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

        Assert.AreEqual(HttpStatusCode.OK, ClienteApplication.StatusCode);
        Assert.AreEqual(2, resultado);
        Assert.AreEqual(HttpStatusCode.OK, ClienteApplication.StatusCode);
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

        Assert.AreEqual(HttpStatusCode.Created, ClienteApplication.StatusCode);
        Assert.IsTrue(clienteVM.Id > 0);
        Assert.AreEqual(HttpStatusCode.Created, ClienteApplication.StatusCode);
    }

    [TestMethod]
    public void Clientes_Update_Sucesso()
    {
        ClienteApplication.Update();

        Assert.AreEqual(HttpStatusCode.OK, ClienteApplication.StatusCode);
    }

    [TestMethod]
    public void Clientes_Delete_Sucesso()
    {
        ClienteApplication.Delete();

        Assert.AreEqual(HttpStatusCode.OK, ClienteApplication.StatusCode);
    }
}
