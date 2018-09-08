using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.MODEL.Attributes
{
   public class Kod :Attribute
    {
        public string Description { get; }
        public string ControlName { get; set; }

        /// <summary>
        /// Validation İşlemleri sırasında Zorunlu olan Alanları İşaretlemek İçin Kullanılacak
        /// </summary>
        /// <param name="descripiton">Uyarı Mesajında gösterilecek olan açıklama</param>
        /// <param name="controlName">Uyarı Mesajı sonrası focus işlemi yapılacak kontrol adı.</param>
        public Kod(string descripiton, string controlName)
        {
            Description = descripiton;
            ControlName = controlName;
        }
    }
}
