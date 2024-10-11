using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Abstract;

namespace Entities.Concrete
{
    public class Brand : IEntity
    {
        // burayı kullanmayacağız ama bulunsun
        // çıplak sınıf kalmasın
        public int BrandId { get; set; }
        public string BrandName { get; set; }
    }
}
