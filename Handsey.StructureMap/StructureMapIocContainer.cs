using System;
using System.Linq;
using WrappedMap = StructureMap;

namespace Handsey.StructureMap
{
    public class StructureMapIocContainer : IIocContainer
    {
        private readonly WrappedMap.IContainer _container;

        public StructureMapIocContainer(WrappedMap.IContainer container)
        {
            _container = container;
        }

        public void Register(Type from, Type to, string name)
        {
            _container.Configure(x => x.For(from).Use(to).Named(name));
        }

        public TResolve[] ResolveAll<TResolve>()
        {
            return _container.GetAllInstances<TResolve>().ToArray();
        }
    }
}