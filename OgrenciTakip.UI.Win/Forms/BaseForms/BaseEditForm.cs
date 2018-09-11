using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using OgrenciTakip.COMMON.Enums;
using DevExpress.XtraBars;
using OgrenciTakip.UI.Win.UserControls.Controls;
using OgrenciTakip.BLL.Interfaces;
using OgrenciTakip.MODEL.Entities.Base;
using OgrenciTakip.UI.Win.Functions;
using OgrenciTakip.COMMON.Message;
using OgrenciTakip.UI.Win.UserControls.Grid;
using OgrenciTakip.UI.Win.Interfaces;
using DevExpress.XtraPrinting.Native;
using OgrenciTakip.MODEL.Entities.Base.Interfaces;

namespace OgrenciTakip.UI.Win.Forms.BaseForms
{
    public partial class BaseEditForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        #region Variables

        private bool _formSablonKayitEdilecek;
        protected MyDataLayoutControl DataLayoutControl;
        protected MyDataLayoutControl[] DataLayoutControls;
        protected IBaseBll Bll;
        protected KartTuru BaseKartTuru;
        protected BaseEntity OldEntity;
        protected BaseEntity CurrentEntity;
        protected bool IsLoaded;
        protected bool KayitSonrasiFormuKapat = true;
        protected BarItem[] ShowItems;
        protected BarItem[] HideItems;
        protected internal IslemTuru BaseIslemTuru;
        protected internal long Id;
        protected internal bool RefreshYapilacak; 

        #endregion

        public BaseEditForm()
        {
            InitializeComponent();
        }

        protected void EventsLoad()
        {
            //Button events

            foreach (BarItem button in ribbonControl.Items)
            {
                button.ItemClick += Button_ItemClick;
            }

            //Form Events

            LocationChanged += BaseEditForm_LocationChanged;
            SizeChanged += BaseEditForm_SizeChanged;

            Load += BaseEditForm_Load;

            FormClosing += BaseEditForm_FormClosing;

            void ControlEvents(Control control)
            {
                control.KeyDown += Control_KeyDown;
                control.GotFocus += Control_GotFocus;
                control.Leave += Control_Leave;
                switch (control)
                {
                    case FilterControl edt:
                        
                        edt.FilterChanged += Control_EditValueChanged;
                        break;
                    case ComboBoxEdit edt:
                        edt.EditValueChanged += Control_EditValueChanged;
                        edt.SelectedValueChanged += Control_SelectedValueChanged;
                        break;
                    case MyButtonEdit edt:
                        edt.IdChanged += Control_IdChanged;
                        edt.EnabledChange += Control_EnabledChange;
                        edt.ButtonClick += Control_ButtonClick;
                        edt.DoubleClick += Control_DoubleClick;
                        break;
                    case BaseEdit edt:
                        edt.EditValueChanged += Control_EditValueChanged;
                        break;
                }
            }
            if (DataLayoutControls==null)
            {
                if (DataLayoutControl==null)
                {
                    return;
                }
                foreach (Control ctrl in DataLayoutControl.Controls)
                {
                    ControlEvents(ctrl);
                }
            }
            else
            {
                foreach (var layout in DataLayoutControls)
                {
                    foreach (Control ctrl in layout.Controls)
                    {
                        ControlEvents(ctrl);
                    }
                }
            }
        }

        private void EntityDelete()
        {
            if (!((IBaseCommonBll)Bll).Delete(OldEntity))
            {
                return;
            }
            RefreshYapilacak = true;
            Close();
        }

        private void ButonGizleGoster()
        {


            ShowItems?.ForEach(x => x.Visibility = BarItemVisibility.Always);
            HideItems?.ForEach(x => x.Visibility = BarItemVisibility.Never);
        }

        private void GeriAl()
        {
            if (Messages.HayirSeciliEvetHayir("Yapılan değişiklikler Geri Alınacaktır. Onaylıyor Musunuz ?", "GeriAl Onay") != DialogResult.Yes)
            {
                return;
            }
            if (BaseIslemTuru == IslemTuru.EntityUpdate)
            {
                Yukle();
            }
            else
            {
                Close();
            }

        }

        private bool Kaydet(bool kapanis)
        {
            bool KayitIslemi()
            {
                Cursor.Current = Cursors.WaitCursor;
                switch (BaseIslemTuru)
                {
                    case IslemTuru.EntityInsert:
                        if (EntityInsert())
                        {
                            return KayitSonrasiIslemler();
                        }
                        break;
                    case IslemTuru.EntityUpdate:
                        if (EntityUpdate())
                        {
                            return KayitSonrasiIslemler();
                        }
                        break;
                }
                bool KayitSonrasiIslemler()
                {
                    OldEntity = CurrentEntity;
                    RefreshYapilacak = true;
                    ButtonEnabledDurumu();
                    if (KayitSonrasiFormuKapat)
                    {
                        Close();
                    }
                    else
                    {
                        BaseIslemTuru = BaseIslemTuru == IslemTuru.EntityInsert ? IslemTuru.EntityUpdate : BaseIslemTuru;
                    }
                    return true;
                }
                return false;
            }
            var result = kapanis ? Messages.KapanisMesaj() : Messages.KayitMesaj();

            switch (result)
            {
                case DialogResult.Yes:
                    return KayitIslemi();
                case DialogResult.No:
                    if (kapanis)
                    {
                        btnKaydet.Enabled = false;
                    }
                    return true;
                case DialogResult.Cancel:
                    return false;


            }
            return false;
        }

        private void SablonYukle()
        {
            Name.FormSablonYukle(this);
        }

        private void FarkliKaydet()
        {
            if (Messages.EvetSeciliEvetHayir("Bu Filtre Referans Alınarak Yeni Kayıt Oluşturulacaktı Onaylıyor Musunuz ?", "Kayıt Onay") != DialogResult.Yes)
            {
                return;
            }
            BaseIslemTuru = IslemTuru.EntityInsert;
            Yukle();
            if (Kaydet(true))
            {
                Close();
            }
        }

        protected virtual void FiltreUygula() { }

        protected void SablonKaydet()
        {
            if (_formSablonKayitEdilecek)
            {
                Name.FormSablonKaydet(Left, Top, Width, Height, WindowState);
            }
        }

        protected virtual void BaskiOnIzleme() { }

        protected virtual void Yazdir() { }

        protected virtual void SecipYap(object sender) { }

        protected virtual bool EntityInsert()
        {
            return ((IBaseGenelBll)Bll).Insert(CurrentEntity);
        }
        protected virtual bool EntityUpdate()
        {
            return ((IBaseGenelBll)Bll).Update(OldEntity, CurrentEntity);
        }

        protected virtual void NesneyiControllereBagla() { }
        protected virtual void GuncelNesneOlustur() { }

        protected internal virtual void Yukle() { }
        protected internal virtual IBaseEntity ReturnEntity() { return null; }
        protected internal virtual void ButtonEnabledDurumu()
        {
            if (!IsLoaded) return;
            GeneralFunctions.ButtonEnabledDurumu(btnYeni, btnKaydet, btnGeriAl, btnSil, OldEntity, CurrentEntity);

        }

        //EVENTS

        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            if (e.Item == btnYeni)
            {
                //Yetki kontrolü yap
                BaseIslemTuru = IslemTuru.EntityInsert;
                Yukle();
            }
            else if (e.Item == btnKaydet)
            {
                Kaydet(false);
            }
            else if (e.Item == btnFarkliKaydet)
            {
                //Yetki kontrolü yap

                FarkliKaydet();
            }

            else if (e.Item == btnGeriAl)
            {
                GeriAl();
            }
            else if (e.Item == btnSil)
            {
                //Yetki kontrolü yap
                EntityDelete();
            }
            else if (e.Item == btnUygula)
            {
                FiltreUygula();
            }
            else if (e.Item == btnYazdir)
            {
                Yazdir();
            }
            else if (e.Item == btnBaskiOnIzleme)
            {
                BaskiOnIzleme();
            }
            else if (e.Item == btnCikis)
            {
                Close();
            }

            Cursor.Current = DefaultCursor;
        }

        private void BaseEditForm_LocationChanged(object sender, EventArgs e)
        {
            _formSablonKayitEdilecek = true;
        }

        private void BaseEditForm_SizeChanged(object sender, EventArgs e)
        {
            _formSablonKayitEdilecek = true;
        }

        private void BaseEditForm_Load(object sender, EventArgs e)
        {
            IsLoaded = true;
            GuncelNesneOlustur();
            SablonYukle();
            ButonGizleGoster();


            //Guncelleme yapılacak
        }

        private void BaseEditForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SablonKaydet();
            if (btnKaydet.Visibility == BarItemVisibility.Never || !btnKaydet.Enabled)
            {
                return;
            }

            if (!Kaydet(true))
            {
                e.Cancel = true;
            }
        }

        private void Control_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
            if (sender is MyButtonEdit edt)
            {
                switch (e.KeyCode)
                {
                    case Keys.Delete when e.Control && e.Shift:
                        edt.Id = null;
                        edt.EditValue = null;
                        break;

                    case Keys.F4:
                    case Keys.Down when e.Modifiers == Keys.Alt:
                        SecipYap(edt);
                        break;
                }
            }
        }

        private void Control_GotFocus(object sender, EventArgs e)
        {
            var type = sender.GetType();
            if (type == typeof(MyButtonEdit) || type == typeof(MyGridView) || type == typeof(MyPictureEdit) || type == typeof(MyComboBoxEdit) || type == typeof(MyDateEdit))
            {
                statusBarKisaYol.Visibility = BarItemVisibility.Always;
                statusBarKisayolAciklama.Visibility = BarItemVisibility.Always;

                statusBarAciklama.Caption = ((IStatusBarAciklama)sender).StatusBarAciklama;
                statusBarKisaYol.Caption = ((IStatusBarKisaYol)sender).StatusBarKisaYol;
                statusBarKisayolAciklama.Caption = ((IStatusBarKisaYol)sender).StatusBarKisaYolAciklama;
            }
            else if (sender is IStatusBarAciklama ctrl)
            {
                statusBarAciklama.Caption = ctrl.StatusBarAciklama;
            }
        }

        private void Control_Leave(object sender, EventArgs e)
        {
            statusBarKisaYol.Visibility = BarItemVisibility.Never;
            statusBarKisayolAciklama.Visibility = BarItemVisibility.Never;
        }

        private void Control_EditValueChanged(object sender, EventArgs e)
        {
            if (!IsLoaded)
            {
                return;
            }
            GuncelNesneOlustur();
        }

        protected virtual void Control_SelectedValueChanged(object sender, EventArgs e) { }

        private void Control_IdChanged(object sender, IdChangedEventArgs e)
        {
            if (!IsLoaded)
            {
                return;
            }
            GuncelNesneOlustur();
        }

        protected virtual void Control_EnabledChange(object sender, EventArgs e)
        {

        }

        private void Control_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            SecipYap(sender);
        }

        private void Control_DoubleClick(object sender, EventArgs e)
        {
            SecipYap(sender);
        }



       

      

        

    }
}