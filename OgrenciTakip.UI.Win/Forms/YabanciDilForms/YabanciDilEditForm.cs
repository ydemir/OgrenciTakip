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

namespace OgrenciTakip.UI.Win.Forms.YabanciDilForms
{
    public partial class YabanciDilEditForm : BaseEditForm
    {
        public YabanciDilEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new YabanciDilBll(myDataLayoutControl);
            BaseKartTuru = COMMON.Enums.KartTuru.YabanciDil;

            EventsLoad();
        }

        protected internal override void Yukle()
        {
            OldEntity = BaseIslemTuru == COMMON.Enums.IslemTuru.EntityInsert ? new YabanciDil() : ((YabanciDilBll)Bll).Single(FilterFunctions.Filter<YabanciDil>(Id));
            NesneyiControllereBagla();

            if (BaseIslemTuru != COMMON.Enums.IslemTuru.EntityInsert)
            {
                return;
            }
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((YabanciDilBll)Bll).YeniKodVer();
            txtDilAdi.Focus();
        }
        protected override void NesneyiControllereBagla()
        {
            var entity = (YabanciDil)OldEntity;
            txtDilAdi.Text = entity.DilAdi;
            txtKod.Text = entity.Kod;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new YabanciDil
            {
                Id = Id,
                Kod = txtKod.Text,
                DilAdi = txtDilAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButtonEnabledDurumu();
        }
    }
}