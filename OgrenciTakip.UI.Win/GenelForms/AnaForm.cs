using DevExpress.XtraBars;
using OgrenciTakip.UI.Win.Forms.OkulForms;
using OgrenciTakip.UI.Win.Show;
using OgrenciTakip.UI.Win.Forms.IlForms;
using OgrenciTakip.UI.Win.Forms.AileBilgiForms;
using OgrenciTakip.UI.Win.Forms.IptalNedeniForms;
using OgrenciTakip.UI.Win.Forms.YabanciDilForms;
using OgrenciTakip.UI.Win.Forms.TesvikForms;
using OgrenciTakip.UI.Win.Forms.KontenjanForms;
using OgrenciTakip.UI.Win.Forms.RehberForms;

namespace OgrenciTakip.UI.Win.GenelForms
{
    public partial class AnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static string DonemAdi = "Dönem Bilgisi Bekleniyor...";
        public static string SubeAdi = "Şube Bilgisi Bekleniyor...";
        public AnaForm()
        {
            InitializeComponent();
            EventsLoad();
        }
    
        private void EventsLoad()
        {
            foreach (var item in ribbonControl.Items)
            {
                switch (item)
                {
                    case BarButtonItem btn:
                        btn.ItemClick += Butonlar_ItemClick;
                        break;
                }
            }
        }

        private void Butonlar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item==btnOkulKartlari)
            {
                ShowListForms<OkulListForm>.ShowListForm(COMMON.Enums.KartTuru.Okul);
                
            }
            else if (e.Item == btnIlKartlari)
            {
                ShowListForms<IlListForm>.ShowListForm(COMMON.Enums.KartTuru.Il);
            }
            else if(e.Item==btnAileBilgiKartlari)
            {
                ShowListForms<AileBilgiListForm>.ShowListForm(COMMON.Enums.KartTuru.AileBilgi);
            }
            else if (e.Item == btnIptalNedeniKartlari)
            {
                ShowListForms<IptalNedeniListForm>.ShowListForm(COMMON.Enums.KartTuru.IptalNedeni);
            }
            else if (e.Item == btnYabanciDilKartlari)
            {
                ShowListForms<YabanciDilListForm>.ShowListForm(COMMON.Enums.KartTuru.YabanciDil);
            }
            else if (e.Item == btnTesvikKartlari)
            {
                ShowListForms<TesvikListForm>.ShowListForm(COMMON.Enums.KartTuru.Tesvik);
            }
            else if (e.Item == btnKontenjanKartlari)
            {
                ShowListForms<KontenjanListForm>.ShowListForm(COMMON.Enums.KartTuru.Kontenjan);
            }
            else if (e.Item == btnRehberKartlari)
            {
                ShowListForms<RehberListForm>.ShowListForm(COMMON.Enums.KartTuru.Rehber);
            }
        }

      
    }
}