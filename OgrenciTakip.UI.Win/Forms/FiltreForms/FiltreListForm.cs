using OgrenciTakip.UI.Win.Forms.BaseForms;
using OgrenciTakip.BLL.General;
using OgrenciTakip.UI.Win.Show;
using DevExpress.XtraGrid;
using OgrenciTakip.COMMON.Enums;
using DevExpress.XtraBars;

namespace OgrenciTakip.UI.Win.Forms.FiltreForms
{
    public partial class FiltreListForm : BaseListForm
    {
        private readonly KartTuru _filtreKartTuru;
        private readonly GridControl _filtreGrid;
       
        public FiltreListForm(params object[] prm)
        {
            InitializeComponent();
            Bll = new FiltreBll();

            _filtreKartTuru = (KartTuru)prm[0];
            _filtreGrid =(GridControl)prm[1];

            HideItems =new BarItem[] {btnFiltrele,btnKolonlar,btnYazdir,btnGonder,barFiltrele,barFiltreleAciklama,barKolonlar,barKolonlarAciklama,barYazdir,barYazdirAciklama,barGonder,barGonderAciklama };
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = COMMON.Enums.KartTuru.Filtre;
            //FormShow = new ShowEditForms<IlEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((FiltreBll)Bll).List(x=>x.KartTuru==_filtreKartTuru);
        }
        protected override void ShowEditForm(long id)
        {
            var result = new ShowEditForms<FiltreEditForm>().ShowDialogEditForm(COMMON.Enums.KartTuru.Filtre, id, _filtreKartTuru, _filtreGrid);

            ShowEditFormDefault(result);
        }

    }
}