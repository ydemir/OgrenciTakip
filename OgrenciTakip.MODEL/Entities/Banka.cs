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
   public class Banka :BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Banka Adı", "txtBankaAdi")]
        public string BankaAdi { get; set; }

        public long? OzelKod1Id { get; set; }
        public long? OzelKod2Id { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }


        public OzelKod OzelKod1 { get; set; }
        public OzelKod OzelKod2 { get; set; }

    }
}
