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
    public class UserManager : IUserManager
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal=userDal;
        }
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new ResultSuccess("Ekleme İşlemi Başarılı");
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new ResultSuccess("Silme İşlemi Başarılı");
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new ResultSuccess("Güncelleme İŞlemi Başarılı");
        }
        public IDataResult<List<User>> GetAll()
        {
            _userDal.GetAll();
            return new DataResult<List<User>>(_userDal.GetAll(),true,"Bilgiler Başarılı Bir Şekilde Getirildi");
        }

        public IDataResult<User> GetById(int userId)
        {
            _userDal.Get(p => p.UserId == userId);
            return new DataResult<User>(_userDal.Get(p => p.UserId == userId), true, _userDal.Get(p => p.UserId == userId).UserId+".Kullanıcı bilgileri başarılı bir şekilde getirildi");
        }

    }
}
