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

namespace OgrenciTakip.UI.Win.Forms.TesvikForms
{
    public partial class TesvikEditForm :BaseEditForm
    {
        public TesvikEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new TesvikBll(myDataLayoutControl);
            BaseKartTuru = COMMON.Enums.KartTuru.Tesvik;

            EventsLoad();
        }

        protected internal override void Yukle()
        {
            OldEntity = BaseIslemTuru == COMMON.Enums.IslemTuru.EntityInsert ? new Tesvik() : ((TesvikBll)Bll).Single(FilterFunctions.Filter<Tesvik>(Id));
            NesneyiControllereBagla();

            if (BaseIslemTuru != COMMON.Enums.IslemTuru.EntityInsert)
            {
                return;
            }
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((TesvikBll)Bll).YeniKodVer();
            txtTesvikAdi.Focus();
        }
        protected override void NesneyiControllereBagla()
        {
            var entity = (Tesvik)OldEntity;
            txtTesvikAdi.Text = entity.TesvikAdi;
            txtKod.Text = entity.Kod;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Tesvik
            {
                Id = Id,
                Kod = txtKod.Text,
                TesvikAdi = txtTesvikAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButtonEnabledDurumu();
        }
    }
}