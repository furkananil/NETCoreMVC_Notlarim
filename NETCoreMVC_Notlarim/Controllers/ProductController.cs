using Microsoft.AspNetCore.Mvc;
using NETCoreMVC_Notlarim.Models;

namespace NETCoreMVC_Notlarim.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult GetProducts()
        {
            Product product = new Product();
            return View();
        }


        //              ----ACTION TURLERI----

        //public ViewResult GetProducts()
        //{
        //    ViewResult result = View(""); belirtilen view ismindeki view dosyasını render eder.
        //    return result;
        //}
        //public PartialViewResult GetProducts()
        //{
        //    PartialViewResult result = PartialView(""); Client tabanlı ajax calismalari icin uygundur.
        //    return result;
        //}
        //public JsonResult GetProducts()
        //{
        //    JsonResult result = Json(new Product { Id = 1, ProductName = "Product 1", Quantity = 10 });
        //    return result;
        //}
        //public EmptyResult GetProducts()
        //{
        //    //RESPONSE GONDERMEK ISTEMIYORSAK KULLANIRIZ
        //    return new EmptyResult();
        //}
        //public ContentResult GetProducts()
        //{
        //    ContentResult result = Content("sayfayı text dosyasına donusturur");
        //    return result;
        //}
        //public IActionResult GetProducts()
        //{
        //    //IActionResult ve ActionResult ACTION TURLERININ ATASIDIR.
        //    return View();
        //}
        //              ----NonAction ve NonController Attributeları-----

        // Controller ICERISINDE [NonAction] ILE ISARETLENEN METHODLAR REQUEST ALMAZLAR YANI IS MANTIGI TURUTEN BIR METHODTUR.
        // [NonController] ILE ISARETLENEN Sınıflar REQUEST ALMAZLAR. SADACE BIR SINIF OLURLAR
    }
}
