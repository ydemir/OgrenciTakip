using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.UI.Win.UserControls.Controls
{
   public class MyCardEdit :MyTextEdit
    {
        [ToolboxItem(true)]
        public MyCardEdit()
        {
            Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            Properties.Mask.EditMask = @"\d?\d?\d?\d?-\d?\d?\d?\d?-\d?\d?\d?\d?-\d?\d?\d?\d?";
            Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None;
            StatusBarAciklama = "Kart No Giriniz.";
            
        }
    }
}
