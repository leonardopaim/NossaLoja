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
        Assert.IsTrue(ClienteApplication.Errors.Count == 0);
        Assert.IsTrue(clienteVM.Id > 0);
    }

    [TestMethod]
    public void Clientes_Add_Erro()
    {
        var clienteVM1 = new ClienteVM
        {
            Nome = "",
            Cpf = "12345678909",
            Identidade = "123456789",
            Cnpj = "",
            InscricaoEstadual = "",
            Ativo = true,
            Excluido = false,
        };

        ClienteApplication.Add(clienteVM1);

        Assert.AreEqual((HttpStatusCode)422, ClienteApplication.StatusCode);
        Assert.IsTrue(clienteVM1.Id == 0);
        Assert.IsTrue(ClienteApplication.Errors.Exists(x => x.Field.Equals("ClienteNome")));

        var clienteVM2 = new ClienteVM
        {
            Nome = "Leonardo Paim",
            Cpf = "",
            Identidade = "123456789",
            Cnpj = "",
            InscricaoEstadual = "",
            Ativo = true,
            Excluido = false,
        };

        ClienteApplication.Add(clienteVM2);

        Assert.AreEqual((HttpStatusCode)422, ClienteApplication.StatusCode);
        Assert.IsTrue(clienteVM2.Id == 0);
        Assert.IsTrue(ClienteApplication.Errors.Exists(x => x.Field.Equals("ClienteCpf")));
        Assert.IsTrue(ClienteApplication.Errors.Exists(x => x.Field.Equals("ClienteCnpj")));

        var clienteVM3 = new ClienteVM
        {
            Nome = "Leonardo Paim",
            Cpf = "12345678909",
            Identidade = "",
            Cnpj = "",
            InscricaoEstadual = "",
            Ativo = true,
            Excluido = false,
        };

        ClienteApplication.Add(clienteVM3);

        Assert.AreEqual((HttpStatusCode)422, ClienteApplication.StatusCode);
        Assert.IsTrue(clienteVM3.Id == 0);
        Assert.IsTrue(ClienteApplication.Errors.Exists(x => x.Field.Equals("ClienteIdentidade")));

        var clienteVM4 = new ClienteVM
        {
            Nome = "Sommus Sistemas",
            Cpf = "",
            Identidade = "",
            Cnpj = "123456789000112",
            InscricaoEstadual = "",
            Ativo = true,
            Excluido = false,
        };

        ClienteApplication.Add(clienteVM4);

        Assert.AreEqual((HttpStatusCode)422, ClienteApplication.StatusCode);
        Assert.IsTrue(clienteVM4.Id == 0);
        Assert.IsTrue(ClienteApplication.Errors.Exists(x => x.Field.Equals("ClienteInscricaoEstadual")));
    }

    [TestMethod]
    public void Clientes_Update_Sucesso()
    {
        var clienteVM1 = new ClienteVM
        {
            Nome = "Trocar Nome",
            Cpf = "12345678909",
            Identidade = "123456789",
            Cnpj = "",
            InscricaoEstadual = "",
            Ativo = true,
            Excluido = false,
        };

        ClienteApplication.Add(clienteVM1);

        clienteVM1.Nome = "Aurélio Paim";

        ClienteApplication.Update(clienteVM1);

        Assert.AreEqual(HttpStatusCode.OK, ClienteApplication.StatusCode);
        Assert.IsTrue(ClienteApplication.Errors.Count == 0);
    }

    [TestMethod]
    public void Clientes_Delete_Sucesso()
    {
        var clienteVM1 = new ClienteVM
        {
            Nome = "Cliente Para Deletar",
            Cpf = "12345678909",
            Identidade = "123456789",
            Cnpj = "",
            InscricaoEstadual = "",
            Ativo = true,
            Excluido = false,
        };

        ClienteApplication.Add(clienteVM1);

        var clienteId = clienteVM1.Id;

        ClienteApplication.Delete(clienteId);

        Assert.AreEqual(HttpStatusCode.OK, ClienteApplication.StatusCode);
    }

    [TestMethod]
    public void Clientes_GetAll_Sucesso()
    {
        var clienteVM1 = new ClienteVM
        {
            Nome = "Cliente Para GET ALL",
            Cpf = "12345678909",
            Identidade = "123456789",
            Cnpj = "",
            InscricaoEstadual = "",
            Ativo = true,
            Excluido = false,
        };

        ClienteApplication.Add(clienteVM1);

        var clientesVM = ClienteApplication.GetAll();

        Assert.AreEqual(HttpStatusCode.OK, ClienteApplication.StatusCode);
        Assert.IsTrue(clientesVM.Count > 0);
    }

    [TestMethod]
    public void Clientes_Get_Sucesso()
    {
        var clienteVM1 = new ClienteVM
        {
            Nome = "Cliente Para GET",
            Cpf = "12345678909",
            Identidade = "123456789",
            Cnpj = "",
            InscricaoEstadual = "",
            Ativo = true,
            Excluido = false,
        };

        ClienteApplication.Add(clienteVM1);

        var clienteId = clienteVM1.Id;

        var clienteVMRecuperado = ClienteApplication.Get(clienteId);

        Assert.AreEqual(HttpStatusCode.OK, ClienteApplication.StatusCode);
        Assert.IsTrue(clienteVMRecuperado.Id == clienteVM1.Id);
    }

    [TestMethod]
    public void Clientes_Get_NaoEncontrado()
    {
        var clienteId = int.MaxValue;

        ClienteApplication.Get(clienteId);

        Assert.AreEqual(HttpStatusCode.NotFound, ClienteApplication.StatusCode);
    }
}
