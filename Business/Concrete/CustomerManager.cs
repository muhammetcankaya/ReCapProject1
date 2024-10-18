using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results.Concrete.MessageSucces;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerManager
    {
        ICustomerDal _customerDal;
        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;      
        }
        public IResult Add(Customers customer)
        {
            _customerDal.Add(customer);
            return new ResultSuccess("Müşteri bilgisi Başarılı bir şekilde eklendi");
        }

        public IResult Delete(Customers customer)
        {
            _customerDal.Delete(customer);
            return new ResultSuccess("Müşteri bilgisi Başarılı bir şekilde Silindi");
        }

        public IDataResult<List<Customers>> GetAll()
        {
            _customerDal.GetAll();
            return new DataResult<List<Customers>>(_customerDal.GetAll(),true,"Bilgiler Başarılı Bir Şekilde Getirildi");
        }

        public IDataResult<Customers> GetById(int customerId)
        {
            _customerDal.Get(p => p.CustomerId == customerId);
            return new DataResult<Customers>(_customerDal.Get(p => p.CustomerId == customerId), true, _customerDal.Get(p => p.CustomerId == customerId) + ". Id yE SAHİP bİLGİ");
        }

        public IResult Update(Customers customer)
        {
            _customerDal.Update(customer);
            return new ResultSuccess("Müşteri bilgisi Başarılı bir şekilde Güncellendi");
        }
    }
}
