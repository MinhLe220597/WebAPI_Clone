using System;
using WebAPI.Core.Infrastructute;
using WebAPI.DataContext;

namespace Library.Core
{
    public class Respository: IResponsitory
    {
        private LearningDBContext _context;

        public Respository(LearningDBContext context)
        {
            _context = context;
        }

        private void SetValueProperty<TEntity>(object obj, object objChange) where TEntity : class
        {
            foreach (var property in obj.GetType().GetProperties())
            {
                var value = objChange.GetType()?.GetProperty(property.Name)?.GetValue(objChange);
                if (value != null)
                    obj.GetType()?.GetProperty(property.Name)?.SetValue(obj, value);
            }
        }

        private TEntity GetNewObj<TEntity>() where TEntity : new()
        {
            return new TEntity();
        }

        public async Task<int> AddOrEditEntity<TEntity>(TEntity entity) where TEntity : class
        {
            //add param
            if (entity.GetType() != null)
            {
                var id = (Guid?)entity.GetType().GetProperty("ID")?.GetValue(entity);

                //add
                if (id == Guid.Empty || id == null)
                {
                    entity.GetType()?.GetProperty("ID")?.SetValue(entity, Guid.NewGuid());
                    entity.GetType()?.GetProperty("UserCreate")?.SetValue(entity, "minh.le");
                    entity.GetType()?.GetProperty("DateCreate")?.SetValue(entity, DateTime.Now);
                    entity.GetType()?.GetProperty("UserUpdate")?.SetValue(entity, "minh.le");
                    entity.GetType()?.GetProperty("DateUpdate")?.SetValue(entity, DateTime.Now);
                    _context.Set<TEntity>().Add(entity);
                }

                //Edit
                else
                {
                    var sourceInDB = _context.Set<TEntity>().Find(id.Value);
                    if (sourceInDB != null)
                    {
                        entity.GetType()?.GetProperty("UserUpdate")?.SetValue(entity, "minh.le");
                        entity.GetType()?.GetProperty("DateUpdate")?.SetValue(entity, DateTime.Now);
                        SetValueProperty<TEntity>(sourceInDB, entity);
                    }
                }
            }

            return await _context.SaveChangesAsync();
        }
    }
}

