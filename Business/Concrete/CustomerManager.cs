using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
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
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Add(Customer customer)
        {
            _customerDal.Add(customer);
            return new ResultSuccess("Müşteri bilgisi Başarılı bir şekilde eklendi");
        }
        [ValidationAspect(typeof(CustomerValidator))]
        public IResult Delete(Customer customer)
        {
            _customerDal.Delete(customer);
            return new ResultSuccess("Müşteri bilgisi Başarılı bir şekilde Silindi");
        }

        public IDataResult<List<Customer>> GetAll()
        {
            _customerDal.GetAll();
            return new DataResult<List<Customer>>(_customerDal.GetAll(),true,"Bilgiler Başarılı Bir Şekilde Getirildi");
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            _customerDal.Get(p => p.CustomerId == customerId);
            return new DataResult<Customer>(_customerDal.Get(p => p.CustomerId == customerId), true, _customerDal.Get(p => p.CustomerId == customerId) + ". Id yE SAHİP bİLGİ");
        }

        public IResult Update(Customer customer)
        {
            _customerDal.Update(customer);
            return new ResultSuccess("Müşteri bilgisi Başarılı bir şekilde Güncellendi");
        }
    }
}
