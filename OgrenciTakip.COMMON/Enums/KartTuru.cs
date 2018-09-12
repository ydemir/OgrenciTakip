using System.ComponentModel;

namespace OgrenciTakip.COMMON.Enums
{
    public enum KartTuru : byte
    {
        //index vermessek database de 1 den başlayacak
        // descrition kullanıcıya gösterilecek alandır

        [Description("Okul Kartı")]
        Okul = 1,
        [Description("İl Kartı")]
        Il = 2,
        [Description("İlçe Kartı")]
        Ilce = 3,
        [Description("Filtre Kartı")]
        Filtre = 4,
        [Description("Aile Bilgi Kartı")]
        AileBilgi = 5,
        [Description("Iptal Nedeni Kartı")]
        IptalNedeni = 6,
        [Description("Yabancı Dil Kartı")]
        YabanciDil = 7,
        [Description("Teşvik Kartı")]
        Tesvik = 8
    }

}
