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
        public List<Car> GetGetCarsByBrandId(int Id)
        {
            using (ReCapProject context = new ReCapProject())
            {
                // ID'ye göre veritabanında ilgili arabaları bul ve liste olarak döndür
                return context.Car
                              .Where(c => c.BrandId == Id)  // CarId'ye göre filtreleme
                              .ToList();  // Liste olarak döndürme
            }
        }
        public List<Car> GetCarsByColorId (int Id)
        {
            using (ReCapProject context = new ReCapProject())
            {
                // ID'ye göre veritabanında ilgili arabaları bul ve liste olarak döndür
                return context.Car
                              .Where(c => c.ColorId == Id)  // CarId'ye göre filtreleme
                              .ToList();  // Liste olarak döndürme
            }
        }

        public List<CarDetailDto> GetCarDetails()
        {
            using (ReCapProject Context = new ReCapProject())
            {
                var result = from c in Context.Car
                             join b in Context.Brand
                             on c.BrandId equals b.BrandId
                             join d in Context.Color
                             on c.ColorId equals d.ColorId
                             select new CarDetailDto { Description = c.Description, BrandName = b.BrandName, ColorName = d.ColorName, DailyPrice = c.DailyPrice };
                return result.ToList();
            }
           
            
        }
    }
}
