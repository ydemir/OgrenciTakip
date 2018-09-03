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

namespace OgrenciTakip.UI.Win.Forms.OkulForms
{
    public partial class OkulListForm : BaseListForm
    {
        public OkulListForm()
        {
            InitializeComponent();
            Bll = new OkulBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            kartTuru = COMMON.Enums.KartTuru.Okul;
            FormShow = new ShowEditForms<OkulEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            Tablo.GridControl.DataSource=((OkulBll)Bll).List(FilterFunctions.Filter<Okul>(AktifKartlariGoster));
        }
    }
}