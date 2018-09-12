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

namespace OgrenciTakip.UI.Win.Forms.KontenjanForms
{
    public partial class KontenjanListForm : BaseListForm
    {
        public KontenjanListForm()
        {
            InitializeComponent();
            Bll = new KontenjanBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = COMMON.Enums.KartTuru.Kontenjan;
            FormShow = new ShowEditForms<KontenjanEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((KontenjanBll)Bll).List(FilterFunctions.Filter<Kontenjan>(AktifKartlariGoster));
        }
    }
}