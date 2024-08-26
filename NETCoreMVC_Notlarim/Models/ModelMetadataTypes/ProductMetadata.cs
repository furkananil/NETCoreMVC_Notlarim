using System.ComponentModel.DataAnnotations;

namespace NETCoreMVC_Notlarim.Models.ModelMetadataTypes
{
    public class ProductMetadata
    {
        [Required(ErrorMessage = "LUTFEN PRODUCT NAME GIRINIZ")]//ATTIRBUTES
        [StringLength(100, ErrorMessage = "PRODUCT NAME EN FAZLA 100 KARAKTER OLABILIR")]
        public string ProductName { get; set; }
        [EmailAddress(ErrorMessage = "LUTFEN EMAIL FORMATINDA VERI GIRINIZ")]
        public string Email { get; set; }
    }
}
