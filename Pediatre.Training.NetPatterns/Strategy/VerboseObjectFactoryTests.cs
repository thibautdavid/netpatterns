using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Pediatre.Training.NetPatterns.Strategy
{
    internal struct UnitTestCommon
    {
        public const string FooTypeFullName = "Pediatre.Training.NetPatterns.Strategy.ExistingFoo";
    }

    [TestClass]
    public class VerboseObjectFactoryTests
    {
        [TestMethod]
        public void Create_MustAddLog()
        {
            var sut = new VerboseObjectFactory();

            sut.Create(new CreationInfo { Name = UnitTestCommon.FooTypeFullName });
        }
    }

    [TestClass]
    public class ObjectFactoryTests
    {
        [TestMethod]
        public void Create_With_NonExistingTypeInAssembly_ShouldTryFromConfig()
        {
            var f = new ObjectFactory();
            var fooInstance = f.Create(new CreationInfo
            {
                Name = "MyNameSpace.ExistingFoo, MyNameSpace.Training.NetPatterns"
            });

            Assert.IsNull(fooInstance);
        }

        [TestMethod]
        public void Create_With_ExistingTypeInAssembly_ShouldReturnInstanceOfSpecifiedType()
        {
            var f = new ObjectFactory();
            var fooInstance = f.Create(new CreationInfo
            {
                Name = UnitTestCommon.FooTypeFullName
            });

            Assert.IsNotNull(fooInstance);
            Assert.AreEqual(UnitTestCommon.FooTypeFullName,
                fooInstance.GetType().FullName);
        }
    }
}