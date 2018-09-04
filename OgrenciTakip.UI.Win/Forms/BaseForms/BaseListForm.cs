using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraBars;
using OgrenciTakip.UI.Win.Show.Interfaces;
using OgrenciTakip.COMMON.Enums;
using DevExpress.XtraGrid.Views.Grid;
using OgrenciTakip.UI.Win.Functions;
using OgrenciTakip.MODEL.Entities.Base;
using OgrenciTakip.BLL.Interfaces;

namespace OgrenciTakip.UI.Win.Forms.BaseForms
{
    public partial class BaseListForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        //sen şu formu açacaksın ona göre işlemler yapacaksın.
        protected IBaseFormShow FormShow;
        protected KartTuru BaseKartTuru;
        protected internal GridView Tablo;
        protected bool AktifKartlariGoster = true;
        protected internal bool MultiSelect;
        protected internal BaseEntity selectedEntity;
        //BaseListForm a bir tane BLL göndereceğiz burada bll ile ilgili delete işlemini yapacağız. Tüm formlar burdan implement olduğundan hazır hale gelecek
        protected IBaseBll Bll;
        protected ControlNavigator Navigator;
        public BaseListForm()
        {
            InitializeComponent();
        }

        private void EventsLoad()
        {
            //Button Events
            foreach (var item in ribbonControl.Items)
            {
                switch (item)
                {
                    case BarItem button:
                        button.ItemClick += Button_ItemClick;
                        break;
                }
            }

            //Table Events

            Tablo.DoubleClick += Tablo_DoubleClick;
            Tablo.KeyDown += Tablo_KeyDown;

            //Forms Events
        }

       
        protected internal void Yukle()
        {
            DegiskenleriDoldur();
            EventsLoad();

            Tablo.OptionsSelection.MultiSelect = MultiSelect;
            Navigator.NavigatableControl = Tablo.GridControl;
            Cursor.Current = Cursors.WaitCursor;
            Listele();
            Cursor.Current = DefaultCursor;

            //Güncellenecek
        }

        protected virtual void DegiskenleriDoldur() { }

        private void ShowEditForm(long id)
        {
            //Hangi formu açacağını bildireceğiz.
            //kart türünü değişkenini filtre gibi alanlarda kulllanacağız.
            var result = FormShow.ShowDialogEditForm(BaseKartTuru, id);
        }

        private void EntityDelete()
        {
            throw new NotImplementedException();
        }

        private void SelectEntity()
        {
            if (MultiSelect)
            {
                //Güncellenecek
            }
            else
            {
                selectedEntity = Tablo.GetRow<BaseEntity>();
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        protected virtual void Listele() { }
        private void FiltreSec()
        {
            throw new NotImplementedException();
        }
        private void Yazdir()
        {
            throw new NotImplementedException();
        }

        private void FormCaptionAyarla()
        {
            throw new NotImplementedException();
        }

        private void IslemTuruSec()
        {
            if (!IsMdiChild)
            {
                //güncellenecek
                SelectEntity();
            }
            else
            {
                //duzeltme işlemi yap yani mdichild değilse duzelt formu gibi aç
                btnDuzelt.PerformClick();
            }
        }


        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {

            //menudeki butona bastığımızda imleç meskul konuma geçiyor
            Cursor.Current = Cursors.WaitCursor;
            if (e.Item==btnGonder)
            {
                var link =(BarSubItemLink) e.Item.Links[0];
                link.Focus();
                link.OpenMenu();
                link.Item.ItemLinks[0].Focus();
            }
            else if (e.Item == btnStandartExcelDosyasi)
            {

            }
            else if(e.Item==btnFormatliExcelDosyasi)
            {

            }
            else if (e.Item == btnFormatsizExcelDosyasi)
            {

            }
            else if (e.Item == btnWordDosyasi)
            {

            }
            else if (e.Item == btnPdfDosyasi)
            {

            }
            else if (e.Item == btnYeni)
            {
                //Yetki kontrolü yapılacak
                //mümkün olduğunda kodlarımızı base formdan yazıyoruz. zorunlu kaldıkça implemente ettiğimiz formlarda yapacağız.
                ShowEditForm(-1);

            }
            else if (e.Item == btnDuzelt)
            {
                ShowEditForm(Tablo.GetRowId());
            }
            else if (e.Item == btnSil)
            {
                //Yetki kontrolü
                EntityDelete();
            }

            else if (e.Item == btnSec)
            {
                SelectEntity();
            }

            else if (e.Item == btnYenile)
            {
                Listele();
            }

            else if (e.Item==btnFiltrele)
            {
                FiltreSec();
            }

            else if (e.Item == btnKolonlar)
            {
                if (Tablo.CustomizationForm==null)
                {
                    Tablo.ShowCustomization();
                }
                else
                {
                    Tablo.HideCustomization();
                }
            }

            else if (e.Item == btnYazdir)
            {
                Yazdir();
            }

            else if (e.Item == btnCikis)
            {
                Close();
            }
            else if (e.Item == btnAktifPasifKartlar)
            {
                //false ise true gönderiyor. true ise false gönderiyor.
                AktifKartlariGoster = !AktifKartlariGoster;

                FormCaptionAyarla();
            }

            Cursor.Current = DefaultCursor;

        }

        private void Tablo_DoubleClick(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            IslemTuruSec();
            Cursor.Current = DefaultCursor;
        }

        private void Tablo_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    IslemTuruSec();
                    break;
                case Keys.Escape:
                    Close();
                    break;
            }
        }


    }
}