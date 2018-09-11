using OgrenciTakip.MODEL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.BLL.Interfaces
{
  public  interface IBaseCommonBll
    {
        bool Delete(BaseEntity entity);
    }
}
