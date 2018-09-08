using OgrenciTakip.BLL.Functions;
using OgrenciTakip.BLL.Interfaces;
using OgrenciTakip.COMMON.Enums;
using OgrenciTakip.COMMON.Functions;
using OgrenciTakip.COMMON.Message;
using OgrenciTakip.DAL.Interfaces;
using OgrenciTakip.MODEL.Attributes;
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

        private bool Validation(IslemTuru islemTuru,BaseEntity oldEntity, BaseEntity currentEntity,Expression<Func<T,bool>> filter)
        {
            var errorControl = GetValidationErrorControl();
            if (errorControl==null)
            {
                return true;
            }
            _ctrl.Controls[errorControl].Focus();
            return false;


            string GetValidationErrorControl()
            {
                string MukerrerKod()
                {
                    foreach (var property in typeof(T).GetPropertyAttributesFromType<Kod>())
                    {
                        if (property.Attribute==null)
                        {
                            continue;
                        }
                        if ((islemTuru==IslemTuru.EntityInsert|| oldEntity.Kod==currentEntity.Kod) && islemTuru==IslemTuru.EntityUpdate )
                        {
                            continue;
                        }
                        if (_uow.Rep.Count(filter)<1)
                        {
                            continue;
                        }

                        Messages.MukerrerKayitHataMesaji(property.Attribute.Description);
                        return property.Attribute.ControlName;
                    }

                    return null;
                }
                string HataliGiris()
                {
                    foreach (var property in typeof(T).GetPropertyAttributesFromType<ZorunluAlan>())
                    {
                        if (property.Attribute == null)
                        {
                            continue;
                        }


                        var value = property.Property.GetValue(currentEntity);

                        if (property.Property.PropertyType==typeof (long))
                        {
                            if ((long)value==0)
                            {
                                value = null;
                            }
                            
                        }
                        if (!string.IsNullOrEmpty(value?.ToString()))
                        {
                            continue;
                        }

                        Messages.HataliVeriMesaji(property.Attribute.Description);
                        return property.Attribute.ControlName;
                    }
                    return null;
                }

                return HataliGiris() ?? MukerrerKod();
            }
        }

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
            if (!Validation(IslemTuru.EntityInsert,null,entity,filter))
            {
                return false;
            }

            //Convert işlemi yapıp o şekilde gönderecektik.

            //Repository imizi OgrenciTakipContext de tanımlanmış olan Entity lerden bir tanesine cast ederek gönderdik.
            _uow.Rep.Insert(entity.EntityConvert<T>());
            return _uow.Save();
        }

        protected bool BaseUpdate(BaseEntity oldEntity, BaseEntity currentEntity, Expression<Func<T, bool>> filter)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
            if (!Validation(IslemTuru.EntityUpdate,oldEntity,currentEntity,filter))
            {
                return false;
            }

            var degisenAlanlar = oldEntity.DegisenAlanlariGetir(currentEntity);

            //Gelen currentEntity i TEntity e çevirmemiz lazım.

            //değişenler yoksa  liste olarak gelcek 
            if (degisenAlanlar.Count==0)
            {
                //false yaparsak sanki database de hata var o yüzden geri dönüyor gibi bir durum oluyor
                return true;
            }
            _uow.Rep.Update(currentEntity.EntityConvert<T>(), degisenAlanlar);

          
            return _uow.Save();
        }

        protected bool BaseDelete(BaseEntity entity,KartTuru kartTuru,bool mesajVer = true)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _uow);

            if (mesajVer)
            {
                if (Messages.SilMesaj(kartTuru.ToName())!=DialogResult.Yes)
                {
                    return false;
                }
            }

            _uow.Rep.Delete(entity.EntityConvert<T>());
            return _uow.Save();
        }


        protected string BaseYeniKodVer(KartTuru kartTuru,Expression<Func<T,string>> filter,Expression<Func<T,bool>> where=null)
        {
            GeneralFunctions.CreateUnitOfWork<T, TContext>(ref _uow);
           return _uow.Rep.YeniKodVer(kartTuru,filter,where);

        }

        #region IDisposable dispose

       

  
  
        public void Dispose()
        {
            //komple bll i dispose edersek hata alırız sadece unitofwork  u dispose edeceğiz.
            _ctrl?.Dispose();
            _uow.Dispose();
         

        }
        #endregion
    }
}
