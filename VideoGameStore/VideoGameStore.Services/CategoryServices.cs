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
    public class CategoryServices : ICategoryServices
    {
        private IRepository<Category> repository;

        public CategoryServices(IRepository<Category> repository)
        {
            if (repository == null)
            {
                throw new NullReferenceException("repository cannot be null");
            }

            this.repository = repository;
        }

        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> categories = this.repository.All();

            return categories;
        }

        public Category GetById(int id)
        {
            Category category = this.repository.GetById(id);

            return category;
        }
    }
}
