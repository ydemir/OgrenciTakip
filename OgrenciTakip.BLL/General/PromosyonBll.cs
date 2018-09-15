using OgrenciTakip.BLL.Base;
using OgrenciTakip.BLL.Interfaces;
using OgrenciTakip.COMMON.Enums;
using OgrenciTakip.MODEL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciTakip.BLL.General
{
    public class PromosyonBll : BaseGenelBll<Promosyon>, IBaseCommonBll
    {
        public PromosyonBll() : base(KartTuru.Promosyon)
        {
        }

        public PromosyonBll(Control ctrl) : base(ctrl, KartTuru.Promosyon)
        {
        }
    }
}
