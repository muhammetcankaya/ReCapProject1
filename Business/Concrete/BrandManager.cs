﻿using System;
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

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();  
        }

        public List<Brand> GetById(int Id) => _brandDal.GetById(Id);

        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
