using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NETCoreMVC_Notlarim.Models;
using NETCoreMVC_Notlarim.Models.ViewModels;
using NETCoreMVC_Notlarim.Services;

namespace NETCoreMVC_Notlarim.Controllers
{
    public class PersonelController : Controller
    {
        public IMapper Mapper { get; }

        public PersonelController(IMapper mapper)
        {
            Mapper = mapper;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(PersonelCreateVM personelCreateVM)
        {
            //  VIEWMODELI ENTITY MODELE DONUSTURME YONTEMLERI;

            //MANUEL DONUSTURME ;

            //Personel p = new Personel()
            //{
            //    Adi = personelCreateVM.Adi,
            //    Soyadi = personelCreateVM.Soyadi,
            //};

            //IMPLICIT DONUSTURME ;

            //Personel personel = personelCreateVM;
            //PersonelCreateVM vm = personel;

            //EXPLICIT DONUSTURME ;

            //Personel personel = (Personel)personelCreateVM;
            //PersonelCreateVM vm = (PersonelCreateVM)personel;

            //REFLECTION ILE DONUSTURME ; 

            Personel p = TypeConversion.Conversion<PersonelCreateVM, Personel>(personelCreateVM);
            PersonelListeVM l = TypeConversion.Conversion<Personel, PersonelListeVM> (new Personel
            {
                Adi = "furkan",
                Soyadi = "anil"
            });

            //AUTOMAPPER ILE DONUSTURME ;

            Personel p1 = Mapper.Map<Personel>(personelCreateVM);
            PersonelCreateVM p2 = Mapper.Map<PersonelCreateVM>(p1);

            return View();
        }

        public IActionResult Listele()
        {
            List<PersonelListeVM> personeller = new List<Personel>() 
            { 
                new Personel() { Adi = "A", Soyadi= "B"},
                new Personel() { Adi = "A1", Soyadi= "B"},
                new Personel() { Adi = "A2", Soyadi= "B"},
                new Personel() { Adi = "A3", Soyadi= "B"},
                new Personel() { Adi = "A4", Soyadi= "B"},
                new Personel() { Adi = "A5", Soyadi= "B"}
            }.Select(p => new PersonelListeVM()
            {
                Adi = p.Adi,
                Soyadi = p.Soyadi,
                Pozisyon = p.Pozisyon,
            }).ToList();

            return View(personeller);
        }

        public IActionResult Get() 
        {
            var nesne = (new Personel(), new Urun(), new Musteri());
            return View(); 
        }

    }
}
