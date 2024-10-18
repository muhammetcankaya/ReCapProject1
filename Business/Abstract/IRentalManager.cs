using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IRentalManager
    {
        IResult Add(Rentals rental);
        IResult Update(Rentals rental);
        IResult Delete(Rentals rental);
        IDataResult<Rentals> GetById(int rentalId);
        IDataResult<List<Rentals>> GetAll();
    }
}
