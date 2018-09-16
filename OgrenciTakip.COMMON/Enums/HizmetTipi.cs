using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.COMMON.Enums
{
   public enum HizmetTipi:byte
    {
        [Description("Eğitim")]
        Egitim=1,
        [Description("Yemek")]
        Yemek =2,
        [Description("Servis")]
        Servis =3,
        [Description("Pansiyon")]
        Pansiyon =4,
        [Description("Diğer")]
        Diger =5
    }
}
