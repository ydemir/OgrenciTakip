using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using OgrenciTakip.COMMON.Enums;
using OgrenciTakip.COMMON.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.UI.Win.Functions
{
   public static class GeneralFunctions
    {
        public static long GetRowId(this GridView tablo)
        {
            if (tablo.FocusedRowHandle>-1) 
            {
                return (long)tablo.GetFocusedRowCellValue("Id");
            }
            Messages.KartSecmemeUyariMesaji();

            return -1;
        }

        public static T GetRow<T>(this GridView tablo,bool mesajVer = true)
        {
            if (tablo.FocusedRowHandle>-1)
            {
                return (T)tablo.GetRow(tablo.FocusedRowHandle);
            }
            if (mesajVer)
            {
                Messages.KartSecmemeUyariMesaji();
            }
            return default(T);
        }

        private static VeriDegisimYeri VeriDegisimYeriGetir<T>(T oldEntity,T currentEntity)
        {
          
            //foreach i reflection yaparak dolaşıyoruz.
            foreach (var prop in currentEntity.GetType().GetProperties())
            {
                //Örnek olarak ile bağlı ilçelere ICollection<Ilce> Ilce get set ile ulaşabiliyoruz.
                //Entity de dolaşırken aşağıdaki property gelecek eğer aşağıdaki gibi ise herhangi işlem yapma contnue yap yani bir sonraki işleme geç
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;
                {
                    //iki tane soru işareti ile gelen değer null ise strişng empty yap old ile current biri null biri string empty olursa karşılaştırılamaz.
                    //
                    var oldValue = prop.GetValue(oldEntity) ?? string.Empty;
                    var currentValue = prop.GetValue(currentEntity) ?? string.Empty;

                    if (prop.PropertyType == typeof(byte[]))
                    {
                        if (string.IsNullOrEmpty(oldValue.ToString()))
                        {
                            oldValue = new byte[] { 0 };
                        }
                        if (string.IsNullOrEmpty(currentEntity.ToString()))
                        {
                            //byte olduğu için default değerini sıfır yaptık
                            currentValue = new byte[] { 0 };
                        }
                        if (((byte[])oldValue).Length != ((byte[])currentValue).Length)
                        {
                            return VeriDegisimYeri.Alan;
                        }
                    }
                    else if (!currentValue.Equals(oldValue))
                    {
                        return VeriDegisimYeri.Alan;
                    }

                }
            }
            return VeriDegisimYeri.VeriDegisimiYok;
        }

        public static void ButtonEnabledDurumu<T>(BarButtonItem btnYeni,BarButtonItem btnKaydet, BarButtonItem btnGeriAl, BarButtonItem btnSil,T oldEntity,T currentEntity)
        {
            var veriDegisimYeri = VeriDegisimYeriGetir(oldEntity, currentEntity);
            var buttonEnabledDurumu = veriDegisimYeri == VeriDegisimYeri.Alan;

            btnKaydet.Enabled = buttonEnabledDurumu;
            btnGeriAl.Enabled = buttonEnabledDurumu;
            btnYeni.Enabled = !buttonEnabledDurumu;
            btnSil.Enabled = !buttonEnabledDurumu;
        }
    }
}
