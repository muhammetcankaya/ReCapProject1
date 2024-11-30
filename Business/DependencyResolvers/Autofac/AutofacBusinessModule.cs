using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.D;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    //builder.Services.AddSingleton<IBrandManager,BrandManager>();
    //        builder.Services.AddSingleton<IBrandDal, EfBrandDal>();

    //        builder.Services.AddSingleton<IColorManager, ColorManager>();
    //        builder.Services.AddSingleton<IColorDal, EfColorDal>();

    //        builder.Services.AddSingleton<ICarManager, CarManager>();
    //        builder.Services.AddSingleton<ICarDal, EfCarDal>();

    //        builder.Services.AddSingleton<IUserManager, UserManager>();
    //        builder.Services.AddSingleton<IUserDal, EfUserDal>();

    //        builder.Services.AddSingleton<ICustomerManager, CustomerManager>();
    //        builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();

    //        builder.Services.AddSingleton<IRentalManager, RentalManager>();
    //        builder.Services.AddSingleton<IRentalDal, EfRentalDal>();
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BrandManager>().As<IBrandManager>().SingleInstance();
            builder.RegisterType<EfBrandDal>().As<IBrandDal>().SingleInstance();

            builder.RegisterType<ColorManager>().As<IColorManager>().SingleInstance();
            builder.RegisterType<EfColorDal>().As<IColorDal>().SingleInstance();

            builder.RegisterType<CarManager>().As<ICarManager>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserManager>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<CustomerManager>().As<ICustomerManager>().SingleInstance();
            builder.RegisterType<EfCustomerDal>().As<ICustomerDal>().SingleInstance();

            builder.RegisterType<RentalManager>().As<IRentalManager>().SingleInstance();
            builder.RegisterType<EfRentalDal>().As<IRentalDal>().SingleInstance();

            builder.RegisterType<CarImageManager>().As<ICarImageManager>().SingleInstance();
            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();

            builder.RegisterType<JwtHelper>().As<ITokenHelper>();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
