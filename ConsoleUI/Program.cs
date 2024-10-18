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
        // mükemmel çalışyor 
        // soyut classları Abstracta ıınterface base
        // somut nesneleri Concrete koyacağız
        static void Main(string[] args)
        {

            RentalManager rentalManager =new RentalManager(new EfRentalDal());
            rentalManager.Add(new Rentals{CarId=1,CustomerId=4,RentDate=DateTime.Now,ReturnDate=DateTime.Now.AddDays(1) });
  
         
        }

        private static void Cartest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var car = carManager.GetGetCarsByBrandId(3);
            
            foreach (var item in car.Data)
            {
                Console.WriteLine(item.Description+" "+car.Success);
            }
        }

        private static void Brandtest()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var x = brandManager.GetAll().Data;
            foreach (var item in x)
            {
                Console.WriteLine(item.BrandName);

            }
        }

        static void AddColors()
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            colorManager.Add(new Color { ColorName = "Kırmızı" });
            colorManager.Add(new Color { ColorName = "Mavi" });
            colorManager.Add(new Color { ColorName = "Yeşil" });
            colorManager.Add(new Color { ColorName = "Sarı" });
            colorManager.Add(new Color { ColorName = "Beyaz" });
            colorManager.Add(new Color { ColorName = "Siyah" });

            Console.WriteLine("Renkler eklendi.");
        }

        static void AddBrands()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            brandManager.Add(new Brand { BrandName = "Toyota" });
            brandManager.Add(new Brand { BrandName = "Ford" });
            brandManager.Add(new Brand { BrandName = "BMW" });

            Console.WriteLine("Markalar eklendi.");
        }

        static void AddCars()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            carManager.Add(new Car { BrandId = 1, ColorId = 1, ModelYear = 2020, DailyPrice = 200, Description = "Toyota Corolla" });
            carManager.Add(new Car { BrandId = 1, ColorId = 2, ModelYear = 2021, DailyPrice = 250, Description = "Toyota Camry" });
            carManager.Add(new Car { BrandId = 1, ColorId = 3, ModelYear = 2019, DailyPrice = 180, Description = "Toyota RAV4" });
            carManager.Add(new Car { BrandId = 2, ColorId = 4, ModelYear = 2020, DailyPrice = 220, Description = "Ford Focus" });
            carManager.Add(new Car { BrandId = 2, ColorId = 5, ModelYear = 2021, DailyPrice = 240, Description = "Ford Fiesta" });
            carManager.Add(new Car { BrandId = 2, ColorId = 6, ModelYear = 2019, DailyPrice = 200, Description = "Ford Mustang" });
            carManager.Add(new Car { BrandId = 3, ColorId = 1, ModelYear = 2020, DailyPrice = 300, Description = "BMW 3 Series" });
            carManager.Add(new Car { BrandId = 3, ColorId = 2, ModelYear = 2021, DailyPrice = 320, Description = "BMW 5 Series" });
            carManager.Add(new Car { BrandId = 3, ColorId = 3, ModelYear = 2022, DailyPrice = 350, Description = "BMW X5" });
            carManager.Add(new Car { BrandId = 1, ColorId = 4, ModelYear = 2021, DailyPrice = 260, Description = "Toyota Yaris" });
            carManager.Add(new Car { BrandId = 2, ColorId = 5, ModelYear = 2020, DailyPrice = 230, Description = "Ford Escape" });
            carManager.Add(new Car { BrandId = 3, ColorId = 6, ModelYear = 2021, DailyPrice = 400, Description = "BMW Z4" });

            Console.WriteLine("Arabalar eklendi.");
        }

        static void AddUsers()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            userManager.Add(new Users { FirstName = "Ahmet", LastName = "Yılmaz", Email = "ahmet.yilmaz@example.com", Password = "password1" });
            userManager.Add(new Users { FirstName = "Mehmet", LastName = "Demir", Email = "mehmet.demir@example.com", Password = "password2" });
            userManager.Add(new Users { FirstName = "Ayşe", LastName = "Kara", Email = "ayse.kara@example.com", Password = "password3" });
            userManager.Add(new Users { FirstName = "Fatma", LastName = "Çelik", Email = "fatma.celik@example.com", Password = "password4" });
            userManager.Add(new Users { FirstName = "Emre", LastName = "Koç", Email = "emre.koc@example.com", Password = "password5" });

            Console.WriteLine("Kullanıcılar eklendi.");
        }

        static void AddCustomers()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customers { UserId = 1, CompanyName = "ABC Şirketi" });
            customerManager.Add(new Customers { UserId = 2, CompanyName = "XYZ A.Ş." });
            customerManager.Add(new Customers { UserId = 3, CompanyName = "QWE Ltd." });
            customerManager.Add(new Customers { UserId = 4, CompanyName = "RTY Firması" });
            customerManager.Add(new Customers { UserId = 5, CompanyName = "UIO İnşaat" });

            Console.WriteLine("Müşteriler eklendi.");
        }
    }
}

