using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using OgrenciTakip.COMMON.Enums;
using OgrenciTakip.COMMON.Message;
using OgrenciTakip.MODEL.Entities.Base;
using OgrenciTakip.UI.Win.UserControls.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciTakip.UI.Win.Functions
{
    public static class GeneralFunctions
    {
        public static long GetRowId(this GridView tablo)
        {
            if (tablo.FocusedRowHandle > -1)
            {
                return (long)tablo.GetFocusedRowCellValue("Id");
            }
            Messages.KartSecmemeUyariMesaji();

            return -1;
        }

        public static T GetRow<T>(this GridView tablo, bool mesajVer = true)
        {
            if (tablo.FocusedRowHandle > -1)
            {
                return (T)tablo.GetRow(tablo.FocusedRowHandle);
            }
            if (mesajVer)
            {
                Messages.KartSecmemeUyariMesaji();
            }
            return default(T);
        }

        private static VeriDegisimYeri VeriDegisimYeriGetir<T>(T oldEntity, T currentEntity)
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

        public static void ButtonEnabledDurumu<T>(BarButtonItem btnYeni, BarButtonItem btnKaydet, BarButtonItem btnGeriAl, BarButtonItem btnSil, T oldEntity, T currentEntity)
        {
            var veriDegisimYeri = VeriDegisimYeriGetir(oldEntity, currentEntity);
            var buttonEnabledDurumu = veriDegisimYeri == VeriDegisimYeri.Alan;

            btnKaydet.Enabled = buttonEnabledDurumu;
            btnGeriAl.Enabled = buttonEnabledDurumu;
            btnYeni.Enabled = !buttonEnabledDurumu;
            btnSil.Enabled = !buttonEnabledDurumu;
        }
        public static void ButtonEnabledDurumu<T>(BarButtonItem btnKaydet, BarButtonItem btnFarkliKaydet, BarButtonItem btnSil, IslemTuru islemTuru, T oldEntity, T currentEntity)
        {
            var veriDegisimYeri = VeriDegisimYeriGetir(oldEntity, currentEntity);
            var buttonEnabledDurumu = veriDegisimYeri == VeriDegisimYeri.Alan;

            btnKaydet.Enabled = buttonEnabledDurumu;
            btnFarkliKaydet.Enabled = islemTuru != IslemTuru.EntityInsert;
            
            btnSil.Enabled = !buttonEnabledDurumu;
        }

        public static long IdOlustur(this IslemTuru IslemTuru, BaseEntity selectedEntity)
        {
            //2018 9 4 00 32 50 55 654

            string SifirEkle(string deger)
            {
                if (deger.Length==1)
                {
                    return "0" + deger;
                }
                return deger;
            }

            string UcBasamakYap(string deger)
            {
                switch (deger.Length)
                {
                    case 1:
                        return "00" + deger;
                    case 2:
                        return "0" + deger;

                       
                }
                return deger;
            }

            string Id()
            {
                var yil = DateTime.Now.Date.Year.ToString();
                var ay = SifirEkle(DateTime.Now.Date.Month.ToString());
                var gun = SifirEkle(DateTime.Now.Date.Day.ToString());
                var saat = SifirEkle(DateTime.Now.Date.Hour.ToString());
                var dakika = SifirEkle(DateTime.Now.Minute.ToString());
                var saniye = SifirEkle(DateTime.Now.Second.ToString());
                var milisaniye = UcBasamakYap(DateTime.Now.Millisecond.ToString());
                var random = SifirEkle(new Random().Next(0, 99).ToString());

                return yil + ay + gun + saat + dakika + saniye + milisaniye + random;
            }
            return IslemTuru == IslemTuru.EntityUpdate ? selectedEntity.Id : long.Parse(Id());
        }

        public static void ControlEnabledChange(this MyButtonEdit baseEdit,Control prmEdit)
        {
            switch (prmEdit)
            {
                case MyButtonEdit edt:
                    edt.Enabled = baseEdit.Id.HasValue && baseEdit.Id>0;
                    edt.Id = null;
                    edt.EditValue = null;
                    break;
            }
        }
        
        public static void RowFocus(this GridView tablo,string aranacakKolon,object aranacakDeger)
        {
            var rowHandle = 0;

            for (int i = 0; i < tablo.RowCount; i++)
            {
                var bulunanDeger = tablo.GetRowCellValue(i, aranacakKolon);
                if (aranacakDeger.Equals(bulunanDeger))
                {
                    rowHandle = i;
                }
            }
            tablo.FocusedRowHandle = rowHandle;
        }

        public static void RowFocus(this GridView tablo,int rowHandle)
        {
            if (rowHandle<=0)
            {
                return;
            }
            if (rowHandle==tablo.RowCount-1)
            {
                tablo.FocusedRowHandle = rowHandle;
            }
            else
            {
                tablo.FocusedRowHandle = rowHandle - 1;
            }
        }

        public static void SagMenuGoster(this MouseEventArgs e,PopupMenu sagMenu)
        {
            if (e.Button!=MouseButtons.Right)
            {
                return;
            }
            sagMenu.ShowPopup(Control.MousePosition);
        }
    }
}

