using System;
using Business.Concrete;
using Core.D;
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
            //Brandtest();


            Cartest();
        }

        private static void Cartest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var car = carManager.GetCarDetails();
            foreach (var item in car)
            {
                Console.WriteLine("Araba ismi: "+item.Description+"  Marka Adı: "+item.BrandName+"  Renk: "+item.ColorName+"  Fiyat: "+item.DailyPrice);
            }
        }

        private static void Brandtest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var x = brandManager.GetAll();
            foreach (var item in x)
            {
                Console.WriteLine(item.BrandName);

            }
        }
    }
}

