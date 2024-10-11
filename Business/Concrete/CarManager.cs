using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class CarManager : ICarManager
    { 
        EfCarDal _carDal;
        public CarManager(EfCarDal carDal)
        {
            _carDal = carDal;
        }



        public void Add(Car car)
        {
            if (car.DailyPrice > 50 && car.Description.Length>2)
            {
                Console.WriteLine("Ekleme işlemi Başarı ile gerçekleşti");
                _carDal.Add(car);
            }
            else 
            {
                Console.WriteLine("Araba fiyatı Bu kadar Düşük Olamaz");
            }
            
        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
        }
        public void Update(Car car)
        {
            _carDal.Update(car);
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();
        }

        public List<Car> GetById(int Id) => _carDal.GetById(Id);
        public List<Car> GetGetCarsByBrandId(int Id)
        {
            return _carDal.GetGetCarsByBrandId(Id);
        }
        public List<Car> GetGetCarsByColorId(int Id)
        { 
            return _carDal.GetCarsByColorId(Id);
        }


    }
}
