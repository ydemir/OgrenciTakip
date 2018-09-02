using OgrenciTakip.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OgrenciTakip.DAL.Base
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : class
    {
        private readonly DbContext _context;

        public UnitOfWork(DbContext context)
        {
            if (context == null) return;
            _context = context;
        }
        public IRepository<T> Rep => new Repository<T>(_context);

        public bool Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {

                var sqlEx =(SqlException) ex.InnerException?.InnerException;
                if (sqlEx==null)
                {

                }
            }
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
