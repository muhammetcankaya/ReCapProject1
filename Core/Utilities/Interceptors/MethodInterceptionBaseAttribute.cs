using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    public partial class Class1
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
        public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
        {
            public int Priority { get; set; }

            public virtual void Intercept(IInvocation invocation)
            {

            }
        }
    }
}
//[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]:

//Bu attribute, sınıf veya metod üzerine uygulanabilir olduğunu belirtir.
//AllowMultiple = true: Aynı sınıf veya metod üzerine birden fazla kez kullanılmasına izin verir.
//Inherited = true: Bu attribute, sınıf mirasıyla birlikte miras alınabil

//public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor:

//Bu sınıf, Attribute sınıfından türemektedir,
//    yani bir sınıf veya metod üzerine uygulamak için kullanılacak bir işaretçidir.
//    Ayrıca, IInterceptor
//    arayüzünü implement eder, bu da metodlara müdahale etme işlevselliği sağlar.

//public virtual void Intercept(IInvocation invocation):

//Bu metod, metodun çalışmasını intercept etmek için kullanılan temel metodtur.
//    Ancak burada sadece boş bir metod tanımlanmış,
//    MethodInterception sınıfında daha ayrıntılı olarak doldurulacaktır. 
//    Metodun başında veya sonunda yapılacak işlemler burada yönetilebilir.


