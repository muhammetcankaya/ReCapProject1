﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results.Concrete.DataMessageSucces;
using Core.Utilities.Results.Concrete.MessageSucces;
using DataAccess.Abstract;




namespace Business.Concrete
{
    public class UserManager : IUserManager
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal=userDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new ResultSuccess("Ekleme İşlemi Başarılı");
        }
        [ValidationAspect(typeof(UserValidator))]
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

        public IDataResult<User> GetByMail(string email)
        {
            return new DataResultSuccess<User>( _userDal.Get(u => u.Email == email));
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            return new DataResultSuccess<List<OperationClaim>>(_userDal.GetClaims(user));
        }
    }
}
