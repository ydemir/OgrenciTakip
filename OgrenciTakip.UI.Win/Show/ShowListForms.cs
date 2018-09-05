using OgrenciTakip.COMMON.Enums;
using OgrenciTakip.MODEL.Entities.Base;
using OgrenciTakip.UI.Win.Forms.BaseForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciTakip.UI.Win.Show
{
   public class ShowListForms<TForm> where TForm:BaseListForm
    {
        public static void ShowListForm (KartTuru kartTuru)
        {
            //Yetki kontrolü yapılacak

            var frm =(TForm) Activator.CreateInstance(typeof(TForm));
            frm.MdiParent = Form.ActiveForm;
            frm.Yukle();
            frm.Show();
        }

        public static BaseEntity ShowDialogListForm(KartTuru kartTuru,long? seciliGelecekId,params object[] prm)
        {
            // yetki kontrolü

            using(var frm = (TForm)Activator.CreateInstance(typeof(TForm), prm))
            {
                frm.seciliGelecekId = seciliGelecekId;
                frm.Yukle();
                frm.ShowDialog();

                return frm.DialogResult == DialogResult.OK ? frm.selectedEntity : null;
            }
        }
    }
}
