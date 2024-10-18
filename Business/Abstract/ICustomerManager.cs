using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerManager
    {
        IResult Add(Customers customer);
        IResult Update(Customers customer);
        IResult Delete(Customers customer);
        IDataResult<Customers> GetById(int customerId);
        IDataResult<List<Customers>> GetAll();
    }
}
