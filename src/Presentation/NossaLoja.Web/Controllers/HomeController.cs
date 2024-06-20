using Microsoft.AspNetCore.Mvc;

namespace NossaLoja.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
