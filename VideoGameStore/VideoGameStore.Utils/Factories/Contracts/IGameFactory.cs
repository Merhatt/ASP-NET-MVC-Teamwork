using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Utils.Factories.Contracts
{
    public interface IGameFactory
    {
        Game Create(string name, decimal price, string description, string imageUrl, ICollection<Category> categories, ICollection<Platform> platforms);
    }
}
