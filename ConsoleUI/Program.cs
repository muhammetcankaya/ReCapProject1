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

            //RentalManager rentalManager =new RentalManager(new EfRentalDal());
            //rentalManager.Add(new Rental{CarId=1,CustomerId=4,RentDate=DateTime.Now });
            //AddBrands();
            //AddColors();
            //AddCars();
            //AddUsers();
            //AddCustomers();
            // Cartest();

        }

        private static void Cartest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var car = carManager.GetAll();
            
            foreach (var item in car.Data)
            {
                Console.WriteLine(item.ModelYear+" "+car.Success);
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
            carManager.Add(new Car { BrandId = 1, ColorId = 1, CarName = "Toyota Corolla", ModelYear = 2020, DailyPrice = 200, Description = "Kilometre: 15000, Motor Hacmi: 1.8L" });
            carManager.Add(new Car { BrandId = 1, ColorId = 2, CarName = "Toyota Camry", ModelYear = 2021, DailyPrice = 250, Description = "Kilometre: 5000, Motor Hacmi: 2.5L" });
            carManager.Add(new Car { BrandId = 1, ColorId = 3, CarName = "Toyota RAV4", ModelYear = 2019, DailyPrice = 180, Description = "Kilometre: 30000, Motor Hacmi: 2.0L" });
            carManager.Add(new Car { BrandId = 2, ColorId = 4, CarName = "Ford Focus", ModelYear = 2020, DailyPrice = 220, Description = "Kilometre: 12000, Motor Hacmi: 1.5L" });
            carManager.Add(new Car { BrandId = 2, ColorId = 5, CarName = "Ford Fiesta", ModelYear = 2021, DailyPrice = 240, Description = "Kilometre: 8000, Motor Hacmi: 1.0L" });
            carManager.Add(new Car { BrandId = 2, ColorId = 6, CarName = "Ford Mustang", ModelYear = 2019, DailyPrice = 200, Description = "Kilometre: 25000, Motor Hacmi: 5.0L" });
            carManager.Add(new Car { BrandId = 3, ColorId = 1, CarName = "BMW 3 Series", ModelYear = 2020, DailyPrice = 300, Description = "Kilometre: 10000, Motor Hacmi: 2.0L" });
            carManager.Add(new Car { BrandId = 3, ColorId = 2, CarName = "BMW 5 Series", ModelYear = 2021, DailyPrice = 320, Description = "Kilometre: 4000, Motor Hacmi: 2.0L" });
            carManager.Add(new Car { BrandId = 3, ColorId = 3, CarName = "BMW X5", ModelYear = 2022, DailyPrice = 350, Description = "Kilometre: 2000, Motor Hacmi: 3.0L" });
            carManager.Add(new Car { BrandId = 1, ColorId = 4, CarName = "Toyota Yaris", ModelYear = 2021, DailyPrice = 260, Description = "Kilometre: 3000, Motor Hacmi: 1.5L" });
            carManager.Add(new Car { BrandId = 2, ColorId = 5, CarName = "Ford Escape", ModelYear = 2020, DailyPrice = 230, Description = "Kilometre: 15000, Motor Hacmi: 2.5L" });
            carManager.Add(new Car { BrandId = 3, ColorId = 6, CarName = "BMW Z4", ModelYear = 2021, DailyPrice = 400, Description = "Kilometre: 6000, Motor Hacmi: 2.0L" });


            Console.WriteLine("Arabalar eklendi.");
        }

        static void AddUsers()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            //userManager.Add(new User { FirstName = "Ahmet", LastName = "Yılmaz", Email = "ahmet.yilmaz@example.com", Password = "password1" });
            //userManager.Add(new User { FirstName = "Mehmet", LastName = "Demir", Email = "mehmet.demir@example.com", Password = "password2" });
            //userManager.Add(new User { FirstName = "Ayşe", LastName = "Kara", Email = "ayse.kara@example.com", Password = "password3" });
            //userManager.Add(new User { FirstName = "Fatma", LastName = "Çelik", Email = "fatma.celik@example.com", Password = "password4" });
            //userManager.Add(new User { FirstName = "salih", LastName = "Koç", Email = "salih.koc@example.com", Password = "password6" });

            Console.WriteLine("Kullanıcılar eklendi.");
        }

        static void AddCustomers()
        {
            CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
            customerManager.Add(new Customer { UserId = 1, CompanyName = "ABC Şirketi" });
            customerManager.Add(new Customer { UserId = 2, CompanyName = "XYZ A.Ş." });
            customerManager.Add(new Customer { UserId = 3, CompanyName = "QWE Ltd." });
            customerManager.Add(new Customer { UserId = 4, CompanyName = "RTY Firması" });
            customerManager.Add(new Customer { UserId = 5, CompanyName = "UIO İnşaat" });

            Console.WriteLine("Müşteriler eklendi.");
        }
    }
}

