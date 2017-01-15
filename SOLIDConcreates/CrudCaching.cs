using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDInterfaces;

namespace SOLIDConcreates
{
    public class CrudCaching<TEntity> : ICru<TEntity>
    {
        private TEntity cachedEntity;
        private IEnumerable<TEntity> allCachedEntities;
        private readonly ICru<TEntity> decorated;

        public CrudCaching(ICru<TEntity> decorated)
        {
            this.decorated = decorated;
        }

        public void Create(TEntity entity)
        {
            decorated.Create(entity);
        }

        public TEntity ReadOne(Guid identity)
        {
            if (cachedEntity == null)
            {
                cachedEntity = decorated.ReadOne(identity);
            }
            return cachedEntity;
        }

        public IEnumerable<TEntity> ReadAll()
        {
            if (allCachedEntities == null)
            {
                allCachedEntities = decorated.ReadAll();
            }
            return allCachedEntities;
        }

        public void Update(TEntity entity)
        {
            decorated.Update(entity);
        }
    }
}
