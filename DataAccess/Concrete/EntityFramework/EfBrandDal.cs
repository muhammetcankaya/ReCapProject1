using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : IBrandDal
    {
        public void Add(Brand entity)
        {
            using (ReCapProject context = new ReCapProject())
            {

                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Brand entity)
        {
            using (ReCapProject context = new ReCapProject())
            {

                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Brand> GetAll(Expression<Func<Brand, bool>> filter = null)
        {
            using (ReCapProject context = new ReCapProject())
            {
                // filtre null mı öyleyse tüm tabloyu getirs liste yap
                //  değilse filtreyi where kriterine 
                return filter == null ?
                    context.Set<Brand>().ToList() :
                    context.Set<Brand>().Where(filter).ToList();
            }
        }

        public List<Brand> GetById(int Id)
        {
            using (ReCapProject context = new ReCapProject())
            {
                // ID'ye göre veritabanında ilgili arabaları bul ve liste olarak döndür
                return context.Brand
                              .Where(c => c.BrandId == Id)  // CarId'ye göre filtreleme
                              .ToList();  // Liste olarak döndürme
            }
        }

        public void Update(Brand entity)
        {
            using (ReCapProject context = new ReCapProject())
            {

                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
