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
   public class MyDateEdit :DateEdit ,IStatusBarKisaYol
    {
        public MyDateEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;

            Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.DateTimeAdvancingCaret;
        }

        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisaYol { get; set; } = "F4 :";
        public string StatusBarKisaYolAciklama { get; set; } = "Tarih Seç";
        public string StatusBarAciklama { get; set; }
    }
}
