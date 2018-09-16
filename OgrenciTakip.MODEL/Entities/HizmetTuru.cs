using OgrenciTakip.COMMON.Enums;
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
  public  class HizmetTuru :BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Hizmet Türü Adı", "txtHizmetTuruAdi")]
        public string HizmetTuruAdi { get; set; }

        public HizmetTipi HizmetTipi { get; set; } = HizmetTipi.Egitim;

        [StringLength(500)]
        public string Aciklama { get; set; }
    }
}
