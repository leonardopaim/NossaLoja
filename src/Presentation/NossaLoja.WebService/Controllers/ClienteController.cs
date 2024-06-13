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

    [HttpGet]
    [Route("GetAll")]
    public IActionResult GetAll()
    {
        try
        {
            var clientes = ClienteApplication.GetAll();

            return StatusCode((int)ClienteApplication.StatusCode, new { Clientes = clientes });
        }
        catch (Exception)
        {
            return BadRequest("Erro ao buscar os clientes.");
        }
        
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        try
        {
            var cliente = ClienteApplication.Get(id);

            return StatusCode((int)ClienteApplication.StatusCode, cliente);
        }
        catch (Exception)
        {
            return BadRequest("Erro ao buscar o cliente");
        }
    }

    [HttpPost]
    public IActionResult Add(ClienteVM cliente)
    {
        try
        {
            ClienteApplication.Add(cliente);

            return StatusCode((int)ClienteApplication.StatusCode, $"Add cliente {cliente.Nome}.");
        }
        catch (Exception)
        {
            return BadRequest("Erro ao adicionar o cliente");
        }
    }

    [HttpPut]
    public IActionResult Update(ClienteVM cliente)
    {
        try
        {
            ClienteApplication.Update(cliente);

            return StatusCode((int)ClienteApplication.StatusCode, $"Atualizar cliente {cliente.Nome}.");
        }
        catch (Exception)
        {
            return BadRequest("Erro ao atualizar o cliente");
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        try
        {
            ClienteApplication.Delete(id);

            return StatusCode((int)ClienteApplication.StatusCode, $"Deleta cliente {id}.");
        }
        catch (Exception)
        {
            return BadRequest("Erro ao deletar o cliente");
        }
    }
}
