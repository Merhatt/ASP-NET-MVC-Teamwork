using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Web.Models.Factories.Contracts
{
    public interface IUserModelFactory
    {
        UserModel Create(string id, string username);
    }
}
