using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car{CarId=1,BrandId=1,ColorId=2,ModelYear=2010,DailyPrice=60000,Description="Sedan"},
                new Car{CarId=2,BrandId=2,ColorId=2,ModelYear=2015,DailyPrice=80000,Description="Sedan"},
                new Car{CarId=3,BrandId=3,ColorId=1,ModelYear=2020,DailyPrice=600000,Description="Hackpackhe"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car CarToDelete = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            _cars.Remove(CarToDelete);
        }
        public void Update(Car car)
        {
            Car CarToUpdate = _cars.SingleOrDefault(p => p.CarId == car.CarId);
            CarToUpdate.BrandId = car.BrandId;
            CarToUpdate.ColorId = car.ColorId;
            CarToUpdate.ModelYear = car.ModelYear;
            CarToUpdate.DailyPrice = car.DailyPrice;
            CarToUpdate.Description = car.Description;

        }
        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetById(int Id)
        {

            return _cars.Where(p => p.CarId == Id).ToList();




        }


    }
}
