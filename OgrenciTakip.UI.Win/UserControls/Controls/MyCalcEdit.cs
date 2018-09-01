using DevExpress.XtraEditors;
using OgrenciTakip.UI.Win.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
   public class MyCalcEdit :CalcEdit,IStatusBarKisaYol
    {
        public MyCalcEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            Properties.EditMask = "n2";
        }

        public override bool EnterMoveNextControl { get; set; }
        public string StatusBarKisaYol { get; set; } = "F4";
        public string StatusBarKisaYolAciklama { get; set; } = "Hesap Makinesi";
        public string StatusBarAciklama { get; set ; }

    }
}
