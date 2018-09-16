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
   public class Kasa :BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = false)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Kasa Adı", "txtKasaAdi")]
        public string KasaAdi { get; set; }

        public long? OzelKod1Id { get; set; }
        public long? OzelKod2Id { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }

        public long SubeId { get; set; }

        public long DonemId { get; set; }

        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }

        public Sube Sube { get; set; }
        public Donem Donem { get; set; }
    }
}
