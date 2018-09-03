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
using OgrenciTakip.COMMON.Enums;

namespace OgrenciTakip.UI.Win.Forms.BaseForms
{
    public partial class BaseEditForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        protected internal IslemTuru IslemTuru;
        protected internal long Id;
        protected internal bool RefreshYapilacak;
        public BaseEditForm()
        {
            InitializeComponent();

         
        }

        protected internal void Yukle() { }


    }
}