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
   public class Rehber :BaseEntityDurum
    {
        [Index("IX_Kod", IsUnique = true)]
        public override string Kod { get; set; }

        [Required, StringLength(50), ZorunluAlan("Rehber Adı Soyadı", "txtAdiSoyadi")]
        public string AdiSoyadi { get; set; }
        [StringLength(17)]
        public string Telefon1 { get; set; }
        [StringLength(17)]
        public string Telefon2 { get; set; }

        [StringLength(500)]
        public string Aciklama { get; set; }
    }
}
