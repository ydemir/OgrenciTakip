using OgrenciTakip.BLL.Base;
using OgrenciTakip.BLL.Interfaces;
using OgrenciTakip.DATA.Contexts;
using OgrenciTakip.MODEL.Entities;
using OgrenciTakip.MODEL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciTakip.BLL.General
{
   public class FiltreBll : BaseBll<Filtre, OgrenciTakipContext>, IBaseCommonDll
    {
        public FiltreBll()
        {

        }

        public FiltreBll(Control ctrl):base(ctrl)
        {

        }

        public BaseEntity Single(Expression<Func<Filtre, bool>> filter)
        {
            //Bütün alanlarla birlikte geri getir
            return BaseSingle(filter, x => x);
        }

        public IEnumerable<BaseEntity> List(Expression<Func<Filtre, bool>> filter)
        {
            return BaseList(filter, x => x).OrderBy(x => x.Kod).ToList();
        }

        public bool Insert(BaseEntity entity, Expression<Func<Filtre, bool>> filter)
        {
            return BaseInsert(entity, filter);
        }

        public bool Update(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<Filtre, bool>> filter)
        {
            return BaseUpdate(oldEntity, currentEntity, filter);
        }

        public bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, COMMON.Enums.KartTuru.Filtre);
        }

        public string YeniKodVer(Expression<Func<Filtre, bool>> filter)
        {
            return BaseYeniKodVer(COMMON.Enums.KartTuru.Ilce, x => x.Kod, filter);
        }
    }
}
