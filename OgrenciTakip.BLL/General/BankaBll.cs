using OgrenciTakip.BLL.Base;
using OgrenciTakip.BLL.Interfaces;
using OgrenciTakip.COMMON.Enums;
using OgrenciTakip.MODEL.Dto;
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
    public class BankaBll : BaseGenelBll<Banka>, IBaseGenelBll, IBaseCommonBll
    {
        public BankaBll() : base(KartTuru.Banka)
        {
        }

        public BankaBll(Control ctrl) : base(ctrl, KartTuru.Banka)
        {
        }

        public override BaseEntity Single(Expression<Func<Banka, bool>> filter)
        {
            return BaseSingle(filter, x => new BankaS
            {
                Id = x.Id,
                Kod = x.Kod,
                BankaAdi = x.BankaAdi,
                OzelKod1Id = x.OzelKod1Id,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Id = x.OzelKod2Id,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
               
                Aciklama = x.Aciklama,
                Durum = x.Durum

            });
        }

        public override IEnumerable<BaseEntity> List(Expression<Func<Banka, bool>> filter)
        {
            return BaseList(filter, x => new BankaL
            {
                Id = x.Id,
                Kod = x.Kod,
                BankaAdi = x.BankaAdi,
                OzelKod1Adi = x.OzelKod1.OzelKodAdi,
                OzelKod2Adi = x.OzelKod2.OzelKodAdi,
                Aciklama = x.Aciklama
            }).OrderBy(x => x.Kod).ToList();
        }
    }
}
