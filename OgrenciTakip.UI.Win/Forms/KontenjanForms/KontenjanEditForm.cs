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

namespace OgrenciTakip.UI.Win.Forms.KontenjanForms
{
    public partial class KontenjanEditForm : BaseEditForm
    {
        public KontenjanEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new KontenjanBll(myDataLayoutControl);
            BaseKartTuru = COMMON.Enums.KartTuru.Kontenjan;

            EventsLoad();
        }

        protected internal override void Yukle()
        {
            OldEntity = BaseIslemTuru == COMMON.Enums.IslemTuru.EntityInsert ? new Kontenjan() : ((KontenjanBll)Bll).Single(FilterFunctions.Filter<Kontenjan>(Id));
            NesneyiControllereBagla();

            if (BaseIslemTuru != COMMON.Enums.IslemTuru.EntityInsert)
            {
                return;
            }
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((KontenjanBll)Bll).YeniKodVer();
            txtKontenjanAdi.Focus();
        }
        protected override void NesneyiControllereBagla()
        {
            var entity = (Kontenjan)OldEntity;
            txtKontenjanAdi.Text = entity.KontenjanAdi;
            txtKod.Text = entity.Kod;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Kontenjan
            {
                Id = Id,
                Kod = txtKod.Text,
                KontenjanAdi = txtKontenjanAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButtonEnabledDurumu();
        }
    }
}