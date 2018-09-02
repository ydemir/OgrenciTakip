using OgrenciTakip.DAL.Base;
using OgrenciTakip.DAL.Interfaces;
using OgrenciTakip.MODEL.Entities.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;

namespace OgrenciTakip.BLL.Functions
{
    public static  class GeneralFunctions
    {
        //Extensions method olarak tanımlamak istiyorsak this anahtar kelimesini kullanmalıyız.
        public static List<string> DegisenAlanlariGetir<T>(this T oldEntity, T currentEntity)
        {
            List<string> alanlar = new List<string>();

            //foreach i reflection yaparak dolaşıyoruz.
            foreach (var prop in currentEntity.GetType().GetProperties())
            {
                //Örnek olarak ile bağlı ilçelere ICollection<Ilce> Ilce get set ile ulaşabiliyoruz.
                //Entity de dolaşırken aşağıdaki property gelecek eğer aşağıdaki gibi ise herhangi işlem yapma contnue yap yani bir sonraki işleme geç
                if (prop.PropertyType.Namespace == "System.Collections.Generic") continue;
                {
                    //iki tane soru işareti ile gelen değer null ise strişng empty yap old ile current biri null biri string empty olursa karşılaştırılamaz.
                    //
                    var oldValue = prop.GetValue(oldEntity)??string.Empty;
                    var currentValue = prop.GetValue(currentEntity) ?? string.Empty;

                    if (prop.PropertyType==typeof(byte[]))
                    {
                        if (string.IsNullOrEmpty(oldValue.ToString()))
                        {
                            oldValue = new byte[] { 0 };
                        }
                        if (string.IsNullOrEmpty(currentEntity.ToString()))
                        {
                            //byte olduğu için default değerini sıfır yaptık
                            currentValue = new byte[] { 0 };
                        }
                        if (((byte[])oldValue).Length!=((byte[]) currentValue).Length) 
                        {
                            alanlar.Add(prop.Name);
                        }
                    }
                    else if (!currentValue.Equals(oldValue))
                    {
                        alanlar.Add(prop.Name);
                    }

                }
            }
            return alanlar;
        }

        //Projemizde 2 modül olacak Yönetim Modulu ve Ogrenci takip Modülü, giriş yaparken iki farklı context olduğu için sürekli değişecek
        //Her zaman güncel connection string e ihtiyacımız olacaak 
        //Bu yüzden UnitOfWrok Function ı oluşturduk.

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["OgrenciTakipContext"].ConnectionString;
        }

        //AppConfig dosyasına gider Context in en son halini alıp bir connection string oluşturup geri döner.

        private static TContext CreateContext<TContext>() where TContext:DbContext
        {
            return (TContext) Activator.CreateInstance(typeof(TContext), GetConnectionString());
        }

        public static void CreateUnitOfWork<T,TContext>(ref IUnitOfWork<T> uow) where T:class,IBaseEntity where TContext:DbContext
        {
            uow?.Dispose();

            //Bir adet UnitOfWork Create etmiş olduk.
            uow = new UnitOfWork<T>(CreateContext<TContext>());
        }
    }
}
