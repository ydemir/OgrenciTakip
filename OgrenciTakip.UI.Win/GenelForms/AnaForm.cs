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
using OgrenciTakip.UI.Win.Forms.SinifGrupForms;
using OgrenciTakip.UI.Win.Forms.MeslekForms;
using OgrenciTakip.UI.Win.Forms.YakinlikForms;
using OgrenciTakip.UI.Win.Forms.IsyeriForms;
using OgrenciTakip.UI.Win.Forms.GorevForms;
using OgrenciTakip.UI.Win.Forms.IndirimTuruForms;
using OgrenciTakip.UI.Win.Forms.EvrakForms;
using OgrenciTakip.UI.Win.Forms.PromosyonForms;
using OgrenciTakip.UI.Win.Forms.ServisForms;
using OgrenciTakip.UI.Win.Forms.SinifForms;
using OgrenciTakip.UI.Win.Forms.HizmetTuruForms;
using System;
using OgrenciTakip.UI.Win.Forms.HizmetForms;

namespace OgrenciTakip.UI.Win.GenelForms
{
    public partial class AnaForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public static long DonemId = 1;
        public static string DonemAdi = "Dönem Bilgisi Bekleniyor...";
        public static string SubeAdi = "Şube Bilgisi Bekleniyor...";
        public static long SubeId = 1;

        public static DateTime EgitimBaslamaTarihi = new DateTime(2017, 09, 15);
        public static DateTime DonemBitisTarihi = new DateTime(2018, 06, 30);

        public static bool GunTarihininOncesininHizmetBaslamaTarihiGirilebilir = true;
        public static bool GunTarihininSonrasinaHizmetBaslamaTarihiGirilebilir = true;

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
            else if (e.Item == btnSinifGrupKartlari)
            {
                ShowListForms<SinifGrupListForm>.ShowListForm(COMMON.Enums.KartTuru.SinifGrup);
            }
            else if (e.Item == btnMeslekKartlari)
            {
                ShowListForms<MeslekListForm>.ShowListForm(COMMON.Enums.KartTuru.Meslek);
            }
            else if (e.Item == btnYakinlikKartlari)
            {
                ShowListForms<YakinlikListForm>.ShowListForm(COMMON.Enums.KartTuru.Yakinlik);
            }
            else if (e.Item == btnIsyeriKarlari)
            {
                ShowListForms<IsyeriListForm>.ShowListForm(COMMON.Enums.KartTuru.Isyeri);
            }
            else if (e.Item == btnGorevKartlari)
            {
                ShowListForms<GorevListForm>.ShowListForm(COMMON.Enums.KartTuru.Gorev);
            }

            else if (e.Item == btnIndirimTuruKartlari)
            {
                ShowListForms<IndirimTuruListForm>.ShowListForm(COMMON.Enums.KartTuru.IndirimTuru);
            }
            else if (e.Item == btnEvrakKartlari)
            {
                ShowListForms<EvrakListForm>.ShowListForm(COMMON.Enums.KartTuru.Evrak);
            }
            else if (e.Item == btnPromosyonKartlari)
            {
                ShowListForms<PromosyonListForm>.ShowListForm(COMMON.Enums.KartTuru.Promosyon);
            }
            else if (e.Item == btnServisYeriKartlari)
            {
                ShowListForms<ServisListForm>.ShowListForm(COMMON.Enums.KartTuru.Servis);
            }
            else if (e.Item == btnSinifKartlari)
            {
                ShowListForms<SinifListForm>.ShowListForm(COMMON.Enums.KartTuru.Sinif);
            }
            else if (e.Item == btnHizmetTuruKartlari)
            {
                ShowListForms<HizmetTuruListForm>.ShowListForm(COMMON.Enums.KartTuru.HizmetTuru);
            }
            else if (e.Item == btnHizmetKartlari)
            {
                ShowListForms<HizmetListForm>.ShowListForm(COMMON.Enums.KartTuru.Hizmet);
            }
        }

      
    }
}