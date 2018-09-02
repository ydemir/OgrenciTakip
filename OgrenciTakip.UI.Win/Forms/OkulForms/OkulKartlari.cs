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

namespace OgrenciTakip.UI.Win.Forms.OkulForms
{
    public partial class OkulKartlari : BaseKartlarForm
    {
        public OkulKartlari()
        {
            InitializeComponent();

            OkulBll bll = new OkulBll();
           grid.DataSource= bll.List(null);
        }
    }
}