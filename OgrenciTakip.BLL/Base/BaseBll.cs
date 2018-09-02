using OgrenciTakip.BLL.Functions;
using OgrenciTakip.BLL.Interfaces;
using OgrenciTakip.DAL.Interfaces;
using OgrenciTakip.MODEL.Entities.Base;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OgrenciTakip.BLL.Base
{
   public class BaseBll<T,TContext> :IBaseBll where T:BaseEntity where TContext:DbContext
    {
        private readonly Control _ctrl;
        private IUnitOfWork<T> _uow;
        protected BaseBll() { }

        protected BaseBll(Control ctrl)
        {
            _ctrl = ctrl;
        }

        protected TResult BaseSingle<TResult>(Expression<Func<T,bool>> filter,Expression<Func<T,TResult>> selector)
        {
            //Projemizde 2 modül olacak Yönetim Modulu ve Ogrenci takip Modülü, giriş yaparken iki farklı context olduğu için sürekli değişecek
            //Her zaman güncel connection string e ihtiyacımız olacaak 
            //Bu yüzden UnitOfWrok Function ı oluşturduk.
            //
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            return _uow.Rep.Find(filter, selector);
        }

        protected IQueryable<TResult> BaseList<TResult>(Expression<Func<T,bool>>filter,Expression<Func<T,TResult>> selector)
        {
            //Her seferinde UnitofWork un instance ını alacaağız çünkü güncel connection string ile işlem yapacağız.
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            return _uow.Rep.Select(filter, selector);
        }

        protected bool BaseInsert(BaseEntity entity,Expression<Func<T,bool>> filter)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            //Validation işlemleri yapılacak

            //Convert işlemi yapıp o şekilde gönderecektik.

            //Repository imizi OgrenciTakipContext de tanımlanmış olan Entity lerden bir tanesine cast ederek gönderdik.
            _uow.Rep.Insert(entity.EntityConvert<T>());
            return _uow.Save();
        }

        //protected bool BaseUpdated(BaseEntity oldEntity,BaseEntity currentEntity,Expression<Func<T,bool>> filter)
        //{
        //    GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
        //    //Validation

        //    var degisenAlanlar=
        //}




        #region IDisposable Support
        private bool disposedValue = false;
       

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
              
                }

            

                disposedValue = true;
            }
        }

  
        public void Dispose()
        {
           
            Dispose(true);
         

        }
        #endregion
    }
}
