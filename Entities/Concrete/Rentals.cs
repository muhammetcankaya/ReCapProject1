using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete
{
    public class Rentals:IEntity
    {
        public int RentId { get; set; }      // Birincil anahtar
        public int CarId { get; set; }       // Foreign key
        public int CustomerId { get; set; }  // Foreign key
        public DateTime RentDate { get; set; }
        public DateTime? ReturnDate { get; set; }
    }
}
