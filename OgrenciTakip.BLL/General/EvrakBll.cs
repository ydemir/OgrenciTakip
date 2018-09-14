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
    //Genel yapımıza uymadığı için IBaseGenelBll den implement edemiyoruz. Interface yapısına uymuyor o yüzden commonbll den implement ediyoruz.
    public class EvrakBll : BaseGenelBll<Evrak>, IBaseCommonBll
    {
        public EvrakBll() : base(KartTuru.Evrak)
        {
        }

        public EvrakBll(Control ctrl) : base(ctrl, KartTuru.Evrak)
        {
        }
    }
}
