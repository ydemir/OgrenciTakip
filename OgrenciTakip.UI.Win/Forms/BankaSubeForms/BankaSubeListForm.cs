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
using OgrenciTakip.UI.Win.Show;

namespace OgrenciTakip.UI.Win.Forms.BankaSubeForms
{
    public partial class BankaSubeListForm :BaseListForm
    {
        private readonly long _bankaId;
        private readonly string _bankaAdi;
        public BankaSubeListForm(params object[] prm)
        {
            InitializeComponent();

            Bll = new BankaSubeBll();

            _bankaId = (long)prm[0];
            _bankaAdi = prm[1].ToString();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = COMMON.Enums.KartTuru.BankaSube;
            //FormShow = new ShowEditForms<IlEditForm>();
            Navigator = longNavigator.Navigator;
            Text = Text + $"- ( {_bankaAdi} )";
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((BankaSubeBll)Bll).List(x => x.Durum == AktifKartlariGoster && x.BankaId == _bankaId);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<BankaSubeEditForm>.ShowDialogEditForm(COMMON.Enums.KartTuru.BankaSube, id, _bankaId, _bankaAdi);

            ShowEditFormDefault(result);
        }
    }
}