using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;
using OgrenciTakip.MODEL.Entities;
using OgrenciTakip.UI.Win.GenelForms;
using OgrenciTakip.UI.Win.Show;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.UI.Win.Functions
{
    public class TablePrintingFunctions
    {
        private static GridView _tablo;
        private static string _subeAdi;
        private static PrintableComponentLink _link;
        private static PrintingSystem _ps;
        private static DokumParametreleri _dp;
        public static void Yazdir(GridView tablo, string raporBaslik, string subeAdi)
        {
            _link = new PrintableComponentLink();
            _ps = new PrintingSystem();
            _tablo = tablo;
            _subeAdi = subeAdi;
            _dp = ShowEditForms<TabloDokumParametreleri>.ShowDialogEditForm<DokumParametreleri>(raporBaslik);

            RaporDokum();
        }

        private static void RaporDokum()
        {
            BaslikEkle();
            RaporuKagidaSigdir();
            _tablo.OptionsPrint.PrintHorzLines = _dp.YatayCizgileriGoster == COMMON.Enums.EvetHayir.Evet;
            _tablo.OptionsPrint.PrintVertLines = _dp.DikeyCizgileriGoster == COMMON.Enums.EvetHayir.Evet;
            _tablo.OptionsPrint.PrintHeader = _dp.SutunBasliklariniGoster == COMMON.Enums.EvetHayir.Evet;
            _tablo.OptionsView.ShowViewCaption = false;

            _link.Component = _tablo.GridControl;
            _link.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            _link.Margins = new System.Drawing.Printing.Margins(59, 59, 115, 48);
            _link.CreateMarginalHeaderArea += _Link_CreateMarginalHeaderArea;
            _link.CreateDocument(_ps);

            switch (_dp.DokumSekli)
            {
                case COMMON.Enums.DokumSekli.TabloBaslikOnIzleme:
                    ShowRibbonForms<RaporOnIzleme>.ShowForm(true, _ps, _dp.RaporBaslik);
                    break;

                case COMMON.Enums.DokumSekli.TabloYazdir:
                    for (int i = 0; i < _dp.YazdirilacakAdet; i++)
                    {
                        _link.Print(_dp.YaziciAdi);
                    }
                    break;


            }

            _tablo.OptionsView.ShowViewCaption = true;
        }

        private static void _Link_CreateMarginalHeaderArea(object sender, CreateAreaEventArgs e)
        {
            if (_dp.BaslikEkle == COMMON.Enums.EvetHayir.Hayir)
            {
                return;
            }
            var boldFont = new Font("Tahoma", 7, FontStyle.Bold);
            var regularFont = new Font("Tahoma", 7, FontStyle.Regular);

            var sayfaBrick = new PageInfoBrick(BorderSide.None, 0, Color.Transparent, Color.Transparent, Color.Black)
            {
                Font = regularFont,
                PageInfo = PageInfo.NumberOfTotal,
                Format = "Sayfa {0} / {1}",
                Alignment=BrickAlignment.Far,
                AutoWidth=true
            };

            _ps.Graph.DrawBrick(sayfaBrick, new RectangleF(200, 25, 40, 15));

            var tarihBrick = new PageInfoBrick(BorderSide.None, 0, Color.Transparent, Color.Transparent, Color.Black)
            {
                Font = regularFont,
                PageInfo = PageInfo.DateTime,
                Format = "Tarih {0:dd.MM.yyyy}",
                Alignment = BrickAlignment.Far,
                AutoWidth = true
            };

            _ps.Graph.DrawBrick(tarihBrick, new RectangleF(0, 40, 50, 15));

            var subeBaslikBrick = new TextBrick(BorderSide.None, 0, Color.Transparent, Color.Transparent, Color.Black)
            {
                Font = boldFont,
               Text="Şube"
            };

            _ps.Graph.DrawBrick(subeBaslikBrick, new RectangleF(0, 25, 40, 15));

            var subeValueBrick = new TextBrick(BorderSide.None, 0, Color.Transparent, Color.Transparent, Color.Black)
            {
                Font = regularFont,
                Text = $": { _subeAdi}"
            };

            _ps.Graph.DrawBrick(subeValueBrick, new RectangleF(55, 25, 500, 15));

            var donemBaslikBrick = new TextBrick(BorderSide.None, 0, Color.Transparent, Color.Transparent, Color.Black)
            {
                Font = boldFont,
                Text = "Dönem"
            };

            _ps.Graph.DrawBrick(donemBaslikBrick, new RectangleF(0, 40, 40, 15));

            var donemValueBrick = new TextBrick(BorderSide.None, 0, Color.Transparent, Color.Transparent, Color.Black)
            {
                Font = regularFont,
                Text = $": {AnaForm.DonemAdi}"
            };

            _ps.Graph.DrawBrick(donemValueBrick, new RectangleF(55, 40, 200, 15));
        }

        private static void RaporuKagidaSigdir()
        {
            YazdirmaYonuAyarla();
            switch (_dp.RaporuKagidaSigdir)
            {
                case COMMON.Enums.RaporuKagidaSigdirmaTuru.SutunlariDaraltarakSigdir:
                    _tablo.OptionsPrint.AutoWidth = true;
                    break;
                case COMMON.Enums.RaporuKagidaSigdirmaTuru.YaziBoyutunuKuculterekSigdir:
                    _tablo.OptionsPrint.AutoWidth = false;
                    _ps.Document.AutoFitToPagesWidth = 1;
                    break;
                default:
                    _tablo.OptionsPrint.AutoWidth = false;
                    _ps.Document.ScaleFactor = 1.0f;
                    break;

            }
        }

        private static void YazdirmaYonuAyarla()
        {
            switch (_dp.YazdirmaYonu)
            {
                case COMMON.Enums.YazdirmaYonu.Dikey:
                    _link.Landscape = false;
                    break;
                case COMMON.Enums.YazdirmaYonu.Yatay:
                    _link.Landscape = true;
                    break;
                case COMMON.Enums.YazdirmaYonu.Otomatik:
                    _link.Landscape = OtomatikYazdirmaYonu();
                    break;

            }
        }

        private static bool OtomatikYazdirmaYonu()
        {
            const int sayfaGenisligi = 703;
            var tabloStunGenislikleri = 0;

            for (int i = 0; i < _tablo.Columns.Count; i++)
            {
                if (_tablo.Columns[i].Visible)
                {
                    tabloStunGenislikleri = _tablo.Columns[i].Width;
                }

            }
            return tabloStunGenislikleri > sayfaGenisligi;
        }

        private static void BaslikEkle()
        {
            if (_dp.BaslikEkle == COMMON.Enums.EvetHayir.Hayir)
            {
                return;
            }

            var headerArea = new PageHeaderArea();
            headerArea.Content.AddRange(new[] { "", _dp.RaporBaslik });
            headerArea.Font = new System.Drawing.Font("Arial Narrow", 10f, System.Drawing.FontStyle.Bold);
            headerArea.LineAlignment = BrickAlignment.Far;
            _link.PageHeaderFooter = new PageHeaderFooter(headerArea, null);
        }
    }
}
