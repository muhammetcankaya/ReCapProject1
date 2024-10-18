using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete.MessageSucces;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;


namespace Business.Concrete
{
    public class BrandManager : IBrandManager
    {
        IBrandDal _brandDal;
        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
                
        }
        public IResult Add(Brand brand)
        {
            _brandDal.Add(brand);
            return new Result(true, "geçici ");

        }

        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new Result(true, "geçici ");
        }

        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new Result(true, "geçici ");
        }

        public IDataResult<Brand> GetById(int Id)
        {
            return new DataResult<Brand>(_brandDal.Get(p => p.BrandId == Id), true, "geçici");
        }

        public IDataResult<List<Brand>> GetAll()
        {
            _brandDal.GetAll();
            return new DataResult<List<Brand>>(_brandDal.GetAll(), true, "geçici");
        }



    }
}
