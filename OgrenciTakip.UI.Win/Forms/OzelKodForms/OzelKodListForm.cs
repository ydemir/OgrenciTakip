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
using OgrenciTakip.COMMON.Enums;
using OgrenciTakip.UI.Win.Show;
using OgrenciTakip.COMMON.Functions;

namespace OgrenciTakip.UI.Win.Forms.OzelKodForms
{
    public partial class OzelKodListForm : BaseListForm
    {
        private readonly OzelKodTuru _ozelKodTuru;
        private readonly KartTuru _ozelKodKartTuru;

        public OzelKodListForm(params object[] prm)
        {
            InitializeComponent();

            Bll = new OzelKodBll();

            _ozelKodTuru = (OzelKodTuru)prm[0];
            _ozelKodKartTuru = (KartTuru)prm[1];
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = COMMON.Enums.KartTuru.OzelKod;
            //FormShow = new ShowEditForms<IlEditForm>();
            Navigator = longNavigator.Navigator;

            Text = $"{Text} - ({_ozelKodTuru.ToName()})";
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((OzelKodBll)Bll).List(x => x.KodTuru==_ozelKodTuru && x.KartTuru==_ozelKodKartTuru);
        }
        protected override void ShowEditForm(long id)
        {
            var result = ShowEditForms<OzelKodEditForm>.ShowDialogEditForm(COMMON.Enums.KartTuru.Filtre, id, _ozelKodTuru, _ozelKodKartTuru);

            ShowEditFormDefault(result);
        }

    }
}