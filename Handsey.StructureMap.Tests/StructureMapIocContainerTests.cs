using NUnit.Framework;
using System;
using System.Linq;
using WrappedMap = StructureMap;

namespace Handsey.StructureMap.Tests
{
    [TestFixture]
    public class StructureMapIocContainerTests
    {
        private IIocContainer _structureMapIocContainer;
        private WrappedMap.IContainer _container;

        [SetUp]
        public void Setup()
        {
            _container = new WrappedMap.Container();
            _structureMapIocContainer = new StructureMapIocContainer(_container);
        }

        [Test]
        public void Register_TypeAndTypeAndString_TypeRegsiteredOnNinjectContainerWithName()
        {
            // Mocking StandardKernel throws an exception so need to do an intergration test here
            _structureMapIocContainer.Register(typeof(IIocContainer), typeof(MockObject), "test");

            Assert.That(_container.GetInstance<IIocContainer>("test"), Is.Not.Null, "Type not registered");
        }

        [Test]
        public void ResolveAll_NoParams_ResolveAllCalledOnNinjectContainer()
        {
            // Mocking StandardKernel throws an exception so need to do an intergration test here
            _structureMapIocContainer.Register(typeof(IIocContainer), typeof(MockObject), "test1");
            _structureMapIocContainer.Register(typeof(IIocContainer), typeof(MockObject2), "test2");

            Assert.That(_structureMapIocContainer.ResolveAll<IIocContainer>().Count(), Is.EqualTo(2), "Type not registered");
        }

        private class MockObject : IIocContainer
        {
            public void Register(Type from, Type to)
            {
                throw new NotImplementedException();
            }

            public void Register(Type from, Type to, string name)
            {
                throw new NotImplementedException();
            }

            public TResolve[] ResolveAll<TResolve>()
            {
                throw new NotImplementedException();
            }
        }

        private class MockObject2 : IIocContainer
        {
            public void Register(Type from, Type to)
            {
                throw new NotImplementedException();
            }

            public void Register(Type from, Type to, string name)
            {
                throw new NotImplementedException();
            }

            public TResolve[] ResolveAll<TResolve>()
            {
                throw new NotImplementedException();
            }
        }
    }
}