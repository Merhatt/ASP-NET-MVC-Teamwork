using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Web.Models.Factories.Contracts
{
    public  interface IGameModelFactory
    {
        GameModel Create(int id, string name, decimal price, string description, string imageUrl, IEnumerable<string> categories, IEnumerable<string> platforms);
    }
}
