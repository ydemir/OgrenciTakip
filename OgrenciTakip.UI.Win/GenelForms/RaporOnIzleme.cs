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
using DevExpress.XtraPrinting;

namespace OgrenciTakip.UI.Win.GenelForms
{
    public partial class RaporOnIzleme : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public RaporOnIzleme(params object [] prm)
        {
            InitializeComponent();

            raporGosterici.PrintingSystem = (PrintingSystem)prm[0];
            Text = $"{Text} ( {prm[1].ToString()} )";
        }
    }
}