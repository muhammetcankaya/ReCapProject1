using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : ICardal
    {
        public void Add(Car entity)
        {
            // Buradaki mevzuyu anlayalım
            // bir tane NorthwindContext nesnesi oluşturdum using içinde 
            // yapmamın sebebi performans amaçlı
            // bu nesneyi var değişkeninde entry yaptı yani bu verş tabanına gir demek
            // sonra bu değişken üzerinden ekleme işlemi yaptım sonrada değişiklikleri kaydettim
            using (ReCapProject context = new ReCapProject())
            {
        
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Car entity)
        {
            using (ReCapProject context = new ReCapProject())
            {

                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(Car entity)
        {
            using (ReCapProject context = new ReCapProject())
            {

                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProject context = new ReCapProject())
            {
                // filtre null mı öyleyse tüm tabloyu getirs liste yap
                //  değilse filtreyi where kriterine 
                return filter == null ?
                    context.Set<Car>().ToList() :
                    context.Set<Car>().Where(filter).ToList();
            }
        }

        public List<Car> GetById(int Id)
        {
            using (ReCapProject context = new ReCapProject())
            {
                // ID'ye göre veritabanında ilgili arabaları bul ve liste olarak döndür
                return context.Car
                              .Where(c => c.CarId == Id)  // CarId'ye göre filtreleme
                              .ToList();  // Liste olarak döndürme
            }
        }

        public List<Car> GetGetCarsByBrandId(int Id)
        {
            using (ReCapProject context = new ReCapProject())
            {
                // ID'ye göre veritabanında ilgili arabaları bul ve liste olarak döndür
                return context.Car
                              .Where(c => c.BrandId == Id)  // CarId'ye göre filtreleme
                              .ToList();  // Liste olarak döndürme
            }
        }
        public List<Car> GetCarsByColorId (int Id)
        {
            using (ReCapProject context = new ReCapProject())
            {
                // ID'ye göre veritabanında ilgili arabaları bul ve liste olarak döndür
                return context.Car
                              .Where(c => c.ColorId == Id)  // CarId'ye göre filtreleme
                              .ToList();  // Liste olarak döndürme
            }
        }
    }

    internal interface ICardal
    {
    }
}
