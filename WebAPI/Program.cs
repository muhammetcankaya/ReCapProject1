
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Business.Abstract;
using Business.Concrete;
using Business.DependencyResolvers.Autofac;
using Core.D;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
            builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterModule(new AutofacBusinessModule());


                });




            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //builder.Services.AddSingleton<IBrandManager,BrandManager>();
            //builder.Services.AddSingleton<IBrandDal, EfBrandDal>();

            //builder.Services.AddSingleton<IColorManager, ColorManager>();
            //builder.Services.AddSingleton<IColorDal, EfColorDal>();

            //builder.Services.AddSingleton<ICarManager, CarManager>();
            //builder.Services.AddSingleton<ICarDal, EfCarDal>();

            //builder.Services.AddSingleton<IUserManager, UserManager>();
            //builder.Services.AddSingleton<IUserDal, EfUserDal>();

            //builder.Services.AddSingleton<ICustomerManager, CustomerManager>();
            //builder.Services.AddSingleton<ICustomerDal, EfCustomerDal>();

            //builder.Services.AddSingleton<IRentalManager, RentalManager>();
            //builder.Services.AddSingleton<IRentalDal, EfRentalDal>();



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
