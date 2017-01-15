using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDInterfaces;

namespace SOLIDConcreates
{
    public class CrudLogging<TEntity> : ICrud<TEntity>
    {
        private readonly ICrud<TEntity> decoratedCrud;
        private readonly ILogger log;

        public CrudLogging(ICrud<TEntity> decoratedCrud, ILogger log)
        {
            this.decoratedCrud = decoratedCrud;
            this.log = log;
        }

        public void Create(TEntity entity)
        {
            log.LogInfo("Creating entity of type {0}", typeof(TEntity).Name);
            decoratedCrud.Create(entity);
        }

        public void Delete(TEntity entity)
        {
            log.LogInfo("Deleting entity of type {0}", typeof(TEntity).Name);
            decoratedCrud.Delete(entity);
        }

        public IEnumerable<TEntity> ReadAll()
        {
            log.LogInfo("Reading all entries of type {0}", typeof(TEntity).Name);
            return decoratedCrud.ReadAll();
        }

        public TEntity ReadOne(Guid identity)
        {
            log.LogInfo("Reading entity of type {0}", typeof(TEntity).Name);
            return decoratedCrud.ReadOne(identity);
        }

        public void Update(TEntity entity)
        {
            log.LogInfo("Updating entity of type {0}", typeof(TEntity).Name);
            decoratedCrud.Delete(entity);
        }
    }
}
