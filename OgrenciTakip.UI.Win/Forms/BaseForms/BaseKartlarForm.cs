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

namespace OgrenciTakip.UI.Win.Forms.BaseForms
{
    public partial class BaseKartlarForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public BaseKartlarForm()
        {
            InitializeComponent();
        }

        private void EventsLoad()
        {
            foreach (var item in ribbonControl.Items)
            {
                switch (item)
                {
                    case BarItem button:
                        button.ItemClick += Button_ItemClick;
                        break;
                }
            }
        }
        private void ShowEditForm(long id)
        {
            var result =
        }
        private void Button_ItemClick(object sender, ItemClickEventArgs e)
        {
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
                ShowEditForm();

            }

        }

        
    }
}