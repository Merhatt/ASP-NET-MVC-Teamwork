using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Services.Contracts
{
    public interface ICategoryServices
    {
        IEnumerable<Category> GetAll();

        Category GetById(int id);
    }
}
