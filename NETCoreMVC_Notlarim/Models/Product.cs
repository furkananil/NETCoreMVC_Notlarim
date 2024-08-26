using Microsoft.AspNetCore.Mvc;
using NETCoreMVC_Notlarim.Models.ModelMetadataTypes;
using System.ComponentModel.DataAnnotations;

namespace NETCoreMVC_Notlarim.Models
{
    [ModelMetadataType(typeof(ProductMetadata))] //BU SINIFIN VALIDATIONLARI PRODUCTMETADATADAN ALINACAKTIR
    public class Product
    { //VIEWMODEL YA DA ENTITYDE VALIDATION TANIMLAMAK YERINE MODELMETADATATYPEDA KULLANMAK SOLID PRENSIPLERINE GORE DAHA DOGRUDUR
        
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public string Email { get; set; }
    }
}
