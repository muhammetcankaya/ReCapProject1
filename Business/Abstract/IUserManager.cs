using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IUserManager
    {
        IResult Add(Users user);
        IResult Update(Users user);
        IResult Delete(Users user);
        IDataResult<Users> GetById(int userId);
        IDataResult<List<Users>> GetAll();
    }
}
