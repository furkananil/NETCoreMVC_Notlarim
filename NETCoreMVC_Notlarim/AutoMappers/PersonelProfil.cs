using AutoMapper;
using NETCoreMVC_Notlarim.Models;
using NETCoreMVC_Notlarim.Models.ViewModels;

namespace NETCoreMVC_Notlarim.AutoMappers
{
    public class PersonelProfil :Profile
    {
        //AUTOMAPPER ILE DONUSTURME
        public PersonelProfil()
        {
            CreateMap<Personel, PersonelCreateVM>();
            CreateMap<PersonelCreateVM,Personel> ();
        }
    }
}
