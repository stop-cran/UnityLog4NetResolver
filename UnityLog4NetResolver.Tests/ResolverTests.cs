using log4net;
using Moq;
using NUnit.Framework;
using Shouldly;
using Unity;
using Unity.Exceptions;
using Unity.Resolution;

namespace UnityLog4NetResolver.Tests
{
    [TestFixture]
    public class ResolverTests
    {
        [Test]
        public void ShouldNotResolveILog() =>
            Should.Throw<ResolutionFailedException>(() =>
                new UnityContainer().Resolve<ClassA>());

        [Test]
        public void ShouldResolveILogByDefault() =>
            new UnityContainer()
                .AddNewExtension<LogByTypeResolverExtension>()
                .Resolve<ClassA>()
                .ShouldBeOfType<ClassA>();

        [Test]
        public void ShouldResolveILogWithTypeName() =>
            new UnityContainer()
                .AddNewExtension<LogByTypeResolverExtension>()
                .Resolve<ClassA>()
                .Log.Logger.Name
                .ShouldBe(typeof(ClassA).FullName);

        [Test]
        public void ShouldNotInterfereRegisterInstance()
        {
            var mock = Mock.Of<ILog>();

            new UnityContainer()
              .AddNewExtension<LogByTypeResolverExtension>()
              .RegisterInstance(mock)
              .Resolve<ClassA>()
              .Log
              .ShouldBeSameAs(mock);
        }

        [Test]
        public void ShouldNotInterfereDependencyOverride()
        {
            var mock = Mock.Of<ILog>();

            new UnityContainer()
              .AddNewExtension<LogByTypeResolverExtension>()
              .Resolve<ClassA>(new DependencyOverride<ILog>(mock))
              .Log
              .ShouldBeSameAs(mock);
        }

        [Test]
        public void ShouldNotInterfereParameterOverride()
        {
            var mock = Mock.Of<ILog>();

            new UnityContainer()
              .AddNewExtension<LogByTypeResolverExtension>()
              .Resolve<ClassA>(new ParameterOverride("log", mock))
              .Log
              .ShouldBeSameAs(mock);
        }

        [Test]
        public void ShouldNotResolveILogDirectly() =>
            Should.Throw<ResolutionFailedException>(() =>
                new UnityContainer()
                    .AddNewExtension<LogByTypeResolverExtension>()
                    .Resolve<ILog>());
    }
}
