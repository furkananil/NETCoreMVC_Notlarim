using Microsoft.AspNetCore.Mvc;
using NETCoreMVC_Notlarim.Models;

namespace NETCoreMVC_Notlarim.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetProducts()
        {
            Product product = new Product();

            //ViewResult result = View(""); belirtilen view ismindeki view dosyasını render eder.
            //return result;
            return View();
        }
    }
}
