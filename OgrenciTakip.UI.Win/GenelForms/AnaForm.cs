using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using OgrenciTakip.UI.Win.Forms.OkulForms;
using OgrenciTakip.UI.Win.Show;
using OgrenciTakip.UI.Win.Forms.IlForms;
using OgrenciTakip.UI.Win.Forms.AileBilgiForms;
using OgrenciTakip.UI.Win.Forms.IptalNedeniForms;
using OgrenciTakip.UI.Win.Forms.YabanciDilForms;

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
        }

      
    }
}