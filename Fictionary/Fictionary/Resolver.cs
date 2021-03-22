using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fictionary
{
    public static class Resolver
    {
        public static IContainer container;

        public static void Initialize(IContainer container)
        {
            Resolver.container = container;
        }

        public static T Resolve<T>()
        {
           return container.Resolve<T>();
        }
    }
}
