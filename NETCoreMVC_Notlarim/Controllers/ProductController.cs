using Microsoft.AspNetCore.Mvc;
using NETCoreMVC_Notlarim.Models;
using NETCoreMVC_Notlarim.Models.ViewModels;
using System.Text.Json;

namespace NETCoreMVC_Notlarim.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index() 
        {
            //                                   ----VERI TASIMA KONTROLLERI----
            // MODEL BAZLI GONDERIM ;
            var products = new List<Product>()
            {
                new Product {Id=1,ProductName="A PRODUCT",Quantity=10},
                new Product {Id=2,ProductName="B PRODUCT",Quantity=10},
                new Product {Id=3,ProductName="C PRODUCT",Quantity=10}
            };
            //return View(products); 

            // VIEWBAG ILE GONDERIM ;
            // VIEWE GONDERILECEK DATAYI DYNAMIC BIR DEGISKENLE TASIMAMIZI SAGLAYAN BIR VERI TASIMA KONTROLUDUR.
            ViewBag.products = products; // ViewBag.x = products;

            // VIEWDATA ILE GONDERIM ;
            // VIEWVBAGDE OLDUGU GIBI ACTIONDAKI DATAYI VIEWE TASIMAMIZI SAGLAYAN KONTROLDUR
            // DATAYI BOXING EDEREK TASIR
            ViewData["products"] = products;

            // TEMPDATA ILE GONDERIM ;
            // VIEWVDATADA OLDUGU GIBI ACTIONDAKI DATAYI VIEWE TASIMAMIZI SAGLAYAN KONTROLDUR
            // DATAYI BOXING EDEREK TASIR
            // ACTIONLAR ARASINDA VERI TASIMAMIZI SAGLAR

            var data = JsonSerializer.Serialize(products);
            TempData["products"] = data;
            return RedirectToAction("Index2");
        }
        public IActionResult Index2() 
        {
            //KOMPLEX TYPE ISE SERIALIZE EDILMESI GEREKLIDIR
            var data = TempData["products"].ToString();
            JsonSerializer.Deserialize<List<Product>>(data);
            return View();
        }
        public IActionResult GetProducts()
        {
            Product product = new Product()
            {
                Id = 1,
                ProductName = "A Product",
                Quantity = 15
            };
            User user = new User()
            {
                Id = 1,
                Name = "furkan",
                LastName = "anil"
            };
            //VIEWMODEL YONTEMI

            //UserProduct userProduct = new UserProduct()
            //{
            //    User = user,
            //    Product = product,
            //};
            //return View(userProduct);

            //TUPLE YONTEMI

            var userProduct = (product, user);

            return View(userProduct);
        }
        
        public IActionResult CreateProduct()
        {
            var product = new Product(); //burada olusturdugumuz nesne islenmis olacaktir yeni nesne olusturulmayacaktir.
            return View(product);
        }
        //[HttpPost]
        //public IActionResult CreateProduct(string txtProductName,string txtQuantity) 
        //{
        //    return View();
        //}
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            return View();
        }

        //                                   ----ACTION TURLERI----

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

        //                              ----NonAction ve NonController Attributeları-----

        // Controller ICERISINDE [NonAction] ILE ISARETLENEN METHODLAR REQUEST ALMAZLAR YANI IS MANTIGI TURUTEN BIR METHODTUR.
        // [NonController] ILE ISARETLENEN Sınıflar REQUEST ALMAZLAR. SADACE BIR SINIF OLURLAR

        //                              ----UrlHelper / HtmlHelper / TagHelper-----

        //  URLHELPER;
        //  Url.Action("index,"product",new { id = 5}); VERILEN CONTROLLER VE ACTIONA AIT URL OLUSTURMAYI SAGLAR
        //  Url.ActionLink("index,"product",new { id = 5}); VERIELN CONTROLLER VE ACTIONA AIT URL OLUSTURMAYI SAGLAR
        //  HOST PORT BILGISINI TASIR.
        //  Url.Content("/site.css"); CSS,SCRIPT GIBI DOSYALARI TARIF ETMEK ICIN KULLANIRIZ.
        //  Url.RouteUrl("Default"); MIMARIDE TANIMLI OLAN ROUTE ISIMLERINE UYGUN BIR SEKILDE URL OLUSTURUR.
        //  Url.ActionContext; O ANKI URLE AIT TUM BILGILERI GETIRIR.

        //  HTMLHELPER;
        //  @Html.Partial("/Views/Product/Index.cshtml") VIEWDEN HEDEF VIEWI RENDER ETMEMIZI SAGLAYAN BIR FONKSIYONDUR
        //  @{Html.RenderPartial("/Views/Product/Index.cshtml");} VIEWDEN HEDEF VIEWI RENDER ETMEMIZI SAGLAYAN BIR FONKSIYONDUR
        //  VOID DONDURDUGU ICIN DAHA HIZLIDIR.
        //  @Html.ActionLink("Anasayfa","Index","Home") a href olusturur.
        //  @Html.TextBox("txtAdi",null, new { style= "background-color:green; color=white;"})

        //  MODELBINDING;
        //  KULLANICININ GIRDIGI DATALARI CONTROLLERDA KENDIMIZE AIT TURLERDE YAKALAMAK ISTEDIGIMIZDE KULLANIRIZ
        //  GONDERILEN DATA TANIMLADIGIMIZ TURE DONUSUR VE ILGILI SINIFIN ISTANCESI UZERINDEN VERIYI YONETIRIZ.



    }
}
