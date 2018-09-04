using OgrenciTakip.BLL.Base;
using OgrenciTakip.DATA.Contexts;
using OgrenciTakip.MODEL.Dto;
using OgrenciTakip.MODEL.Entities;
using OgrenciTakip.MODEL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Windows.Forms;
using System.Linq;
using OgrenciTakip.BLL.Interfaces;

namespace OgrenciTakip.BLL.General
{
    public class OkulBll : BaseBll<Okul, OgrenciTakipContext>,IBaseGenelBll
    {
        public OkulBll() { }

        public OkulBll(Control ctrl) : base(ctrl) { }

        public BaseEntity Single(Expression<Func<Okul,bool>> filter)
        {
            return BaseSingle(filter, x => new OkulS
            {
                Id=x.Id,
                Kod=x.Kod,
                OkulAdi=x.OkulAdi,
                IlId=x.IlId,
                IlAdi=x.Il.IlAdi,
                IlceId=x.IlceId,
                IlceAdi=x.Ilce.IlceAdi,
                Aciklama=x.Aciklama,
                Durum=x.Durum
                
            });
        }

        public IEnumerable<BaseEntity> List(Expression<Func<Okul,bool>> filter)
        {
            return BaseList(filter, x => new OkulL
            {
                Id=x.Id,
                Kod=x.Kod,
                OkulAdi=x.OkulAdi,
                IlAdi=x.Il.IlAdi,
                IlceAdi=x.Ilce.IlceAdi,
                Aciklama=x.Aciklama
                //IQuerable olduğu için sql sorgusu gelir bu yüzden aşağıdaki kodu ekleyip list olarak kod a göre getiriyoruz.
                //BaseBll deki methodda tolist dememizin nedeni iquerable dönüyor. veritabanından çekmeden kod a göre sırala çek dedik
            }).OrderBy(x=>x.Kod).ToList();
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
            return BaseDelete(entity, COMMON.Enums.KartTuru.Okul);
        }

        public string YeniKodVer()
        {
            return BaseYeniKodVer(COMMON.Enums.KartTuru.Okul, x => x.Kod);
        }
    }
}
