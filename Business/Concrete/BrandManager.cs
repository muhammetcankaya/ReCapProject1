using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
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
        public void Add(Brand brand)
        {
            _brandDal.Add(brand);
        }

        public void Delete(Brand brand)
        {
           _brandDal.Delete(brand);
        }

        public Brand Get(int ıd)
        {
            return _brandDal.Get(b=>b.BrandId==ıd);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();  
        }


        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
