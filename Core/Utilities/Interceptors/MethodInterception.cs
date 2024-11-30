using Castle.DynamicProxy;
using static Core.Utilities.Interceptors.Class1;



namespace Core.Utilities.Interceptors
{
    public abstract class MethodInterception : MethodInterceptionBaseAttribute
    {
        protected virtual void OnBefore(IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnException(IInvocation invocation, System.Exception e) { }
        protected virtual void OnSuccess(IInvocation invocation) { }
        public override void Intercept(IInvocation invocation)
        {
            //trycatch tekrar bir bak 
            var isSuccess = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception e)
            {
                isSuccess = false;
                OnException(invocation, e);
                throw;
            }
            finally
            {
                if (isSuccess)
                {
                    OnSuccess(invocation);
                }
            }
            OnAfter(invocation);
        }
    }
}
//public abstract class MethodInterception : MethodInterceptionBaseAttribute:

//Bu sınıf, MethodInterceptionBaseAttribute sınıfından türetilmiştir ve 
//    AOP işlemlerinin uygulanmasında kullanılır. 
//    Metodların başında ve sonunda yapılacak işlemleri kontrol eder.

//public override void Intercept(IInvocation invocation):

//Intercept metodu, IInvocation nesnesi ile çalışır ve metodu intercept
//etmek için kullanılan ana metottur.
//var isSuccess = true;: İlk olarak isSuccess adında bir 
//boolean değişkeni tanımlanır. Eğer metod başarılı bir şekilde çalışırsa true kalır, hata alırsa false olur.
//OnBefore(invocation);: Metod çağrılmadan önce yapılacak
//işlemler çağrılır.
//invocation.Proceed();: Bu satır, metodun normal işlevini çalıştırır.
//Eğer burada bir hata oluşursa, catch bloğuna düşer.
//catch (Exception e): Eğer metod çalışırken bir hata meydana gelirse,
//hata burada yakalanır ve isSuccess değeri false yapılır.
//Ayrıca OnException metodu çağrılır.
//finally: Son olarak, metod başarılı bir şekilde çalıştıysa OnSuccess
//çağrılır. Her durumda ise OnAfter çağrılır