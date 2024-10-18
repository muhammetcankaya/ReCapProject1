using System;
using System.Collections.Generic;
using System.Linq;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using Core.Utilities.Results.Concrete.MessageSucces;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;

namespace Core.D
{
    public class CarManager : ICarManager
    { 
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }


        public IResult Add(Car car)
        {
            if (car.DailyPrice > 50 && car.Description.Length > 2)
            {
                
                _carDal.Add(car);
                return new ResultSuccess("Ekleme İşlemi Başarıyla gerçekleiştir");

            }
            return new ResultError("Ekleme işlemi yapılamadı kurallara Uygun haraket ediniz");
            
            
        }

        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new Result(true,"geçici ");
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new Result(true, "geçici ");
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new DataResult<Car>(_carDal.Get(p=>p.CarId==carId),true,"geçici");
        }

        public IDataResult<List<Car>> GetAll()
        {
            _carDal.GetAll();
            return new DataResult<List<Car>>(_carDal.GetAll(), true, "geçici");
        }

        public IDataResult<List<Car>> GetGetCarsByColorId(int Id)
        {
            _carDal.GetAll();
            return new DataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == Id), true, "geçici");
        }

        public IDataResult<List<Car>> GetGetCarsByBrandId(int Id)
        {
            _carDal.GetAll();
            return new DataResult<List<Car>>(_carDal.GetAll(b => b.ColorId == Id), true, "geçici");
        }

        public IDataResult<List<CarDetailDto>> GetCarDetails()
        {
            _carDal.GetAll();
            return new DataResult<List<CarDetailDto>>(_carDal.GetCarDetails(), true, "geçici");
        }
      

    }
}
