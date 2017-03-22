using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Data.Contracts
{
    public interface IVideoGameDBContext : IDisposable
    {
        int SaveChanges();

        IDbSet<Game> Games { get; set; }

        IDbSet<Category> Categories { get; set; }

        IDbSet<Platform> Platforms { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
