using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(p => p.ColorId).GreaterThan(0).LessThan(7);
            RuleFor(p => p.BrandId).GreaterThan(0).LessThan(4);
            RuleFor(p => p.Description).MinimumLength(5);
            RuleFor(p => p.DailyPrice).NotEmpty().GreaterThan(100);
            RuleFor(p => p.ModelYear).GreaterThan(2000).NotEmpty();
            RuleFor(p => p.CarName).MinimumLength(3).NotEmpty();
        }
    }
}
//// Rulefor product için yani hangi nesneyi verirsen onun için
////buraya validation kuralları yazılabilir
//RuleFor(p => p.Productname).NotEmpty();
//RuleFor(p => p.Productname).MinimumLength(2);
//RuleFor(p => p.UnitPrice).NotEmpty();
//RuleFor(p => p.UnitPrice).GreaterThan(0);
////altta unitprice 10dan büyük eşit olacak when yani categoryıd 1 oldupunda
//RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);

//// BURAYA KENDİ METODUMUZU YAZDIK 
//// A ile başlamak zorunda dedik
//RuleFor(p => p.Productname).Must(StartwithA);

//        }

//        private bool StartwithA(string arg)
//{
//    return arg.StartsWith("A");
//}
