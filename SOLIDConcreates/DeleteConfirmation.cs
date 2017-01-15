using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SOLIDInterfaces;

namespace SOLIDConcreates
{
    public class DeleteConfirmation<TEntity> : IDelete<TEntity>, IUserInteraction
    {
        private readonly IDelete<TEntity> decoratedCrud;

        public DeleteConfirmation(IDelete<TEntity> decoratedCrud)
        {
            this.decoratedCrud = decoratedCrud;
        }

        public void Delete(TEntity entity)
        {
            if (this.Confirm(message)) decoratedCrud.Delete(entity);
        }

        public bool Confirm(string message)
        {
            Console.WriteLine(message);
            var keyInfo = Console.ReadKey();
            return keyInfo.Key == ConsoleKey.Y;
        }
        private readonly string message = "are you sure you want to delete the entity? [y/n]";
    }
}
