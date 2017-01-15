using System;
using System.Collections.Generic;
using SOLIDInterfaces;

namespace SOLIDConcreates
{
    public class CrudTransactional<TEntity> : ICrud<TEntity>
    {
        private readonly ICrud<TEntity> decoratedCrud;

        public CrudTransactional(ICrud<TEntity> decoratedCrud)
        {
            this.decoratedCrud = decoratedCrud;
        }

        public void Create(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Create(entity);
                transaction.Complete();
            }
        }

        public TEntity ReadOne(Guid identity)
        {
            TEntity entity;
            using (var transaction = new TransactionScope())
            {
                entity = decoratedCrud.ReadOne(identity);
                transaction.Complete();
            }
            return entity;
        }

        public IEnumerable<TEntity> ReadAll()
        {
            IEnumerable<TEntity> allEntities;
            using (var transaction = new TransactionScope())
            {
                allEntities = decoratedCrud.ReadAll();
                transaction.Complete();
            }
            return allEntities;
        }

        public void Update(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Update(entity);
                transaction.Complete();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var transaction = new TransactionScope())
            {
                decoratedCrud.Delete(entity);
                transaction.Complete();
            }
        }
    }
}