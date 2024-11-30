using System.Reflection;
using Castle.DynamicProxy;
using static Core.Utilities.Interceptors.Class1;
// intercepter araya girmek 
// metodun başı veya sonu hata veridiğinde araya girmek
namespace Core.Utilities.Interceptors
{
    public class AspectInterceptorSelector : IInterceptorSelector
    {
        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }
}

//public class AspectInterceptorSelector : IInterceptorSelector:

//AspectInterceptorSelector, IInterceptorSelector arayüzünü implement eder. Bu sınıf, hangi Interceptor'ların hangi metodlarda çalışacağına karar verir.
//public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors):

//Bu metod, hangi Interceptor'ların hangi metodlarda çalışacağını belirler.
//type.GetCustomAttributes<MethodInterceptionBaseAttribute>(true).ToList();: Sınıfın üzerine eklenen tüm
//MethodInterceptionBaseAttribute attribute'larını alır.
//type.GetMethod(method.Name).GetCustomAttributes<MethodInterceptionBaseAttribute>(true);: İlgili metodun üzerine eklenen
//tüm MethodInterceptionBaseAttribute attribute'larını alır.
//classAttributes.AddRange(methodAttributes);: Hem sınıfın hem de metodun üzerine eklenen attribute'ları birleştirir.
//return classAttributes.OrderBy(x => x.Priority).ToArray();: Priority değerine göre sıralanmış interceptor'lar döndürülür.
//Bu sıralama, hangi interceptor'ın önce çalışacağını belirler.
