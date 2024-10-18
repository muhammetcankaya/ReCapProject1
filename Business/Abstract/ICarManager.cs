using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface ICarManager
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<Car> GetById(int carId);
        IDataResult<List<Car>> GetAll();

        IDataResult<List<Car>> GetGetCarsByColorId(int Id);
        IDataResult<List<Car>> GetGetCarsByBrandId(int Id);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        //getbyıd içinde get kullanıcaz get operasyonunu buraya yazmanın bir anlamı yok
        // aslında aynı şey ama gerek yok 
        // get by ıd yi özelliştirmek daha iyi
    }
}
