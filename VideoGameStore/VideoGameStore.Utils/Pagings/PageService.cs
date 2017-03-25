using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGameStore.Utils.Pagings.Contracts;

namespace VideoGameStore.Utils.Pagings
{
    public class PageService<TModel> : IPageService<TModel>
    {
        private IEnumerable<TModel> items;
        private int itemsCountPerPage;

        public PageService(IEnumerable<TModel> items, int itemsCountPerPage)
        {
            if (items == null)
            {
                throw new NullReferenceException("items cannot be null");
            }

            if (itemsCountPerPage <= 0)
            {
                throw new NullReferenceException("itemsCountPerPage cannot be <= zero");
            }

            this.items = items;
            this.itemsCountPerPage = itemsCountPerPage;
        }

        public int GetMaxPage()
        {
            int maxPage = this.items.Count() / this.itemsCountPerPage + 1;

            return maxPage;
        }

        public IEnumerable<TModel> GetPage(int page)
        {
            if (page <= 0)
            {
                throw new NullReferenceException("page cannot be <= zero");
            }

            int skipCount = (page - 1) * this.itemsCountPerPage;

            IEnumerable<TModel> itemsInPage = this.items.Skip(skipCount)
                .Take(this.itemsCountPerPage);

            return itemsInPage;
        }
    }
}
