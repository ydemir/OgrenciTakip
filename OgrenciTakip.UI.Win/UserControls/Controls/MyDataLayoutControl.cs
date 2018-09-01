using DevExpress.XtraDataLayout;
using DevExpress.XtraLayout;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
   public class MyDataLayoutControl:DataLayoutControl
    {
        public MyDataLayoutControl()
        {
            OptionsFocus.EnableAutoTabOrder = false;
        }
        protected override LayoutControlImplementor CreateILayoutControlImplementorCore()
        {
            return new MyLayoutControlImplementor(this);
        }
    }

    internal class MyLayoutControlImplementor : LayoutControlImplementor
    {
        public MyLayoutControlImplementor(ILayoutControlOwner owner) : base(owner)
        {
        }

        public override BaseLayoutItem CreateLayoutItem(LayoutGroup parent)
        {
            var item= base.CreateLayoutItem(parent);
            item.AppearanceItemCaption.ForeColor = Color.Maroon;
            return item;
        }
        public override LayoutGroup CreateLayoutGroup(LayoutGroup parent)
        {
            var grp= base.CreateLayoutGroup(parent);
            grp.LayoutMode = DevExpress.XtraLayout.Utils.LayoutMode.Table;

            grp.OptionsTableLayoutGroup.ColumnDefinitions[0].SizeType = System.Windows.Forms.SizeType.Absolute;
            grp.OptionsTableLayoutGroup.ColumnDefinitions[0].Width = 200;
            grp.OptionsTableLayoutGroup.ColumnDefinitions[1].SizeType = System.Windows.Forms.SizeType.Percent;
            grp.OptionsTableLayoutGroup.ColumnDefinitions[1].Width = 100;
            grp.OptionsTableLayoutGroup.ColumnDefinitions.Add(new ColumnDefinition
            {
                SizeType = System.Windows.Forms.SizeType.Absolute,
                Width = 99
            });

            grp.OptionsTableLayoutGroup.RowDefinitions.Clear();

            for (int i = 0; i < 9; i++)
            {
                grp.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                {
                    SizeType = System.Windows.Forms.SizeType.Absolute,
                    Height=24
                });

                //10 a eşit olmadığı sürece devam et 

                if (i + 1 != 9) continue;

                //i + =10 ise 

                grp.OptionsTableLayoutGroup.RowDefinitions.Add(new RowDefinition
                {
                    SizeType=System.Windows.Forms.SizeType.Percent,
                    Height=100
                });
             
            }

            return grp;
        }
    }
}
