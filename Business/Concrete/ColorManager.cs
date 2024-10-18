using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;

namespace Business.Concrete
{
    public class ColorManager : IColorManager
    {
        IColorDal _colorDal;
        public ColorManager(IColorDal color)
        {
             _colorDal = color;
        }
        public IResult Add(Color color)
        {
            _colorDal.Add(color);
            return new Result(true, "geçici ");

        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new Result(true, "geçici ");
        }

        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new Result(true, "geçici ");
        }

        public IDataResult<Color> GetById(int Id)
        {
            return new DataResult<Color>(_colorDal.Get(p => p.ColorId == Id), true, "geçici");
        }

        public IDataResult<List<Color>> GetAll()
        {
            _colorDal.GetAll();
            return new DataResult<List<Color>>(_colorDal.GetAll(), true, "geçici");
        }
    }
}
