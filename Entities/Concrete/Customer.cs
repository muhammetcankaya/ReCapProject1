using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Customer:IEntity
    {
        public int CustomerId { get; set; } // Birincil anahtar
        public int UserId { get; set; }      // Users ile ilişki
        public string CompanyName { get; set; }


    }
}
