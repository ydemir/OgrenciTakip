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
    public class IlBll : BaseBll<Il, OgrenciTakipContext>,IBaseGenelBll
    {
        public IlBll() { }

        public IlBll(Control ctrl):base(ctrl) { }

        public BaseEntity Single(Expression<Func<Il, bool>> filter)
        {
            return BaseSingle(filter, x => new Il
            {
                Id = x.Id,
                Kod = x.Kod,
                IlAdi = x.IlAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum

            });
        }

        public IEnumerable<BaseEntity> List(Expression<Func<Il, bool>> filter)
        {
            return BaseList(filter, x => new Il
            {
                Id = x.Id,
                Kod = x.Kod,
                IlAdi = x.IlAdi,
                Aciklama = x.Aciklama
                //IQuerable olduğu için sql sorgusu gelir bu yüzden aşağıdaki kodu ekleyip list olarak kod a göre getiriyoruz.
                //BaseBll deki methodda tolist dememizin nedeni iquerable dönüyor. veritabanından çekmeden kod a göre sırala çek dedik
            }).OrderBy(x => x.Kod).ToList();
        }

        public bool Insert(BaseEntity entity)
        {
            return BaseInsert(entity, x => x.Kod == entity.Kod);
        }

        public bool Update(BaseEntity oldEntity, BaseEntity currentEntity)
        {
            return BaseUpdate(oldEntity, currentEntity, x => x.Kod == currentEntity.Kod);
        }

        public bool Delete(BaseEntity entity)
        {
            return BaseDelete(entity, COMMON.Enums.KartTuru.Il);
        }

        public string YeniKodVer()
        {
            return BaseYeniKodVer(COMMON.Enums.KartTuru.Il, x => x.Kod);
        }
    }
}
