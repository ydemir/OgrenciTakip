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
using OgrenciTakip.MODEL.Entities;
using OgrenciTakip.UI.Win.Functions;
using OgrenciTakip.UI.Win.GenelForms;

namespace OgrenciTakip.UI.Win.Forms.PromosyonForms
{
    public partial class PromosyonEditForm : BaseEditForm
    {
        public PromosyonEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new PromosyonBll(myDataLayoutControl);
            BaseKartTuru = COMMON.Enums.KartTuru.Promosyon;
            EventsLoad();
        }

        protected internal override void Yukle()
        {
            OldEntity = BaseIslemTuru == COMMON.Enums.IslemTuru.EntityInsert ? new Promosyon() : ((PromosyonBll)Bll).Single(FilterFunctions.Filter<Promosyon>(Id));
            NesneyiControllereBagla();

            if (BaseIslemTuru != COMMON.Enums.IslemTuru.EntityInsert)
            {
                return;
            }
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            //Evrak olarak veritabanına git Oradaki ŞubeID ve DonemId ile sorgulama yap eğer entity geliyorsa Enbuyuk koda sahip olanı al 1 arttır ve bunu kod text e aktar yoksada 001 ile aktar
            //demiş olduk. yenikodver içeriisnde vardır.
            txtKod.Text = ((PromosyonBll)Bll).YeniKodVer(x => x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
            txtPromosyonAdi.Focus();
        }

        protected override void NesneyiControllereBagla()
        {
            var entity = (Promosyon)OldEntity;
            txtKod.Text = entity.Kod;
            txtPromosyonAdi.Text = entity.PromosyonAdi;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Promosyon
            {
                Id = Id,
                Kod = txtKod.Text,
                PromosyonAdi = txtPromosyonAdi.Text,
                SubeId = AnaForm.SubeId,
                DonemId = AnaForm.DonemId,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButtonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            return ((PromosyonBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }

        protected override bool EntityUpdate()
        {
            return ((PromosyonBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId && x.DonemId == AnaForm.DonemId);
        }
    }
}