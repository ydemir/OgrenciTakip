using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using OgrenciTakip.UI.Win.Interfaces;
using System;
using System.ComponentModel;
using System.Drawing;

namespace OgrenciTakip.UI.Win.UserControls.Controls
{
    [ToolboxItem(true)]
    public class MyButtonEdit :ButtonEdit, IStatusBarKisaYol
    {
      
        public MyButtonEdit()
        {
            Properties.TextEditStyle = TextEditStyles.DisableTextEditor;
            Properties.AppearanceFocused.BackColor = Color.LightCyan;

        }
        public override bool EnterMoveNextControl { get; set; } = true;
        public string StatusBarAciklama { get; set; }
        public string StatusBarKisaYol { get; set; } = "F4";
        public string StatusBarKisaYolAciklama { get; set; }


        #region Events
        private long? _id;

        [Browsable(false)]
        public long? Id
        {
            get => _id;
            set
            {
                var oldValue = _id;
                var newValue = value;

                if (newValue == oldValue) return;

                _id = value;

                //idchanged null değilse invoke et bu delegete i çağır
                IdChanged(this, new IdChangedEventArgs(oldValue, newValue));


            }
        }



        public event EventHandler<IdChangedEventArgs> IdChanged = delegate { }; 
        #endregion

    }

    public class IdChangedEventArgs : EventArgs
    {

        public IdChangedEventArgs(long? oldValue,long? newValue)
        {
            OldValue = oldValue;
            NewValue = newValue;
        }

        public long? OldValue { get;  }
        public long? NewValue { get;  }
    }
}
