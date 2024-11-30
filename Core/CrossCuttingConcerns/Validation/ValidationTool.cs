using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Core.Utilities.Results.Concrete;
using FluentValidation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity) 
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}

//using FluentValidation:

//FluentValidation kütüphanesini kullanır. Bu, doğrulama kurallarını tanımlamak ve
//çalıştırmak için kullanılan bir araçtır.
//public static class ValidationTool :

//Validation işlemleri için yardımcı bir araçtır.Bu sınıf static olarak tanımlanmıştır,
//çünkü sadece doğrulama yapmak için kullanılır ve bir örneği oluşturulmaz.
//public static void Validate(IValidator validator, object entity):

//Bu metod, verilen validator ve entity üzerinde doğrulama işlemi yapar.
//IValidator validator: Doğrulama işlemlerini gerçekleştirecek olan validator örneği.
//object entity: Doğrulama işlemi yapılacak nesne.
//var context = new ValidationContext<object>(entity);:

//Doğrulama işlemi için bir ValidationContext oluşturur.
//Bu context, doğrulama işleminin hangi entity üzerinde yapılacağını belirtir.
//var result = validator.Validate(context);:

//Verilen validator ve context kullanılarak doğrulama işlemini çalıştırır.
//result: Doğrulama sonucu, IsValid özelliği ve hata bilgilerini içerir.
//if (!result.IsValid):

//Eğer doğrulama başarısızsa (IsValid == false):
//throw new ValidationException(result.Errors);:
//Doğrulama hatalarını içeren bir istisna (exception) fırlatır.
//Bu, kullanıcıya doğrulama hataları hakkında bilgi sağlar.