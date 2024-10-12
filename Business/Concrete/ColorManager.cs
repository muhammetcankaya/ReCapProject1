using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using DataAccess.Abstract;
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
        public void Add(Color color)
        {
            _colorDal.Add(color);
        }

        public void Delete(Color color)
        {
            _colorDal.Delete(color);
        }

        public Color Get(int ıd)
        {
            return _colorDal.Get(color=>color.ColorId==ıd); 
        }

        public List<Color> GetAll()
        {
            return _colorDal.GetAll();
        }

        

        public void Update(Color color)
        {
            _colorDal.Update(color);
        }
    }
}
