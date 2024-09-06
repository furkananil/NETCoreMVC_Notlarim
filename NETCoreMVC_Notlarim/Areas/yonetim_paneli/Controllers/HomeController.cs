using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NETCoreMVC_Notlarim.Areas.yonetim_paneli.Controllers
{
    public class HomeController : Controller
    {
        //AREA ICERISINDEKI CONTROLLER AREA ATTRIBUTEU ILE ISARETLENMELIDIR
        [Area("yonetim_paneli")]
        public IActionResult Index()
        {
            TempData["data"] = "furkan...";
            return RedirectToAction("Index","Home",new {area = "fatura_yonetimi"});
        }

        // AREALAR ARASI BAGLANTI OLUSTURMA ; 

        //@Html.ActionLink("Yonetim","Index","Home", new {area = "yonetim"})
        //<a href = "@Url.Action("Index","Controller", new {area = "yonetim"})"> yonetim</a>
        //<a asp-action="Index" asp-controller="Home" asp-area="yonetim"> yonetim</a>

    }
}
