using System;
using System.Collections.Generic;
using System.Linq;
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        public List<Car> GetCarsByColorId(int Id);
        public List<Car> GetGetCarsByBrandId(int Id);

        List<CarDetailDto> GetCarDetails();

    }
}