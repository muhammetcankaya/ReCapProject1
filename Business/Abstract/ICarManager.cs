using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarManager
    {
        public List<Car> GetGetCarsByBrandId(int Id);
        public List<Car> GetGetCarsByColorId(int Id);
        List<Car> GetById(int Id);
        List<Car> GetAll();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);
    }
}
