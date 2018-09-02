using OgrenciTakip.DAL.Base;
using OgrenciTakip.DAL.Interfaces;
using OgrenciTakip.MODEL.Entities.Base.Interfaces;
using System;
using System.Configuration;
using System.Data.Entity;

namespace OgrenciTakip.BLL.Functions
{
    public  class GeneralFunctions
    {
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
