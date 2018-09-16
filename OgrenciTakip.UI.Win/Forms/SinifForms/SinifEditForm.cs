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

namespace OgrenciTakip.UI.Win.Forms.SinifForms
{
    public partial class SinifEditForm : BaseEditForm
    {
        public SinifEditForm()
        {
            InitializeComponent();
            DataLayoutControl = myDataLayoutControl;
            Bll = new SinifBll(myDataLayoutControl);
            BaseKartTuru = COMMON.Enums.KartTuru.Sinif;
            EventsLoad();
        }

        protected internal override void Yukle()
        {
            OldEntity = BaseIslemTuru == COMMON.Enums.IslemTuru.EntityInsert ? new SinifS() : ((SinifBll)Bll).Single(FilterFunctions.Filter<Sinif>(Id));
            NesneyiControllereBagla();

            if (BaseIslemTuru != COMMON.Enums.IslemTuru.EntityInsert)
            {
                return;
            }
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((SinifBll)Bll).YeniKodVer(x=>x.SubeId==AnaForm.SubeId);
            txtSinifAdi.Focus();
        }


        protected override void NesneyiControllereBagla()
        {
            var entity = (SinifS)OldEntity;
            txtKod.Text = entity.Kod;
            txtSinifAdi.Text = entity.SinifAdi;
            txtGrup.Id = entity.GrupId;
            txtGrup.Text = entity.GrupAdi;
            txtHedefOgrSayisi.Value = entity.HedefOgrenciSayisi;
            txtHedefCiro.Value = entity.HedefCiro;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;

        }

        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Sinif
            {
                Id = Id,
                Kod = txtKod.Text,
                SinifAdi = txtSinifAdi.Text,
                GrupId =Convert.ToInt64(txtGrup.Id),
                HedefOgrenciSayisi=(int)txtHedefOgrSayisi.Value,
                HedefCiro=txtHedefCiro.Value,
                Aciklama = txtAciklama.Text,
                SubeId=AnaForm.SubeId,
                Durum = tglDurum.IsOn
            };

            ButtonEnabledDurumu();
        }

        protected override bool EntityInsert()
        {
            return ((SinifBll)Bll).Insert(CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId );
        }

        protected override bool EntityUpdate()
        {
            return ((SinifBll)Bll).Update(OldEntity, CurrentEntity, x => x.Kod == CurrentEntity.Kod && x.SubeId == AnaForm.SubeId );
        }

        protected override void SecipYap(object sender)
        {
            if (!(sender is ButtonEdit))
            {
                return;
            }

            using (var sec = new SelectFunctions())
            {
                if (sender == txtGrup)
                {
                    sec.Sec(txtGrup);
                }
             

            }
        }
    }
}