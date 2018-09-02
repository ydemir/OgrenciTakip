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
            return _uow.Rep.Find(filter, selector);
        }




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
