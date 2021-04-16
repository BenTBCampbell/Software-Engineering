using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Fictionary.ViewModels;
//using Fictionary.Repositories;
using Xamarin.Forms;

namespace Fictionary
{
    public static class Boostrapper
    {
        public static void Initialize()
        {
            var containerBuilder = new ContainerBuilder();
            //containerBuilder.RegisterType<AccountRepository>();
            //containerBuilder.RegisterType<WordRepository>();
            containerBuilder.RegisterAssemblyTypes(typeof(App).Assembly)
                .Where(x => x.IsSubclassOf(typeof(ViewModel)) || x.IsSubclassOf(typeof(Page)));

            var container = containerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
