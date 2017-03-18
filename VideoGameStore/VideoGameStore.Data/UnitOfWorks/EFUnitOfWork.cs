using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Contracts;

namespace VideoGameStore.Data.UnitOfWorks
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private IVideoGameDBContext context;

        public EFUnitOfWork(IVideoGameDBContext context)
        {
            if (context == null)
            {
                throw new NullReferenceException("context cannot be null");
            }

            this.context = context;
        }

        public void Commit()
        {
            this.context.SaveChanges();
        }
    }
}
