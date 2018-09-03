using OgrenciTakip.MODEL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.UI.Win.Functions
{
  public  class FilterFunctions
    {
        public static Expression<Func<T,bool>> Filter<T>(bool aktifKartlariGoster) where T : BaseEntityDurum
        {
            return x => x.Durum == aktifKartlariGoster;
        }

        public static Expression<Func<T,bool>> Filter<T>(long id) where T : BaseEntityDurum
        {
            return x => x.Id == id;
        }
    }
}
