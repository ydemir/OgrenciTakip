using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
   public class MyEmailTextEdit:MyTextEdit
    {
        public MyEmailTextEdit()
        {
            Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            Properties.Mask.EditMask = @"((([0-9a-zA-Z_%-])+[.])+|([0-9a-zA-Z_%-])+)+@((([0-9a-zA-Z_-])+[.])+|([0-9a-zA-Z_-])+)+";
            Properties.Mask.AutoComplete = DevExpress.XtraEditors.Mask.AutoCompleteType.Strong;
            StatusBarAciklama = "Email Adresi Giriniz";
        }
    }
}
