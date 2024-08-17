using Microsoft.AspNetCore.Mvc;

namespace NETCoreMVC_Notlarim.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
