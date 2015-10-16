using CH.RMap.Core.Exceptions;
using CH.RMap.IoC;
using CH.RMap.IoC.Exceptions;
using CH.RMap.Test.Utility.TestTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CH.RMap.Test.IoC
{
	[TestClass]
	public class ContainerTest
	{
		[TestMethod]
		public void RegisterTypeTest()
		{
			var container = new Container();
			var registration = container.RegisterType(typeof(TestType));

			Assert.IsNotNull(registration);
			Assert.AreEqual(typeof(TestType), registration.sourceType);
		}

		[TestMethod]
		public void RegisterTypeGenericTest()
		{
			var container = new Container();
			var registration = container.RegisterType<TestType>();

			Assert.IsNotNull(registration);
			Assert.AreEqual(typeof(TestType), registration.sourceType);
		}

		[TestMethod]
		public void RegisterTypeNullTest()
		{
			var container = new Container();

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
			var container = new Container();

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
			var container = new Container();

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
			var container = new Container();

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

		[TestMethod]
		public void GetRegistrationAsyncNoTypeRegistrationFoundTest()
		{
			var container = new Container();

			try
			{
				container.GetRegistration(typeof(ITestType1));
				Assert.Fail();
			}
			catch (NoTypeRegistrationFoundException)
			{
				return;
			}

			Assert.Fail();
		}
	}
}
