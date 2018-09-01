using OgrenciTakip.MODEL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.MODEL.Entities
{
   public class Ilce :BaseEntityDurum
    {
        public string IlceAdi { get; set; }
        public long IlId { get; set; }
        public string Aciklama { get; set; }

        public Il Il { get; set; }
    }
}
