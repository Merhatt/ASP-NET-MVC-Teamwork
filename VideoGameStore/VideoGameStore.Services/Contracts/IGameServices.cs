using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Services.Contracts
{
    public interface IGameServices
    {
        void Create(string name, decimal price, string description, string imageUrl, ICollection<Category> categories);

        IEnumerable<Game> GetAll();

        IEnumerable<Game> GetAll(IEnumerable<Category> categories);

        IEnumerable<Game> GetAll(string name);
    }
}
