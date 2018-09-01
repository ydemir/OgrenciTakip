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
   public class MyKodTexEdit :MyTextEdit
    {
        public MyKodTexEdit()
        {
            Properties.Appearance.BackColor = Color.PaleGoldenrod;
            Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            Properties.MaxLength = 20;
            StatusBarAciklama = "Kod Giriniz.";
        }
    }
}
