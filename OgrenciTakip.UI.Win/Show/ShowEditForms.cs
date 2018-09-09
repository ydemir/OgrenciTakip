using OgrenciTakip.COMMON.Enums;
using OgrenciTakip.UI.Win.Forms.BaseForms;
using OgrenciTakip.UI.Win.Show.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.UI.Win.Show
{
  public  class ShowEditForms<TForm> :IBaseFormShow where TForm:BaseEditForm 
    {
        public long ShowDialogEditForm(KartTuru kartTuru,long id)//,params object[] prm)
        {
            //Yetki kontrolü

            //showdialog formları disposable olduğu için using ile yapıyoruz.
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm)))
            {
                frm.BaseIslemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
                frm.Id = id;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefreshYapilacak ? frm.Id : 0;

            }
        }

        public static long ShowDialogEditForm(KartTuru kartTuru, long id ,params object[] prm)
        {
            //Yetki kontrolü

            //showdialog formları disposable olduğu için using ile yapıyoruz.
            using (var frm = (TForm)Activator.CreateInstance(typeof(TForm),prm))
            {
                frm.BaseIslemTuru = id > 0 ? IslemTuru.EntityUpdate : IslemTuru.EntityInsert;
                frm.Id = id;
                frm.Yukle();
                frm.ShowDialog();
                return frm.RefreshYapilacak ? frm.Id : 0;

            }
        }
    }
}
