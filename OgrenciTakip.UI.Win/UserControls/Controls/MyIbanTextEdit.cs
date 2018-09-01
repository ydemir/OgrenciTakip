using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
   public class MyIbanTextEdit :MyTextEdit
    {
        public MyIbanTextEdit()
        {
            Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Regular;
            Properties.Mask.EditMask = @"TR\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?\d?\d? \d?\d?";
            Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.None;
            StatusBarAciklama = "Iban No Giriniz.";
        }
    }
}
