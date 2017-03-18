using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Utils.Factories;
using VideoGameStore.Utils.Factories.Contracts;

namespace VideoGameStore.Web.App_Start.NinjectModules
{
    public class FactoriesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IGameFactory>().To<GameFactory>().InSingletonScope();
        }
    }
}