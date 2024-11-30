using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Concrete;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(p => p.FirstName).MinimumLength(3).NotEmpty();
            RuleFor(p => p.LastName).MinimumLength(3).NotEmpty();
            RuleFor(p => p.Email).EmailAddress();
            
            // password için küçük harf büyük harf içermeli gibi şeyler koyabiliriz öğrenirsek tabi
        }
    }
}
