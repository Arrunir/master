using CH.HogLib.Core.Exceptions;
using CH.HogLib.Test.Utility.TestTypes;
using CH.RMap.IoC;
using CH.RMap.IoC.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CH.RMap.Test.IoC
{
	[TestClass]
	public class ContainerBuilderTest
	{
		[TestMethod]
		public void RegisterTypeTest()
		{
			var container = new ContainerBuilder();
			var registration = container.RegisterType(typeof(TestType));

			Assert.IsNotNull(registration);
			Assert.AreEqual(typeof(TestType), registration.SourceType);
		}

		[TestMethod]
		public void RegisterTypeGenericTest()
		{
			var container = new ContainerBuilder();
			var registration = container.RegisterType<TestType>();

			Assert.IsNotNull(registration);
			Assert.AreEqual(typeof(TestType), registration.SourceType);
		}

		[TestMethod]
		public void RegisterTypeNullTest()
		{
			var container = new ContainerBuilder();

			try
			{
				container.RegisterType(null);
				Assert.Fail();
			}
			catch (ArgumentNullException)
			{
				return;
			}

			Assert.Fail();
		}

		[TestMethod]
		public void RegisterTypeInterfaceTest()
		{
			var container = new ContainerBuilder();

			try
			{
				container.RegisterType(typeof(ITestType1));
				Assert.Fail();
			}
			catch (NotAClassException)
			{
				return;
			}

			Assert.Fail();
		}

		[TestMethod]
		public void RegisterTypeInterfaceGenericTest()
		{
			var container = new ContainerBuilder();

			try
			{
				container.RegisterType<ITestType1>();
				Assert.Fail();
			}
			catch (NotAClassException)
			{
				return;
			}

			Assert.Fail();
		}

		[TestMethod]
		public void RegisterTypeValueTypeTest()
		{
			var container = new ContainerBuilder();

			try
			{
				container.RegisterType(typeof(int));
				Assert.Fail();
			}
			catch (NotAClassException)
			{
				return;
			}

			Assert.Fail();
		}
	}
}
