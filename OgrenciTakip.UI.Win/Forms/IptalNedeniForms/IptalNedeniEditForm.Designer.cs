namespace OgrenciTakip.UI.Win.Forms.IptalNedeniForms
{
    partial class IptalNedeniEditForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraLayout.ColumnDefinition columnDefinition1 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition2 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.ColumnDefinition columnDefinition3 = new DevExpress.XtraLayout.ColumnDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition1 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition2 = new DevExpress.XtraLayout.RowDefinition();
            DevExpress.XtraLayout.RowDefinition rowDefinition3 = new DevExpress.XtraLayout.RowDefinition();
            this.myDataLayoutControl = new OgrenciTakip.UI.Win.UserControls.Controls.MyDataLayoutControl();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.txtKod = new OgrenciTakip.UI.Win.UserControls.Controls.MyKodTexEdit();
            this.layoutkod = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtIptalNedeniAdi = new OgrenciTakip.UI.Win.UserControls.Controls.MyTextEdit();
            this.Laypıtneden = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtAciklama = new OgrenciTakip.UI.Win.UserControls.Controls.MyMemoEdit();
            this.layoutaciklama = new DevExpress.XtraLayout.LayoutControlItem();
            this.tglDurum = new OgrenciTakip.UI.Win.UserControls.Controls.MyToogleSwitch();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl)).BeginInit();
            this.myDataLayoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutkod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIptalNedeniAdi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laypıtneden)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutaciklama)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglDurum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl
            // 
            this.ribbonControl.ExpandCollapseItem.Id = 0;
            this.ribbonControl.Size = new System.Drawing.Size(380, 102);
            this.ribbonControl.Toolbar.ShowCustomizeItem = false;
            // 
            // myDataLayoutControl
            // 
            this.myDataLayoutControl.Controls.Add(this.tglDurum);
            this.myDataLayoutControl.Controls.Add(this.txtAciklama);
            this.myDataLayoutControl.Controls.Add(this.txtIptalNedeniAdi);
            this.myDataLayoutControl.Controls.Add(this.txtKod);
            this.myDataLayoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.myDataLayoutControl.Location = new System.Drawing.Point(0, 102);
            this.myDataLayoutControl.Name = "myDataLayoutControl";
            this.myDataLayoutControl.OptionsFocus.EnableAutoTabOrder = false;
            this.myDataLayoutControl.Root = this.layoutControlGroup1;
            this.myDataLayoutControl.Size = new System.Drawing.Size(380, 116);
            this.myDataLayoutControl.TabIndex = 0;
            this.myDataLayoutControl.Text = "myDataLayoutControl1";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutkod,
            this.Laypıtneden,
            this.layoutaciklama,
            this.layoutControlItem4});
            this.layoutControlGroup1.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            columnDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition1.Width = 200D;
            columnDefinition2.SizeType = System.Windows.Forms.SizeType.Percent;
            columnDefinition2.Width = 100D;
            columnDefinition3.SizeType = System.Windows.Forms.SizeType.Absolute;
            columnDefinition3.Width = 99D;
            this.layoutControlGroup1.OptionsTableLayoutGroup.ColumnDefinitions.AddRange(new DevExpress.XtraLayout.ColumnDefinition[] {
            columnDefinition1,
            columnDefinition2,
            columnDefinition3});
            rowDefinition1.Height = 24D;
            rowDefinition1.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition2.Height = 24D;
            rowDefinition2.SizeType = System.Windows.Forms.SizeType.Absolute;
            rowDefinition3.Height = 100D;
            rowDefinition3.SizeType = System.Windows.Forms.SizeType.Percent;
            this.layoutControlGroup1.OptionsTableLayoutGroup.RowDefinitions.AddRange(new DevExpress.XtraLayout.RowDefinition[] {
            rowDefinition1,
            rowDefinition2,
            rowDefinition3});
            this.layoutControlGroup1.Size = new System.Drawing.Size(380, 116);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // txtKod
            // 
            this.txtKod.EnterMoveNextControl = true;
            this.txtKod.Location = new System.Drawing.Point(65, 12);
            this.txtKod.MenuManager = this.ribbonControl;
            this.txtKod.Name = "txtKod";
            this.txtKod.Properties.Appearance.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.txtKod.Properties.Appearance.Options.UseBackColor = true;
            this.txtKod.Properties.Appearance.Options.UseTextOptions = true;
            this.txtKod.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtKod.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtKod.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtKod.Properties.MaxLength = 20;
            this.txtKod.Size = new System.Drawing.Size(143, 20);
            this.txtKod.StatusBarAciklama = "Kod Giriniz.";
            this.txtKod.StyleController = this.myDataLayoutControl;
            this.txtKod.TabIndex = 3;
            // 
            // layoutkod
            // 
            this.layoutkod.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutkod.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutkod.Control = this.txtKod;
            this.layoutkod.Location = new System.Drawing.Point(0, 0);
            this.layoutkod.Name = "layoutkod";
            this.layoutkod.Size = new System.Drawing.Size(200, 24);
            this.layoutkod.Text = "Kod";
            this.layoutkod.TextSize = new System.Drawing.Size(49, 13);
            // 
            // txtIptalNedeniAdi
            // 
            this.txtIptalNedeniAdi.EnterMoveNextControl = true;
            this.txtIptalNedeniAdi.Location = new System.Drawing.Point(65, 36);
            this.txtIptalNedeniAdi.MenuManager = this.ribbonControl;
            this.txtIptalNedeniAdi.Name = "txtIptalNedeniAdi";
            this.txtIptalNedeniAdi.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtIptalNedeniAdi.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtIptalNedeniAdi.Properties.MaxLength = 50;
            this.txtIptalNedeniAdi.Size = new System.Drawing.Size(303, 20);
            this.txtIptalNedeniAdi.StatusBarAciklama = "İptal Nedeni Giriniz.";
            this.txtIptalNedeniAdi.StyleController = this.myDataLayoutControl;
            this.txtIptalNedeniAdi.TabIndex = 0;
            // 
            // Laypıtneden
            // 
            this.Laypıtneden.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.Laypıtneden.AppearanceItemCaption.Options.UseForeColor = true;
            this.Laypıtneden.Control = this.txtIptalNedeniAdi;
            this.Laypıtneden.Location = new System.Drawing.Point(0, 24);
            this.Laypıtneden.Name = "Laypıtneden";
            this.Laypıtneden.OptionsTableLayoutItem.ColumnSpan = 3;
            this.Laypıtneden.OptionsTableLayoutItem.RowIndex = 1;
            this.Laypıtneden.Size = new System.Drawing.Size(360, 24);
            this.Laypıtneden.Text = "Neden Adı";
            this.Laypıtneden.TextSize = new System.Drawing.Size(49, 13);
            // 
            // txtAciklama
            // 
            this.txtAciklama.EnterMoveNextControl = true;
            this.txtAciklama.Location = new System.Drawing.Point(65, 60);
            this.txtAciklama.MenuManager = this.ribbonControl;
            this.txtAciklama.Name = "txtAciklama";
            this.txtAciklama.Properties.AppearanceFocused.BackColor = System.Drawing.Color.LightCyan;
            this.txtAciklama.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.txtAciklama.Properties.MaxLength = 500;
            this.txtAciklama.Size = new System.Drawing.Size(303, 44);
            this.txtAciklama.StatusBarAciklama = "Açıklama Giriniz.";
            this.txtAciklama.StyleController = this.myDataLayoutControl;
            this.txtAciklama.TabIndex = 1;
            // 
            // layoutaciklama
            // 
            this.layoutaciklama.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutaciklama.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutaciklama.Control = this.txtAciklama;
            this.layoutaciklama.Location = new System.Drawing.Point(0, 48);
            this.layoutaciklama.Name = "layoutaciklama";
            this.layoutaciklama.OptionsTableLayoutItem.ColumnSpan = 3;
            this.layoutaciklama.OptionsTableLayoutItem.RowIndex = 2;
            this.layoutaciklama.Size = new System.Drawing.Size(360, 48);
            this.layoutaciklama.Text = "Açıklama";
            this.layoutaciklama.TextSize = new System.Drawing.Size(49, 13);
            // 
            // tglDurum
            // 
            this.tglDurum.EnterMoveNextControl = true;
            this.tglDurum.Location = new System.Drawing.Point(273, 12);
            this.tglDurum.MenuManager = this.ribbonControl;
            this.tglDurum.Name = "tglDurum";
            this.tglDurum.Properties.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.tglDurum.Properties.Appearance.Options.UseForeColor = true;
            this.tglDurum.Properties.AutoHeight = false;
            this.tglDurum.Properties.AutoWidth = true;
            this.tglDurum.Properties.GlyphAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.tglDurum.Properties.OffText = "Pasif";
            this.tglDurum.Properties.OnText = "Aktif";
            this.tglDurum.Size = new System.Drawing.Size(97, 20);
            this.tglDurum.StatusBarAciklama = "Kartın Kullanım Durumunu Seçiniz";
            this.tglDurum.StyleController = this.myDataLayoutControl;
            this.tglDurum.TabIndex = 2;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.AppearanceItemCaption.ForeColor = System.Drawing.Color.Maroon;
            this.layoutControlItem4.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutControlItem4.Control = this.tglDurum;
            this.layoutControlItem4.Location = new System.Drawing.Point(261, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.OptionsTableLayoutItem.ColumnIndex = 2;
            this.layoutControlItem4.Size = new System.Drawing.Size(99, 24);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // IptalNedeniEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 249);
            this.Controls.Add(this.myDataLayoutControl);
            this.MinimumSize = new System.Drawing.Size(390, 250);
            this.Name = "IptalNedeniEditForm";
            this.Text = "İptal Nedeni Kartı";
            this.Controls.SetChildIndex(this.ribbonControl, 0);
            this.Controls.SetChildIndex(this.myDataLayoutControl, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataLayoutControl)).EndInit();
            this.myDataLayoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtKod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutkod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIptalNedeniAdi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Laypıtneden)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAciklama.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutaciklama)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tglDurum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private UserControls.Controls.MyDataLayoutControl myDataLayoutControl;
        private UserControls.Controls.MyToogleSwitch tglDurum;
        private UserControls.Controls.MyMemoEdit txtAciklama;
        private UserControls.Controls.MyTextEdit txtIptalNedeniAdi;
        private UserControls.Controls.MyKodTexEdit txtKod;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutkod;
        private DevExpress.XtraLayout.LayoutControlItem Laypıtneden;
        private DevExpress.XtraLayout.LayoutControlItem layoutaciklama;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
    }
}