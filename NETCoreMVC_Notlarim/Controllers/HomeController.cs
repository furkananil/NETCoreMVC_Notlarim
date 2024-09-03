using Microsoft.AspNetCore.Mvc;

namespace NETCoreMVC_Notlarim.Controllers
{
    //ATTRIBUTE ROUTING

    //[Route("[controller]/[action]")]
    //[Route("anasayfa/[action]")]
    //[Route("anasayfa")]
    public class HomeController : Controller
    {
        //[Route("in")]
        //[Route("in/{id?}")]
        //[Route("in/{id:int?}")]
        //Index(int? id)
        public IActionResult Index()
        {
            //var images = new List<string> { "img1.jpg", "img2.jpg", "img3.jpg" };

            //return View(images);

            ViewBag.Data = new List<string> { "img1.jpg", "img2.jpg", "img3.jpg" };

            object o = new object();
            return View(o);

            //BU DATA LAYOUTA GELECEK ORADAN _SLAYTPARTIALA GELIp =>
            //
            //@model List<string>
            // var m = Model;
            
            // LAYOUTTA
            // <partial name="/Views/Home/Partials/_SlaytPartial.cshtml" model="@ViewBag.Data / >
        }
        public IActionResult Index2()
        {
            return View();
        }
        public IActionResult Index3()
        {
            return View();
        }

        //       CUSTOM ROUTE HANDLER ; HERHANGI BIR BELIRLENMIS ROUTE SEMASININ CONTROLLER
        //  SINIFLARINDAN ZIYADE IS MANTIGINDA KARSILANMASI VE ORADA IS GORUP RESPONSEUN DONULMESI OPERASYONUDUR.
    }
}
