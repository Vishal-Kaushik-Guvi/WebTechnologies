using Microsoft.AspNetCore.Mvc;

namespace CSharpASPandADO.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
