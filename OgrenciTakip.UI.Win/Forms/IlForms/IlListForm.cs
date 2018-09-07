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
using OgrenciTakip.UI.Win.Forms.IlceForms;

namespace OgrenciTakip.UI.Win.Forms.IlForms
{
    public partial class IlListForm : BaseListForm
    {
        public IlListForm()
        {
            InitializeComponent();
           
            Bll = new IlBll();
            btnBagliKartlar.Caption = "Ilçe Kartları";
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = COMMON.Enums.KartTuru.Il;
            FormShow = new ShowEditForms<IlEditForm>();
            Navigator = longNavigator.Navigator;

            if (IsMdiChild)
            {
                ShowItems =new BarItem[]{ btnBagliKartlar};
            }
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource = ((IlBll)Bll).List(FilterFunctions.Filter<Il>(AktifKartlariGoster));
        }

        protected override void BagliKartAc()
        {
        
            var entity = Tablo.GetRow<Il>();
            if (entity==null)
            {
                return;
            }
            ShowListForms<IlceListForm>.ShowListForm(COMMON.Enums.KartTuru.Ilce, entity.Id, entity.IlAdi);
        }


    }
}