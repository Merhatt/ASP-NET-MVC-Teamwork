using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Utils.Factories.Contracts;
using VideoGameStore.Utils.Pagings;
using VideoGameStore.Utils.Pagings.Contracts;

namespace VideoGameStore.Utils.Factories
{
    public class PageServiceFactory<TModel> : IPageServiceFactory<TModel>
    {
        public IPageService<TModel> Create(IEnumerable<TModel> items, int itemsCountPerPage)
        {
            if (items == null)
            {
                throw new NullReferenceException("items cannot be null");
            }

            if (itemsCountPerPage <= 0)
            {
                throw new NullReferenceException("itemsCountPerPage cannot be <= zero");
            }

            IPageService<TModel> service = new PageService<TModel>(items, itemsCountPerPage);

            return service;
        }
    }
}
