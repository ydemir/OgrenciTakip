using OgrenciTakip.BLL.Base;
using OgrenciTakip.BLL.Interfaces;
using OgrenciTakip.COMMON.Enums;
using OgrenciTakip.DATA.Contexts;
using OgrenciTakip.MODEL.Entities;
using OgrenciTakip.MODEL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Windows.Forms;

namespace OgrenciTakip.BLL.General
{
    public class IlBll : BaseGenelBll<Il>,IBaseGenelBll,IBaseCommonDll
    {
        public IlBll():base (KartTuru.Il) { }

        public IlBll(Control ctrl):base(ctrl,KartTuru.Il) { }

       
    }
}
