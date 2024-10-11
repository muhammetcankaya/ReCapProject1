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
    public class EfColorDal : IColorDal
    {
        public void Add(Color entity)
        {
            using (ReCapProject context = new ReCapProject())
            {

                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Color entity)
        {
            using (ReCapProject context = new ReCapProject())
            {

                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Color> GetAll(Expression<Func<Color, bool>> filter = null)
        {
            using (ReCapProject context = new ReCapProject())
            {
                // filtre null mı öyleyse tüm tabloyu getirs liste yap
                //  değilse filtreyi where kriterine 
                return filter == null ?
                    context.Set<Color>().ToList() :
                    context.Set<Color>().Where(filter).ToList();
            }
        }

        public List<Color> GetById(int Id)
        {
            using (ReCapProject context = new ReCapProject())
            {
                // ID'ye göre veritabanında ilgili arabaları bul ve liste olarak döndür
                return context.Color
                              .Where(c => c.ColorId == Id)  // CarId'ye göre filtreleme
                              .ToList();  // Liste olarak döndürme
            }
        }

        public void Update(Color entity)
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
