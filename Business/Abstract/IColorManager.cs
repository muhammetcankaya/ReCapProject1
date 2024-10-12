using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IColorManager
    {
        Color Get(int ıd);
        List<Color> GetAll();
        void Add(Color color);
        void Update(Color color);
        void Delete(Color color);
    }
}

