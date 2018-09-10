using OgrenciTakip.BLL.Base;
using OgrenciTakip.BLL.Interfaces;
using OgrenciTakip.COMMON.Enums;
using OgrenciTakip.MODEL.Entities;
using System.Windows.Forms;

namespace OgrenciTakip.BLL.General
{
    public class IlceBll : BaseGenelBll<Ilce>, IBaseCommonDll
    {
        public IlceBll(): base(KartTuru.Ilce) { }

        public IlceBll(Control ctrl) : base(ctrl, KartTuru.Ilce) { }

      
    }
}
