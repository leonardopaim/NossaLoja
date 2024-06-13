using Microsoft.AspNetCore.Mvc;
using NossaLoja.Cadastros.Application.Application;
using NossaLoja.Cadastros.Application.ViewModels;

namespace NossaLoja.WebService.Controllers;

[Route("Api/Clientes")]
[ApiController]
public class ClienteController : ControllerBase
{
    private ClienteApplication ClienteApplication { get; set; }

    public ClienteController()
    {
        ClienteApplication = new ClienteApplication();
    }
    
    [HttpPost]
    public IActionResult Add(ClienteVM cliente)
    {
        try
        {
            ClienteApplication.Add(cliente);

            return StatusCode((int)ClienteApplication.StatusCode, ClienteApplication.ResponseMessage);
        }
        catch (Exception)
        {
            return BadRequest("Erro ao cadastrar o cliente.");
        }
    }

    [HttpPut]
    public IActionResult Update(ClienteVM cliente)
    {
        try
        {
            ClienteApplication.Update(cliente);

            return Ok();
        }
        catch (Exception)
        {
            return BadRequest("Erro ao atualizar o cliente.");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            ClienteApplication.Delete(id);

            return Ok();
        }
        catch (Exception)
        {
            return BadRequest("Erro ao excluir o cliente.");
        }
    }

    [HttpGet]
    [Route("GetAll")]
    public IActionResult GetAll()
    {
        try
        {
            var clientes = ClienteApplication.GetAll();

            return StatusCode(200, new { Quantidade = clientes.Count, Clientes = clientes });
        }
        catch (Exception)
        {
            return BadRequest("Erro recuperar os clientes.");
        }
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            var cliente = ClienteApplication.Get(id);

            return StatusCode(200, cliente);
        }
        catch (Exception)
        {
            return BadRequest("Erro recuperar o cliente.");
        }
    }
}
