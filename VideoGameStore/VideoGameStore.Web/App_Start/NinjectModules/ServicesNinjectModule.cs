using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VideoGameStore.Services;
using VideoGameStore.Services.Contracts;

namespace VideoGameStore.Web.App_Start.NinjectModules
{
    public class ServicesNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Kernel.Bind<IGameServices>().To<GameServices>();
        }
    }
}