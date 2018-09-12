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

namespace OgrenciTakip.UI.Win.Forms.TesvikForms
{
    public partial class TesvikListForm : BaseListForm
    {
        public TesvikListForm()
        {
            InitializeComponent();

            Bll = new TesvikBll();
        }

        protected override void DegiskenleriDoldur()
        {
            Tablo = tablo;
            BaseKartTuru = COMMON.Enums.KartTuru.Tesvik;
            FormShow = new ShowEditForms<TesvikEditForm>();
            Navigator = longNavigator.Navigator;
        }

        protected override void Listele()
        {
            tablo.GridControl.DataSource = ((TesvikBll)Bll).List(FilterFunctions.Filter<Tesvik>(AktifKartlariGoster));
        }
    }
}