using Microsoft.AspNetCore.Mvc;

namespace NossaLoja.Web.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Url = "https://localhost:44362";
        return View();
    }
}
