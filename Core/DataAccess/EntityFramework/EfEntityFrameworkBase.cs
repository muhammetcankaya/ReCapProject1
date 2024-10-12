using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityFrameworkBase<TEntity, Tcontext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where Tcontext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            // Buradaki mevzuyu anlayalım
            // bir tane NorthwindContext nesnesi oluşturdum using içinde 
            // yapmamın sebebi performans amaçlı
            // bu nesneyi var değişkeninde entry yaptı yani bu verş tabanına gir demek
            // sonra bu değişken üzerinden ekleme işlemi yaptım sonrada değişiklikleri kaydettim
            using (Tcontext context = new Tcontext())
            {

                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (Tcontext context = new Tcontext())
            {

                var deleteEntity = context.Entry(entity);
                deleteEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (Tcontext context = new Tcontext())
            {

                var updateEntity = context.Entry(entity);
                updateEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (Tcontext context = new Tcontext())
            {
                // filtre null mı öyleyse tüm tabloyu getirs liste yap
                //  değilse filtreyi where kriterine 
                return filter == null ?
                    context.Set<TEntity>().ToList() :
                    context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (Tcontext context = new Tcontext())
            {
                // önce db setlerinde productta bağlanıyorum
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
    }
}
