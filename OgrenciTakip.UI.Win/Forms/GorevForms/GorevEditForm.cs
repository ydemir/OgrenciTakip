using OgrenciTakip.UI.Win.Forms.BaseForms;
using OgrenciTakip.BLL.General;
using OgrenciTakip.MODEL.Entities;
using OgrenciTakip.UI.Win.Functions;

namespace OgrenciTakip.UI.Win.Forms.GorevForms
{
    public partial class GorevEditForm : BaseEditForm
    {
        public GorevEditForm()
        {
            InitializeComponent();

            DataLayoutControl = myDataLayoutControl;
            Bll = new GorevBll(myDataLayoutControl);
            BaseKartTuru = COMMON.Enums.KartTuru.Gorev;

            EventsLoad();
        }

        protected internal override void Yukle()
        {
            OldEntity = BaseIslemTuru == COMMON.Enums.IslemTuru.EntityInsert ? new Gorev() : ((GorevBll)Bll).Single(FilterFunctions.Filter<Gorev>(Id));
            NesneyiControllereBagla();

            if (BaseIslemTuru != COMMON.Enums.IslemTuru.EntityInsert)
            {
                return;
            }
            Id = BaseIslemTuru.IdOlustur(OldEntity);
            txtKod.Text = ((GorevBll)Bll).YeniKodVer();
            txtGorevAdi.Focus();
        }
        protected override void NesneyiControllereBagla()
        {
            var entity = (Gorev)OldEntity;
            txtGorevAdi.Text = entity.GorevAdi;
            txtKod.Text = entity.Kod;
            txtAciklama.Text = entity.Aciklama;
            tglDurum.IsOn = entity.Durum;
        }
        protected override void GuncelNesneOlustur()
        {
            CurrentEntity = new Gorev
            {
                Id = Id,
                Kod = txtKod.Text,
                GorevAdi = txtGorevAdi.Text,
                Aciklama = txtAciklama.Text,
                Durum = tglDurum.IsOn
            };

            ButtonEnabledDurumu();
        }
    }
}