using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NETCoreMVC_Notlarim.Models;
using NETCoreMVC_Notlarim.Services;
using NETCoreMVC_Notlarim.Services.Interfaces;

namespace NETCoreMVC_Notlarim.Controllers
{
    //ATTRIBUTE ROUTING

    //[Route("[controller]/[action]")]
    //[Route("anasayfa/[action]")]
    //[Route("anasayfa")]
    public class HomeController : Controller
    {
        //private readonly IConfiguration Config;
        //public HomeController(IConfiguration config)
        //{
        //    Config = config;
        //}

        //OPTIONS PATTERN
        MailInfo _mailInfo; //MailInfo verileri direkt olarak gelir
        public HomeController(IOptions<MailInfo> mailInfo)
        {
            _mailInfo = mailInfo.Value;
        }

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


        //DEPENDENCY INJECTION VE IOC YAPILANMASI

        private readonly ILog _log;

        

        public HomeController(ILog log)
        {
            _log = log;
        }
        public IActionResult Log()
        {
            //ConsoleLog log = new();
            //log.Log();
            // BU SEKILDE HER SEFERINDE NEWLEME YAPMAMAMIZ GEREKMEKTEDIR.

            _log.Log();
            return View();
        }
        //ACTION BAZLI TALEPTE BULUNMA
        //public IActionResult LogAction([FromServices] ILog log)
        //{
        //    log.Log();
        //    return View();
        //}
        //VIEW DOSYALARINDA INJECT ISLEMI ICIN
        // @inject ILog log
        //ILE KULLANABILIRIZ

        // appsettings.json

        //IConfiguration : ASP.NET Core IOC providerinde bulunan bir servistir.
        //BU SERVIS UYGULAMADAKI APPSETTINGS.JSONDEKI HERHANGI BIR KONFIGURASYONU ELDE ETMEMIZI SAGLAYAN ARAYUZDUR
        //CTORDAN DEP. INJ. ILE CEKERIZ
        //public IActionResult appsettings()
        //{
        //    string metin = Config["OrnekMetin"];
        //    var v = Config["Person"]; // OBJENIN ICINDE OBJE OLDUGU ICIN NULL DONER
        //    var v2 = Config["Person:Name"];
        //    var v3 = Config["Person:Surname"];

        //    var v4 = Config.GetSection("Person");
        //    var v5 = Config.GetSection("Person:Name");
        //    var v6 = v5.Value;

        //    var v7 = Config.GetSection("Person").Get(typeof(Person)); 
        //    //appsettings.jsondaki Person verilerini Person classina ilgili proplara aktarir
        //    return View();
        //}

        public IActionResult mailsettings()
        {
            //string host = Config["MailInfo:Host"];
            //string port = Config["MailInfo:Port"];

            //MailInfo mailInfo = Config.GetSection("MailInfo").Get<MailInfo>();
            return View();
        }
    }
}
