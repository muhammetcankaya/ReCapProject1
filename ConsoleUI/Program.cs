using System;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;




namespace ConsoleUI
{
    public class Program
    {
        // soyut classları Abstracta ıınterface base
        // somut nesneleri Concrete koyacağız
        static void Main(string[] args)
        {
            //Car car1 = new Car();
            ////car1.CarId = 23;
            //car1.BrandId = 2;
            //car1.ColorId = 1;
            //car1.Description = "Renault R9";
            //car1.DailyPrice = 51;
            //car1.ModelYear = 1999;
            //CarManager carManager = new CarManager(new EfCarDal());
            //carManager.Add(car1);
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var x =brandManager.GetAll();
            foreach (var item in x)
            {
                Console.WriteLine(item.BrandName);
                
            }
            //var car = carManager.GetGetCarsByBrandId(4);
            //foreach (var item in car)
            //{
            //    Console.WriteLine(item.Description);
            //}
        }
    }
}

