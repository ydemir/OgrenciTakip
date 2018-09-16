using OgrenciTakip.MODEL.Attributes;
using OgrenciTakip.MODEL.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.MODEL.Entities
{
   public class Hizmet :BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Hizmet Adı", "txtHizmetAdi")]
        public string HizmetAdi { get; set; }

        [ZorunluAlan("Hizmet Türü Adı", "txtHizmetTuru")]
        public long HizmetTuruId { get; set; }

        [Column(TypeName ="date")]
        public DateTime BaslamaTarihi { get; set; }

        [Column(TypeName = "date")]
        public DateTime BitisTarihi { get; set; }

        [Column(TypeName = "money")]
        public decimal Ucret { get; set; }


        [StringLength(500)]
        public string Aciklama { get; set; }



        public long SubeId { get; set; }

        public long DonemId { get; set; }

        public HizmetTuru HizmetTuru { get; set; }
        //EntityFramework Generate aşamasında şube tablosuna alacak ŞubeId oluşturucak Bu tabloda ŞubeId olduğu için iki entity yi birbirine bağlayacak
        public Sube Sube { get; set; }

        public Donem Donem { get; set; }
    }
}
