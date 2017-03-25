using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoGameStore.Utils.Pagings.Contracts
{
    public interface IPageService<TModel>
    {
        IEnumerable<TModel> GetPage(int page);

        int GetMaxPage();
    }
}
