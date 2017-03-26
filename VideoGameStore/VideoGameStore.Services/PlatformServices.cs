using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Contracts;
using VideoGameStore.Data.Models;
using VideoGameStore.Services.Contracts;

namespace VideoGameStore.Services
{
    public class PlatformServices : IPlatformServices
    {
        private IRepository<Platform> repository;

        public PlatformServices(IRepository<Platform> repository)
        {
            if (repository == null)
            {
                throw new NullReferenceException("repository cannot be null");
            }

            this.repository = repository;
        }

        public IEnumerable<Platform> GetAll()
        {
            IEnumerable<Platform> allPlatforms = this.repository.All().ToList();

            return allPlatforms;
        }

        public Platform GetById(int id)
        {
            if (id < 0)
            {
                throw new NullReferenceException("id cannot be less than 0");
            }

            Platform platform = this.repository.GetById(id);

            return platform;
        }
    }
}
