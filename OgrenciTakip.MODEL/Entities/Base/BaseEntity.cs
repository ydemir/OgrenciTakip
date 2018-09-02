using OgrenciTakip.MODEL.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.MODEL.Entities.Base
{
   public class BaseEntity :IBaseEntity
    {
        public long Id { get; set; }
        public string Kod { get; set; }

    }
}
