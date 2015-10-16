using CH.RMap.Core.Exceptions;
using CH.RMap.IoC;
using CH.RMap.Test.Utility.TestTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CH.RMap.Test.IoC
{
	[TestClass]
	public class TypeRegistrationTest
	{
		[TestMethod]
		public void AsTest()
		{
			var container = new Container();
			var registration = new TypeRegistration(container, typeof(TestType));
			registration.As(typeof(ITestType1));

			var classType = container.GetRegistration(typeof(ITestType1));
			Assert.AreEqual(typeof(TestType), classType);
		}

		[TestMethod]
		public void AsGenericTest()
		{
			var container = new Container();
			var registration = new TypeRegistration(container, typeof(TestType));
			registration.As<ITestType1>();

			var classType = container.GetRegistration(typeof(ITestType1));
			Assert.AreEqual(typeof(TestType), classType);
		}

		[TestMethod]
		public void AsContainerNullTest()
		{
			try
			{
				new TypeRegistration(null, typeof(TestType));
				Assert.Fail();
			}
			catch (ArgumentNullException)
			{
				return;
			}

			Assert.Fail();
		}

		[TestMethod]
		public void AsClassTypeNullTest()
		{
			try
			{
				new TypeRegistration(new Container(), null);
				Assert.Fail();
			}
			catch (ArgumentNullException)
			{
				return;
			}

			Assert.Fail();
		}

		[TestMethod]
		public void AsNullTest()
		{
			var container = new Container();
			var registration = new TypeRegistration(container, typeof(TestType));

			try
			{
				registration.As(null);
				Assert.Fail();
			}
			catch (ArgumentNullException)
			{
				return;
			}

			Assert.Fail();
		}

		[TestMethod]
		public void AsValueTypeTest()
		{
			var container = new Container();
			var registration = new TypeRegistration(container, typeof(TestType));

			try
			{
				registration.As(typeof(int));
				Assert.Fail();
			}
			catch (NotAReferenceTypeException)
			{
				return;
			}

			Assert.Fail();
		}
	}
}
