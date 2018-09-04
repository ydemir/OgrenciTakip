using OgrenciTakip.BLL.Base;
using OgrenciTakip.BLL.Interfaces;
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
   public class IlceBll : BaseBll<Ilce, OgrenciTakipContext>
    {
        public IlceBll()
        {

        }

        public IlceBll(Control ctrl)  :base(ctrl)
        {

        }

        public BaseEntity Single(Expression<Func<Ilce, bool>> filter)
        {
            //Bütün alanlarla birlikte geri getir
            return BaseSingle(filter, x => x);
        }

        public IEnumerable<BaseEntity> List(Expression<Func<Ilce, bool>> filter)
        {
            return BaseList(filter, x => x).OrderBy(x => x.Kod).ToList();
        }

        public bool Insert(BaseEntity entity, Expression<Func<Ilce, bool>> filter)
        {
            return BaseInsert(entity,filter);
        }

        public bool Update(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<Ilce, bool>> filter)
        {
            return BaseUpdate(oldEntity, currentEntity, filter);
        }

        public bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, COMMON.Enums.KartTuru.Ilce);
        }

        public string YeniKodVer(Expression<Func<Ilce, bool>> filter)
        {
            return BaseYeniKodVer(COMMON.Enums.KartTuru.Ilce, x => x.Kod,filter);
        }
    }
}
