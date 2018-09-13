using System.Windows.Forms;
using OgrenciTakip.BLL.Base;
using OgrenciTakip.BLL.Interfaces;
using OgrenciTakip.COMMON.Enums;
using OgrenciTakip.MODEL.Entities;

namespace OgrenciTakip.BLL.General
{
    public class RehberBll : BaseGenelBll<Rehber>, IBaseGenelBll, IBaseCommonBll
    {
        public RehberBll() : base(KartTuru.Rehber)
        {
        }

        public RehberBll(Control ctrl) : base(ctrl, KartTuru.Rehber)
        {
        }
    }
}
