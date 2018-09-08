using OgrenciTakip.MODEL.Attributes;
using OgrenciTakip.MODEL.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OgrenciTakip.MODEL.Entities
{
    public class Okul :BaseEntityDurum
    {
        //İndex oluşturduk isUnuqie ile kod alanına bir tane girilecek Okul 1 den iki tane girilemeyecek
        [Index("IX_Kod",IsUnique =true)]
        //Kod alanının daha hızlı gelmesi için index uyguluyoruz. 
        public override string Kod { get ; set; }

        [Required,StringLength(50), ZorunluAlan("Okul Adı", "txtOkulAdi")]
        public string OkulAdi { get; set; }

        [ZorunluAlan("İl Adı","txtIl")]
        public long IlId { get; set; }
        [ZorunluAlan("İlçe Adı", "txtIlce")]
        public long IlceId { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public Il Il { get; set; }
        public Ilce Ilce { get; set; }

    }
}
