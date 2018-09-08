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
using DevExpress.XtraPrinting.Native;

namespace OgrenciTakip.UI.Win.Forms.BaseForms
{
    public partial class BaseListForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private bool _formSablonKayitEdilecek;
        private bool _tabloSablonKayitEdilecek;
        //sen şu formu açacaksın ona göre işlemler yapacaksın.
        protected IBaseFormShow FormShow;
        protected KartTuru BaseKartTuru;
        protected internal GridView Tablo;
        protected bool AktifKartlariGoster = true;
        protected internal bool AktifPasifButonGoster = false;
        protected internal bool MultiSelect;
        protected internal BaseEntity selectedEntity;
        //BaseListForm a bir tane BLL göndereceğiz burada bll ile ilgili delete işlemini yapacağız. Tüm formlar burdan implement olduğundan hazır hale gelecek
        protected IBaseBll Bll;
        protected ControlNavigator Navigator;
        protected internal long? seciliGelecekId;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;
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
            Tablo.MouseUp += Tablo_MouseUp;
            Tablo.ColumnWidthChanged += Tablo_ColumnWidthChanged;
            Tablo.ColumnPositionChanged += Tablo_ColumnPositionChanged;
            Tablo.EndSorting += Tablo_EndSorting;

            //Forms Events

            Shown += BaseListForm_Shown;
            Load += BaseListForm_Load;
            FormClosing += BaseListForm_FormClosing;
            LocationChanged += BaseListForm_LocationChanged;
            SizeChanged += BaseListForm_SizeChanged;
        }

        private void BaseListForm_SizeChanged(object sender, EventArgs e)
        {
            if (!IsMdiChild)
            {
                _formSablonKayitEdilecek = true;
            }
           
        }

        private void BaseListForm_LocationChanged(object sender, EventArgs e)
        {
            if (!IsMdiChild)
            {
                _formSablonKayitEdilecek = true;
            }
        }

        private void Tablo_EndSorting(object sender, EventArgs e)
        {
            _tabloSablonKayitEdilecek = true;
        }

        private void Tablo_ColumnPositionChanged(object sender, EventArgs e)
        {
            _tabloSablonKayitEdilecek = true;
        }

        private void Tablo_ColumnWidthChanged(object sender, DevExpress.XtraGrid.Views.Base.ColumnEventArgs e)
        {
            _tabloSablonKayitEdilecek = true;
        }

        private void BaseListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SablonKaydet();
        }

        private void BaseListForm_Load(object sender, EventArgs e)
        {
            SablonYukle();
        }

        private void Tablo_MouseUp(object sender, MouseEventArgs e)
        {
            e.SagMenuGoster(sagMenu);
        }

        private void BaseListForm_Shown(object sender, EventArgs e)
        {
            Tablo.Focus();
            ButonGizleGoster();
            //SutunGizleGoster();

            if (IsMdiChild ||seciliGelecekId==null)
            {
                return;
            }
            Tablo.RowFocus("Id", seciliGelecekId);
        }

        private void SutunGizleGoster()
        {
            throw new NotImplementedException();
        }

        private void SablonKaydet()
        {
            if (_formSablonKayitEdilecek)
            {
                Name.FormSablonKaydet(Left, Top, Width, Height, WindowState);

            }
            if (_tabloSablonKayitEdilecek)
            {
                Tablo.TabloSablonKaydet(IsMdiChild ? Name + " Tablosu" : Name + " TablosuMDI");
            }
        }
        private void SablonYukle()
        {
            if (IsMdiChild)
            {
                Tablo.TabloSablonYukle(Name + " Tablosu");
            }
            else
            {
                Name.FormSablonYukle(this);
                Tablo.TabloSablonYukle(Name + " TablosuMDI");
            }
        }

        private void ButonGizleGoster()
        {
            btnSec.Visibility = AktifPasifButonGoster == true ? BarItemVisibility.Never : IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;
            barEnter.Visibility = IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;
            barEnterAciklama.Visibility = IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;
            btnAktifPasifKartlar.Visibility = AktifPasifButonGoster ? BarItemVisibility.Always : !IsMdiChild ? BarItemVisibility.Never : BarItemVisibility.Always;

            ShowItems?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            HideItems?.ForEach(x => x.Visibility = BarItemVisibility.Never);
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

        protected virtual void ShowEditForm(long id)
        {
            //Hangi formu açacağını bildireceğiz.
            //kart türünü değişkenini filtre gibi alanlarda kulllanacağız.
            var result = FormShow.ShowDialogEditForm(BaseKartTuru, id);
            ShowEditFormDefault(result);
        }

        protected void ShowEditFormDefault(long id)
        {
            if (id<=0)
            {
                return;
            }

            AktifKartlariGoster = true;
            FormCaptionAyarla();
            Tablo.RowFocus("Id", id);
        }

        private void EntityDelete()
        {
            var entity = Tablo.GetRow<BaseEntity>();
            if (entity==null)
            {
                return;
            }

            if (!((IBaseCommonDll)Bll).Delete(entity))
            {
                return;
            }

            Tablo.DeleteSelectedRows();
            Tablo.RowFocus(Tablo.FocusedRowHandle);
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
            if (btnAktifPasifKartlar==null)
            {
                Listele();
                return;
            }
            if (AktifKartlariGoster)
            {
                btnAktifPasifKartlar.Caption = "Pasif Kartlar";
                Tablo.ViewCaption = Text;
            }
            else
            {
                btnAktifPasifKartlar.Caption = "Aktif Kartlar";
                Tablo.ViewCaption = Text + " - Pasif Kartlar";
            }
            Listele();
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
                Tablo.TabloDisariAktar(DosyaTuru.ExcelStandart, e.Item.Caption, Text);
            }
            else if(e.Item==btnFormatliExcelDosyasi)
            {
                Tablo.TabloDisariAktar(DosyaTuru.ExcelFormatli, e.Item.Caption, Text);
            }
            else if (e.Item == btnFormatsizExcelDosyasi)
            {
                Tablo.TabloDisariAktar(DosyaTuru.ExcelFormatsiz, e.Item.Caption, Text);
            }
            else if (e.Item == btnWordDosyasi)
            {
                Tablo.TabloDisariAktar(DosyaTuru.WordDosyasi, e.Item.Caption);
            }
            else if (e.Item == btnPdfDosyasi)
            {
                Tablo.TabloDisariAktar(DosyaTuru.PdfDosyasi, e.Item.Caption);
            }
            else if (e.Item == btnTxtDosyasi)
            {
                Tablo.TabloDisariAktar(DosyaTuru.TxtDosyasi, e.Item.Caption);
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
            else if (e.Item == btnBagliKartlar)
            {
                BagliKartAc();
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

        protected virtual void BagliKartAc()
        {
           
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