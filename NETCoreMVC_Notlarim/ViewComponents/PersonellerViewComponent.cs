using Microsoft.AspNetCore.Mvc;
using NETCoreMVC_Notlarim.Models;

namespace NETCoreMVC_Notlarim.ViewComponents
{
    public class PersonellerViewComponent : ViewComponent
    {
        //VIEWCOMPONENTIN IMZASI BU SEKILDE OLMALIDIR
        public IViewComponentResult Invoke()
        {
            List<Personel> data = new() 
            {
                new Personel { Adi = "Furkan" , Soyadi = "5"},
                new Personel { Adi = "Furkan" , Soyadi = "0"},
                new Personel { Adi = "Furkan" , Soyadi = "1"},
                new Personel { Adi = "Furkan" , Soyadi = "2"},
                new Personel { Adi = "Furkan" , Soyadi = "3"},
                new Personel { Adi = "Furkan" , Soyadi = "4"}
            };

            return View(data);
        }
    }
}
