using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Utils.Pagings.Contracts;

namespace VideoGameStore.Utils.Factories.Contracts
{
    public interface IPageServiceFactory<TModel>
    {
        IPageService<TModel> Create(IEnumerable<TModel> items, int itemsCountPerPage);
    }
}
