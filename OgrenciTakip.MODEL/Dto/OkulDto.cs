using OgrenciTakip.MODEL.Entities;
using OgrenciTakip.MODEL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.MODEL.Dto
{
    //veritabanına kayıt olmaması için attribbute ekleyeceğiz.
    //OkulS single ı ifade eder. 
  public  class OkulS:Okul
    {
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
    }
    public class OkulL : BaseEntity
    {
        public string OkulAdi { get; set; }
        public string IlAdi { get; set; }
        public string IlceAdi { get; set; }
        public string Aciklama { get; set; }
    }
}
