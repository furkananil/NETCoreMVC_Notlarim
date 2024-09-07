using System.ComponentModel.DataAnnotations;

namespace NETCoreMVC_Notlarim.Models.ViewModels
{
    public class PersonelCreateVM
    {
        //VIEWMODELDA SADECE TASINACAK VERININ PROPLARI TEMSIL EDILIR
        //GELEN VERILER VIEWMODELDE VALIDATION EDILMELIDIR
        [Required]
        public string Adi { get; set; }
        [Required]
        public string Soyadi { get; set; }
    }
}
