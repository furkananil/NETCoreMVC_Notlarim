using NETCoreMVC_Notlarim.Models.ViewModels;

namespace NETCoreMVC_Notlarim.Models
{
    public class Personel
    {
        public int Id { get; set; }
        public string Adi { get; set; }
        public string Soyadi { get; set; }
        public string Pozisyon { get; set; }
        public int Maas { get; set; }
        public bool MedeniHal { get; set; }

        //TUR DONUSTURMEK ISTEDIGIMIZ SINIFLARINDAN BIR TANESINDE YAPMAK YETERLI OLACAKTIR

        //IMPLICIT(BILINCSIZ) OPERATOR OVERLOADIN ILE VIEWMODELI ENTITY MODELE DONUSTURME VE TAM TERSI

        //public static implicit operator PersonelCreateVM(Personel model) //PERSONELI PERSONELCREATEVMYE DONUSTURUR
        //{
        //    return new PersonelCreateVM
        //    {
        //        Adi = model.Adi,
        //        Soyadi = model.Soyadi,
        //    };
        //}

        //public static implicit operator Personel(PersonelCreateVM model) //PERSONELCREATEVM PERSONELE DONUSUR
        //{
        //    return new Personel
        //    {
        //        Adi = model.Adi,
        //        Soyadi = model.Soyadi,
        //    };
        //}

        //EXPLICIT(BILINLI) OPERATOR OVERLOADIN ILE VIEWMODELI ENTITY MODELE DONUSTURME VE TAM TERSI

        // TEK FARKI BIZIM BILINCLI BIR SEKILDE KARAR VERMEMIZ GEREKECEKTIR
        public static explicit operator PersonelCreateVM(Personel model) //PERSONELI PERSONELCREATEVMYE DONUSTURUR
        {
            return new PersonelCreateVM
            {
                Adi = model.Adi,
                Soyadi = model.Soyadi,
            };
        }

        public static explicit operator Personel(PersonelCreateVM model) //PERSONELCREATEVM PERSONELE DONUSUR
        {
            return new Personel
            {
                Adi = model.Adi,
                Soyadi = model.Soyadi,
            };
        }
    }
}
