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
        Tesvik = 8,
        [Description("Kontenjan Kartları")]
        Kontenjan = 9,
        [Description("Rehber Kartları")]
        Rehber = 10,
        [Description("Sınıf Grup Kartları")]
        SinifGrup = 11,
        [Description("Meslek Grup Kartları")]
        Meslek = 12,
        [Description("Yakınlık Kartları")]
        Yakinlik = 13,
        [Description("İşyeri Kartı")]
        Isyeri = 14,
        [Description("Görev Kartı")]
        Gorev = 15,
        [Description("İndirim Türü Kartı")]
        IndirimTuru = 16,
        [Description("Evrak Kartı")]
        Evrak = 17,
    }

}
