using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Fictionary.ViewModels;

namespace Fictionary
{
    public static class Boostrapper
    {
        public static void Initialize()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly);
            containerBuilder.RegisterAssemblyTypes().Where(x => x.IsSubclassOf(typeof(ViewModel)));

            var container = containerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
