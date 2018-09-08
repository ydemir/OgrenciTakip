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
  public  class Filtre :BaseEntity
    {
        //unik yapmadık cünkü içe kodları unik değil
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }
        [Required,StringLength(100),ZorunluAlan("Filtre Adı","txtFiltreAdi")]
        public string FiltreAdi { get; set; }
        [Required,StringLength(1000), ZorunluAlan("Filtre Metni", "txtFiltreMetni")]
        public string FiltreMetni { get; set; }
        [Required]
        public KartTuru KartTuru { get; set; }
    }
}
