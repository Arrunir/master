using CH.HogLib.Test.Utility.TestTypes;
using CH.RMap.IoC.Activation;
using CH.RMap.IoC.Exceptions;
using CH.RMap.IoC.Registrations.RegistrationManagement;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace CH.RMap.Test.IoC.Activation
{
	[TestClass]
	public class ResolverTest
	{
		[TestMethod]
		public void ResolveTest()
		{
			var container = A.Dummy<IContainer>();
			A.CallTo(() => container.GetSourceTypes(typeof(ITestType1))).Returns(new[] { typeof(TestType) });

			var resolver = new Resolver(container);

			var result = resolver.ResolveSingle<ITestType1>();

			Assert.IsNotNull(result);
			Assert.IsTrue(result is ITestType1);
			Assert.IsTrue(result is TestType);
		}

		[TestMethod]
		public void ResolveWithArgumentTest()
		{
			var container = A.Dummy<IContainer>();
			A.CallTo(() => container.GetSourceTypes(typeof(ITestType1))).Returns(new[] { typeof(TestTypeWithArgument) });
			A.CallTo(() => container.GetSourceTypes(typeof(ITestType2))).Returns(new[] { typeof(TestType) });

			var resolver = new Resolver(container);

			var result = resolver.ResolveSingle<ITestType1>();

			Assert.IsNotNull(result);
			Assert.IsTrue(result is ITestType1);
			Assert.IsTrue(result is TestTypeWithArgument);
			Assert.IsNotNull(((TestTypeWithArgument)result).Type2);
			Assert.IsTrue(((TestTypeWithArgument)result).Type2 is ITestType2);
			Assert.IsTrue(((TestTypeWithArgument)result).Type2 is TestType);
		}

		[TestMethod]
		public void ResolveWithArgumentNotResolvableTest()
		{
			var container = A.Dummy<IContainer>();
			A.CallTo(() => container.GetSourceTypes(typeof(ITestType1))).Returns(new[] { typeof(TestTypeWithArguments) });
			A.CallTo(() => container.GetSourceTypes(typeof(ITestType2))).Returns(new[] { typeof(TestType) });
			A.CallTo(() => container.GetSourceTypes(typeof(ITestType4))).Returns(new[] { typeof(TestType4) });

			var resolver = new Resolver(container);

			try
			{
				resolver.ResolveSingle<ITestType1>();
				Assert.Fail();
			}
			catch (ResolverException ex)
			{
				Debug.Write(ex.Message);
				return;
			}

			Assert.Fail();
		}
	}
}
