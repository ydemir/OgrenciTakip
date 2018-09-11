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

namespace OgrenciTakip.UI.Win.Forms.AileBilgiForms
{
    public partial class AileBilgiListForm : BaseListForm
    {
        public AileBilgiListForm()
        {
            InitializeComponent();

            Bll = new AileBilgiBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = COMMON.Enums.KartTuru.AileBilgi;
            FormShow = new ShowEditForms<AileBilgiEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((AileBilgiBll)Bll).List(FilterFunctions.Filter<AileBilgi>(AktifKartlariGoster));
        }
    }
}