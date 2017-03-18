using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Data;
using VideoGameStore.Data.Contracts;
using VideoGameStore.Data.Repositories;
using VideoGameStore.Data.UnitOfWorks;

namespace VideoGameStore.Web.App_Start.NinjectModules
{
    public class DbNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IVideoGameDBContext>().To<VideoGameDBContext>().InSingletonScope();
            this.Kernel.Bind(typeof(IRepository<>)).To(typeof(GenericRepository<>));
            this.Kernel.Bind<IUnitOfWork>().To<EFUnitOfWork>().InSingletonScope();
        }
    }
}