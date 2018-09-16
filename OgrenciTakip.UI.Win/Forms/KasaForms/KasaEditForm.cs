using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OgrenciTakip.UI.Win.Forms.BaseForms;
using OgrenciTakip.BLL.General;
using OgrenciTakip.MODEL.Dto;
using OgrenciTakip.UI.Win.Functions;
using OgrenciTakip.MODEL.Entities;
using OgrenciTakip.UI.Win.GenelForms;

namespace OgrenciTakip.UI.Win.Forms.KasaForms
{
    public partial class KasaEditForm : BaseEditForm
    {
        public KasaEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new KasaBll(myDataLayoutControl);
            BaseKartTuru = COMMON.Enums.KartTuru.Kasa;
            EventsLoad();
        }

        protected internal override void Yukle()
        {
            OldEntity = BaseIslemTuru == COMMON.Enums.IslemTuru.EntityInsert ? new KasaS() : ((KasaBll)Bll).Single(FilterFunctions.Filter<Kasa>(Id));
            NesneyiControllereBagla();

            if (BaseIslemTuru != COMMON.Enums.IslemTuru.EntityInsert)
            {
                return;
            }
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((KasaBll)Bll).YeniKodVer(x=>x.SubeId==AnaForm.SubeId && x.DonemId==AnaForm.DonemId);
            txtKasaAdi.Focus();
        }

        protected override void NesneyiControllereBagla()
        {
            var entity = (KasaS)OldEntity;
            txtKod.Text = entity.Kod;
            txtKasaAdi.Text = entity.KasaAdi;
            txtOzelKod1.Id = entity.OzelKod1Id;
            txtOzelKod1.Text = entity.OzelKod1Adi;
            txtOzelKod2.Id = entity.OzelKod2Id;
            txtOzelKod2.Text = entity.OzelKod2Adi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Kasa
            {
                Id = Id,
                Kod = txtKod.Text,
                KasaAdi = txtKasaAdi.Text,
                OzelKod1Id = txtOzelKod1.Id,
                OzelKod2Id=txtOzelKod2.Id,
                SubeId=AnaForm.SubeId,
                DonemId=AnaForm.DonemId,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButtonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            return ((KasaBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }

        protected override bool EntityUpdate()
        {
            return ((KasaBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }

        protected override void SecipYap(object sender)
        {
            if (!(sender is ButtonEdit))
            {
                return;
            }

            using (var sec = new SelectFunctions())
            {
                if (sender == txtOzelKod1)
                {
                    sec.Sec(txtOzelKod1,COMMON.Enums.KartTuru.Kasa);
                }
                if (sender==txtOzelKod2)
                {
                    sec.Sec(txtOzelKod2, COMMON.Enums.KartTuru.Kasa);
                }


            }
        }
    }
}