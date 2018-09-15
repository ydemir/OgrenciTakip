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
    //IbaseGenelBll yapısına uymadığı için commonbll den implement ettik
    public class ServisBll : BaseGenelBll<Servis>, IBaseCommonBll
    {
        public ServisBll() : base(KartTuru.Servis)
        {
        }

        public ServisBll(Control ctrl) : base(ctrl, KartTuru.Servis)
        {
        }
    }
}
