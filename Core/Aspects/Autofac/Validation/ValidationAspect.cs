using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Autofac.Features.Metadata;
using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Bu bir doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}


//public class ValidationAspect : MethodInterception:

//Bu sınıf, AOP altyapısının bir parçasıdır ve MethodInterception sınıfından türetilmiştir. Validation (doğrulama) işlemlerini metodlar çalışmadan önce yapar.
//private Type _validatorType;:

//Bu alan, doğrulama işlemlerinde kullanılacak olan validator sınıfının tipini tutar.
//Constructor (ValidationAspect):

//public ValidationAspect(Type validatorType):
//Kullanıcıdan bir validator tipi alır.
//if (!typeof(IValidator).IsAssignableFrom(validatorType)):
//Eğer verilen tip, IValidator arayüzünü implement etmemişse bir hata fırlatır.
//Bu kontrol, doğru bir validator sınıfı gönderildiğinden emin olmak için yapılır.
//_validatorType = validatorType;:
//Gelen validator tipi özel bir alanda saklanır.
//protected override void OnBefore(IInvocation invocation):

//Bu metod, metod çağrılmadan önce çalıştırılır ve doğrulama işlemini gerçekleştirir.
//var validator = (IValidator)Activator.CreateInstance(_validatorType);:
//_validatorType ile belirtilen validator sınıfının bir örneğini dinamik olarak oluşturur.
//var entityType = _validatorType.BaseType.GetGenericArguments()[0];:
//Validator sınıfının hangi entity tipiyle çalıştığını bulur. Örneğin, CarValidator sınıfı Car tipiyle çalışır.
//var entities = invocation.Arguments.Where(t => t.GetType() == entityType);:
//Metoda gönderilen parametrelerden, validator'ın doğruladığı entity türüne uygun olanları alır.
//Foreach Döngüsü:
//foreach (var entity in entities):
//Tüm entity'ler üzerinde gezinir.
//ValidationTool.Validate(validator, entity);:
//Her bir entity için doğrulama işlemi yapar. Doğrulama işlemi ValidationTool aracılığıyla gerçekleştirilir.
//public class ValidationAspect : MethodInterception:

//Bu sınıf, AOP altyapısının bir parçasıdır ve MethodInterception sınıfından türetilmiştir. Validation (doğrulama)
//işlemlerini metodlar çalışmadan önce yapar.
//private Type _validatorType;:

//Bu alan, doğrulama işlemlerinde kullanılacak olan validator sınıfının tipini tutar.
//Constructor (ValidationAspect):

//public ValidationAspect(Type validatorType):
//Kullanıcıdan bir validator tipi alır.
//if (!typeof(IValidator).IsAssignableFrom(validatorType)):
//Eğer verilen tip, IValidator arayüzünü implement etmemişse bir hata fırlatır.
//Bu kontrol, doğru bir validator sınıfı gönderildiğinden emin olmak için yapılır.
//_validatorType = validatorType;:
//Gelen validator tipi özel bir alanda saklanır.
//protected override void OnBefore(IInvocation invocation):

//Bu metod, metod çağrılmadan önce çalıştırılır ve doğrulama işlemini gerçekleştirir.
//var validator = (IValidator)Activator.CreateInstance(_validatorType);:
//_validatorType ile belirtilen validator sınıfının bir örneğini dinamik olarak oluşturur.
//var entityType = _validatorType.BaseType.GetGenericArguments()[0];:
//Validator sınıfının hangi entity tipiyle çalıştığını bulur. Örneğin, CarValidator sınıfı Car tipiyle çalışır.
//var entities = invocation.Arguments.Where(t => t.GetType() == entityType);:
//Metoda gönderilen parametrelerden, validator'ın doğruladığı entity türüne uygun olanları alır.
//Foreach Döngüsü:
//foreach (var entity in entities):
//Tüm entity'ler üzerinde gezinir.
//ValidationTool.Validate(validator, entity);:
//Her bir entity için doğrulama işlemi yapar. Doğrulama işlemi ValidationTool aracılığıyla gerçekleştirilir.