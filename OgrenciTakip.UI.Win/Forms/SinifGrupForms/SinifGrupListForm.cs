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

namespace OgrenciTakip.UI.Win.Forms.SinifGrupForms
{
    public partial class SinifGrupListForm : BaseListForm
    {
        public SinifGrupListForm()
        {
            InitializeComponent();
            Bll = new SinifGrupBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = COMMON.Enums.KartTuru.AileBilgi;
            FormShow = new ShowEditForms<SinifGrupEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((SinifGrupBll)Bll).List(FilterFunctions.Filter<SinifGrup>(AktifKartlariGoster));
        }
    }
}