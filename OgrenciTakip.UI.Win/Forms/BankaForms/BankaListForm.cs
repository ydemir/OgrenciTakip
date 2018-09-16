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
using OgrenciTakip.UI.Win.Functions;
using OgrenciTakip.MODEL.Entities;
using DevExpress.XtraBars;

namespace OgrenciTakip.UI.Win.Forms.BankaForms
{
    public partial class BankaListForm : BaseListForm
    {
        public BankaListForm()
        {
            InitializeComponent();

            Bll = new BankaBll();

            btnBagliKartlar.Caption = "Şube Kartları";
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = COMMON.Enums.KartTuru.Banka;
            FormShow = new ShowEditForms<BankaEditForm>();
            Navigator = longNavigator.Navigator;

            if (IsMdiChild)
            {
                ShowItems = new BarItem[] { btnBagliKartlar };
            }

        }

        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((BankaBll)Bll).List(FilterFunctions.Filter<Banka>(AktifKartlariGoster));
        }

        //protected override void BagliKartAc()
        //{

        //    var entity = Tablo.GetRow<Il>();
        //    if (entity == null)
        //    {
        //        return;
        //    }
        //    ShowListForms<IlceListForm>.ShowListForm(COMMON.Enums.KartTuru.Ilce, entity.Id, entity.IlAdi);
        //}
    }
}