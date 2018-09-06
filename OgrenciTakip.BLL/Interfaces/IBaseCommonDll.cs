using OgrenciTakip.MODEL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.BLL.Interfaces
{
  public  interface IBaseCommonDll
    {
        bool Delete(BaseEntity entity);
    }
}
