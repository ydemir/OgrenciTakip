using OgrenciTakip.MODEL.Attributes;
using OgrenciTakip.MODEL.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OgrenciTakip.MODEL.Entities
{
    public class Sinif :BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Sinif Adı", "txtSinifAdi")]
        public string SinifAdi { get; set; }

        [ZorunluAlan("Grup Adı","txtGrup")]
        public long GrupId { get; set; }

        public int HedefOgrenciSayisi { get; set; }

        [Column(TypeName ="money")]
        public decimal HedefCiro { get; set; }


        [StringLength(500)]
        public string Aciklama { get; set; }

        public long SubeId { get; set; }

        public SinifGrup Grup { get; set; }
        //EntityFramework Generate aşamasında şube tablosuna alacak ŞubeId oluşturucak Bu tabloda ŞubeId olduğu için iki entity yi birbirine bağlayacak
        public Sube Sube { get; set; }

    }
}
