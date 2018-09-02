using OgrenciTakip.COMMON.Message;
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
                    Messages.HataMesaji(ex.Message);
                    return false;
                }

                switch (sqlEx.Number)
                {
                    case 208:
                        Messages.HataMesaji("İşlem Yapmak İstediğiniz Tablo Veritabanında Bulunamadı");
                        break;
                    case 547:
                        Messages.HataMesaji("Seçilen Kartın İşlem Görmüş Hareketleri Var Silinemez.");
                        break;
                    case 2601:
                    case 2627:
                        Messages.HataMesaji("Girmiş Olduğunuz Id Daha Önce Kullanılmıştır.");
                        break;
                    case 4060:
                        Messages.HataMesaji("İşlem Yapmak İstediğiniz Veritabanı Sunucuda Bulunamadı.");
                        break;
                    case 18456:
                        Messages.HataMesaji("Server'a Bağlanılmak İstenen Kullanıcı Adı ve Şifre Hatalıdır.");
                        break;
                    default:
                        Messages.HataMesaji(sqlEx.Message);
                        break;
                }
                return false;
            }

            catch(Exception ex)
            {
                Messages.HataMesaji(ex.Message);
                return false;

            }
            return true;
        }

        #region Dispose
        private bool _disposedValue = false;
        

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
                }


                _disposedValue = true;
            }
        }


    
        public void Dispose()
        {
    
            Dispose(true);
            GC.SuppressFinalize(this);
      
        }
        #endregion
    }
}
