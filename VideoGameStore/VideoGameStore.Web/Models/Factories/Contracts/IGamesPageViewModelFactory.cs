using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Data.Models;

namespace VideoGameStore.Web.Models.Factories.Contracts
{
    public interface IGamesPageViewModelFactory
    {
        GamesPageViewModel Create(IEnumerable<Game> games);
    }
}
