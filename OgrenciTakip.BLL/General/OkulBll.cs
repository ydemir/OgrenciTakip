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
using OgrenciTakip.COMMON.Enums;

namespace OgrenciTakip.BLL.General
{
    public class OkulBll : BaseGenelBll<Okul>,IBaseGenelBll, IBaseCommonDll
    {
        public OkulBll(): base(KartTuru.Okul) { }

        public OkulBll(Control ctrl) : base(ctrl,KartTuru.Okul) { }

        public override BaseEntity Single(Expression<Func<Okul, bool>> filter)
        {
            return BaseSingle(filter, x => new OkulS
            {
                Id = x.Id,
                Kod = x.Kod,
                OkulAdi = x.OkulAdi,
                IlId = x.IlId,
                IlAdi = x.Il.IlAdi,
                IlceId = x.IlceId,
                IlceAdi = x.Ilce.IlceAdi,
                Aciklama = x.Aciklama,
                Durum = x.Durum

            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Okul, bool>> filter)
        {
            return BaseList(filter, x => new OkulL
            {
                Id = x.Id,
                Kod = x.Kod,
                OkulAdi = x.OkulAdi,
                IlAdi = x.Il.IlAdi,
                IlceAdi = x.Ilce.IlceAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }

     
    }
}
