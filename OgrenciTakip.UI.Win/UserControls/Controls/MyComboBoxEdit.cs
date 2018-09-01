using DevExpress.XtraEditors;
using OgrenciTakip.UI.Win.Interfaces;
using System.ComponentModel;
using System.Drawing;

namespace OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
   public class MyComboBoxEdit :ComboBoxEdit,IStatusBarKisaYol
    {
        public MyComboBoxEdit()
        {
            Properties.AppearanceFocused.BackColor = Color.LightCyan;
            Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarKisaYol { get; set; } = "F4";
        public string StatusBarKisaYolAciklama { get; set; }
        public string StatusBarAciklama { get; set; }
    }
}
