using Microsoft.AspNetCore.Mvc;

namespace NETCoreMVC_Notlarim.Areas.fatura_paneli.Controllers
{
    public class HomeController : Controller
    {
        [Area("fatura_yonetimi")]
        public IActionResult Index()
        {
            var data = TempData["data"];
            return View();
        }
    }
}
