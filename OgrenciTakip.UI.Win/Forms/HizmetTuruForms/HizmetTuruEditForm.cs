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
using OgrenciTakip.UI.Win.Functions;
using OgrenciTakip.MODEL.Entities;
using OgrenciTakip.COMMON.Functions;
using OgrenciTakip.COMMON.Enums;

namespace OgrenciTakip.UI.Win.Forms.HizmetTuruForms
{
    public partial class HizmetTuruEditForm : BaseEditForm
    {
        public HizmetTuruEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new HizmetTuruBll(myDataLayoutControl);

            txtHizmetTipi.Properties.Items.AddRange(EnumFunctions.GetEnumDescriptionList<HizmetTipi>());
            BaseKartTuru = COMMON.Enums.KartTuru.HizmetTuru;

            EventsLoad();   
        }

        protected internal override void Yukle()
        {
            OldEntity = BaseIslemTuru == COMMON.Enums.IslemTuru.EntityInsert ? new HizmetTuru() : ((HizmetTuruBll)Bll).Single(FilterFunctions.Filter<HizmetTuru>(Id));
            NesneyiControllereBagla();

            if (BaseIslemTuru != COMMON.Enums.IslemTuru.EntityInsert)
            {
                return;
            }
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((HizmetTuruBll)Bll).YeniKodVer();
            txtHizmetTuruAdi.Focus();
        }
        protected override void NesneyiControllereBagla()
        {
            var entity = (HizmetTuru)OldEntity;
            txtHizmetTuruAdi.Text = entity.HizmetTuruAdi;
            txtHizmetTipi.SelectedItem = entity.HizmetTipi.ToName();
            txtKod.Text = entity.Kod;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new HizmetTuru
            {
                Id = Id,
                Kod = txtKod.Text,
                HizmetTuruAdi = txtHizmetTuruAdi.Text,
                HizmetTipi = txtHizmetTipi.Text.GetEnum<HizmetTipi>(),
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButtonEnabledDurumu();
        }
    }
}