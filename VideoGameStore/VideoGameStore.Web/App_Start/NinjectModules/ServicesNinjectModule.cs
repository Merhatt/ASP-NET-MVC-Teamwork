using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Services;
using VideoGameStore.Services.Contracts;
using VideoGameStore.Utils.Pagings;
using VideoGameStore.Utils.Pagings.Contracts;

namespace VideoGameStore.Web.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IGameServices>().To<GameServices>();
            this.Kernel.Bind<ICategoryServices>().To<CategoryServices>();
            this.Kernel.Bind<IPlatformServices>().To<PlatformServices>();
            this.Kernel.Bind<IUserServices>().To<UserServices>();
            this.Kernel.Bind<IReviewServices>().To<ReviewServices>();
            this.Kernel.Bind(typeof(IPageService<>)).To(typeof(PageService<>));
        }
    }
}