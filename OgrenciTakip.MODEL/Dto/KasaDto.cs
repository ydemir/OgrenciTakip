using OgrenciTakip.MODEL.Entities;
using OgrenciTakip.MODEL.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.MODEL.Dto
{
    [NotMapped]
   public class KasaS:Kasa
    {
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }

    }

    public class KasaL : BaseEntity
    {
        public string KasaAdi { get; set; }
        public string OzelKod1Adi { get; set; }
        public string OzelKod2Adi { get; set; }
        public string Aciklama { get; set; }
    }
}
