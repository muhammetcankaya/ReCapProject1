using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarManager
    {
        public List<Car> GetGetCarsByBrandId(int Id);
        public List<Car> GetGetCarsByColorId(int Id);
        Car Get(int ıd);
        List<Car> GetAll();
        List<CarDetailDto> GetCarDetails();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
