using Microsoft.AspNetCore.Mvc;
using NETCoreMVC_Notlarim.Models;
using NETCoreMVC_Notlarim.Models.ViewModels;
using System.Reflection;
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
                new Product {ProductName="A PRODUCT",Quantity=10},
                new Product {ProductName="B PRODUCT",Quantity=10},
                new Product {ProductName="C PRODUCT",Quantity=10}
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

        //public IActionResult CreateProduct()
        //{
        //    var product = new Product(); //burada olusturdugumuz nesne islenmis olacaktir yeni nesne olusturulmayacaktir.
        //    return View(product);
        //}
        ////[HttpPost]
        ////public IActionResult CreateProduct(string txtProductName,string txtQuantity) 
        ////{
        ////    return View();
        ////}
        //[HttpPost]
        //public IActionResult CreateProduct(Product product)
        //{
        //    return View();
        //}

        //                                   ----KULLANICIDAN VERI ALMA YONTEMLERI----

        //  FORM ILE VERI ALMA                    

        //1
        //[HttpPost]
        //public IActionResult VeriAl(IFormCollection datas)
        //{
        //    var value1 = datas["txtValue1"].ToString();
        //    var value2 = datas["txtValue2"].ToString();
        //    var value3 = datas["txtValue3"].ToString();
        //    return View();
        //}

        //2
        //[HttpPost]
        //public IActionResult VeriAl(string txtValue1, string txtValue2, string txtValue3)
        //{
        //    return View();
        //}

        //3
        //public class Model
        //{
        //    public string txtValue1 { get; set; }
        //    public string txtValue2 { get; set; }
        //    public string txtValue3 { get; set; }
        //}

        //[HttpPost]
        //public IActionResult VeriAl(Model model)
        //{
        //    return View();
        //}

        //4
        //[HttpPost]
        //public IActionResult VeriAl(Product product) //AYNI PROPLARI ICEREN FARKLI BIR SINIFLADA KARSILANABILIR
        //{
        //    return View();
        //}

        //  QUERYSTRING ILE VERI ALMA ; GUVENLIK GEREKTIRMEYEN BILGILERIN URL UZERINDE TASINMASI ICIN KULLANILIR

        //1
        //  localhost/product/verial?a=4&b=furkan
        //public IActionResult VeriAl(string a,string b)
        //{
        //    return View();
        //}

        //2
        //public class QueryString
        //{
        //    public int A { get; set; }
        //    public string B { get; set; }
        //    public IActionResult VeriAl(QueryString qs)
        //}

        //3
        //public IActionResult VeriAl()
        //{
        //    var qs = Request.QueryString; //REQ YAPILAN ENDPOINTE QUERYSTRING PARAMETRESI EKLENIP EKLENMEDIGI ILE ALAKALI BILGI VERIR
        //    var a = Request.Query["a"].ToString(); //QS DEGERLERINI DONER
        //    var b = Request.Query["b"].ToString();
        //    return View();
        //}

        //  ROUTE PARAMETRELERI UZERINDEN VERI ALMA ; QUERYSTRINGDEN BI NEBZEDE OLSUN DAHA GUVENLIDIR

        //1
        //public IActionResult VeriAl(string id) // ROUTEYE GORE ISIM AYNI OLAMAK ZORUNDA {controller}/{action}/{id?}
        //{
        //    var values = Request.RouteValues; //controller,action,id yakalanir
        //    return View();
        //}

        //2
        //public IActionResult VeriAl(string id,string a,string b) //CUSTOMROUTE verial/furkan/anil/1
        //{
        //    return View();
        //}

        //3
        //public class RouteData
        //{
        //    public string A { get; set; }
        //    public string B { get; set; }
        //    public string Id { get; set; }
        //    public IActionResult VeriAl(RouteData datas)
        //}

        //  HEADER UZERINDEN VERI ALMA

        //public IActionResult VeriAl()
        //{
        //    var headers = Request.Headers; //POSTMAN UZERINDEN REQUEST ATTIK.
        //    return View();
        //}

        //  AJAX TABANLI VERI ALMA

        //public class AjaxData
        //{
        //    public string A { get; set; }
        //    public string B { get; set; }
        //}
        //[HttpPost]
        //public IActionResult VeriAl(AjaxData ajaxData)
        //{
        //    return View();
        //}

        //  TUPLE NESNE POST ETME VE YAKALAMA

        //public IActionResult VeriAl()
        //{
        //    var tuple = (new Product(), new User());
        //    return View();
        //}
        //[HttpPost]
        //public IActionResult VeriAl([Bind(Prefix = "Item1")]Product product, [Bind(Prefix = "Item1")] User user)
        //{
        //    return View();
        //}

        //                                   ----VALIDATIONS----

        //[HttpPost]
        //public IActionResult CreateProduct(Product model)
        //{
        //    //if(string.IsNullOrEmpty(model.ProductName) && model.ProductName.Length <= 100)
        //    //{
        //    //    // DOGRULAMALAR IF SWITCH ILE YAPILMAMALIDIR.
        //    //}

        //    //ModelState ; MVC DE BIR TYPEIN DATA ANNOTATIONSLARININ DURUMLARINI KONTROL EDEN VE GERIYE SONUC DONEN BIR PROP

        //    if(!ModelState.IsValid)
        //    {
        //        //LOGLAMA , KULLANICI BILGILENDIRME ,
        //        return View(model);//BUNU YAPARAK ASP-VALIDATION-FOR DAKI ERROR MESSAGEYI ALIR VE EKRANDA GOSTERIR
        //    }

        //    //DOGRULANMAYAN VALIDATIONLARI HATA MESAJI YAKALAMA;
        //    ViewBag.HataMesaji = ModelState.Values.FirstOrDefault(X => X.ValidationState == Microsoft.AspNetCore.Mvc.ModelBinding.ModelValidationState.Invalid).Errors[0].ErrorMessage;

           
        //    return View();
        //}

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
