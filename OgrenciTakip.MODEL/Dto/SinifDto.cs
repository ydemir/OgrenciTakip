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
    //Not mapped eklemezsem gidip bunu sinif alanına ekliyor veritabanında
    [NotMapped]
   public class SinifS :Sinif
    {
        public string GrupAdi { get; set; }
    }

    public class SinifL: BaseEntity
    {
        public string SinifAdi { get; set; }
        public string GrupAdi { get; set; }
        public int HedefOgrenciSayisi { get; set; }
        public string Aciklama { get; set; }

        public decimal HedefCiro { get; set; }
    }
}
