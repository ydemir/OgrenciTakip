using OgrenciTakip.MODEL.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.BLL.Functions
{
   public static class Converts
    {
        //İki tane functions olacak EntityConvert suan yapılacak
        //Convert işlemi yaparken iki adet entity ihtiyacımız bulunmaktadır. 
        //1 tanesi kaynak Entity diğeri Hedef Entity
        //Kaynak entity property arasına dolaşıp hedef teki ile karşılaştırıcağız. Aynı ise
        //Kaynaktakini alıp hedefe atacağız.

        //Oluşturacağımız function ı extensions method olarak oluşturacağız.
        //Extensions oluşturabilmemiz için class ve function ın static olması lazım ve ilk değişken this ile başlamı

        //Source u IBaseEntity tanımlamamızın neden biliyoruz ki bütün entitylerimiz IBaseEntity den implemente olacak ve  her halikarda bu şekilde bir kaynak gelecek

        public static TTarget EntityConvert<TTarget>(this IBaseEntity source)
        {
            if (source==null)
            {
                return default(TTarget);
            }

            //Bu şekilde hedef entitytim olan TTarget dan bir instance üretmiş olduk. 
            var hedef = Activator.CreateInstance<TTarget>();

            //Kaynak ve hedef entity property lerine reflection ile ulaşabiliriz.

            var kaynakProp = source.GetType().GetProperties();
            var hedefProp = typeof(TTarget).GetProperties();

            foreach (var kp in kaynakProp)
            {
                //Kaynak property in value sunu alıyoruz.
                //Kaynak property değerine ulaştık
                var value = kp.GetValue(source);

                //hedef property ulaşmaya çalışıyoruz.
                //Gelen kaynak prop ismini al hedef te ara buluyosan at bulamıyorsn null gelir burası
                var hp = hedefProp.FirstOrDefault(x => x.Name == kp.Name);

                if (hp!=null)
                {
                    //kAYNAKTAN gelen verilerde boi ise tırnak olarak geliyor tırnak ise null olarak kayıt edilmesini istiyorsak veritabanına aşağıdaki gibi yapıyoruz.
                    hp.SetValue(hedef, ReferenceEquals(value, "") ? null : value);
                }
            }
            return hedef;

            
        }


    }
}
