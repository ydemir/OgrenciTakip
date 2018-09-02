using DevExpress.XtraEditors;
using System.Windows.Forms;

namespace OgrenciTakip.COMMON.Message
{
    public class Messages
    {
        public static void HataMesaji(string hataMesaji)
        {
            XtraMessageBox.Show(hataMesaji, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
