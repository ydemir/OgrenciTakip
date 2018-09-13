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
    public class MeslekBll : BaseGenelBll<Meslek>, IBaseGenelBll, IBaseCommonBll
    {
        public MeslekBll() : base(KartTuru.Meslek) { }

        public MeslekBll(Control ctrl) : base(ctrl, KartTuru.Meslek) { }
    }
}
