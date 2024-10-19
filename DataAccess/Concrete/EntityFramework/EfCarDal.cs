using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityFrameworkBase<Car, ReCapProject>, ICarDal
    {


        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProject Context = new ReCapProject())
            {
                var result = from c in Context.Cars
                             join b in Context.Brands
                             on c.BrandId equals b.BrandId
                             join d in Context.Colors
                             on c.ColorId equals d.ColorId
                             select new CarDetailDto { Description = c.Description, BrandName = b.BrandName, ColorName = d.ColorName, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
           
            
        }
    }
}
