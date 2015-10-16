using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using static CH.RMap.Test.Utility.AsyncTestHelper;
using CH.RMap.IoC;
using CH.RMap.Core.Exceptions;
using CH.RMap.IoC.Exceptions;
using CH.RMap.Test.Utility.TestTypes;

namespace CH.RMap.Test.IoC
{
	[TestClass]
	public class ContainerTest
	{
		[TestMethod]
		public async Task RegisterTypeTest()
		{
			var container = new Container();
			var registration = await container.RegisterTypeAsync(typeof(TestType));

			Assert.IsNotNull(registration);
			Assert.AreEqual(typeof(TestType), registration.ClassType);
		}

		[TestMethod]
		public async Task RegisterTypeGenericTest()
		{
			var container = new Container();
			var registration = await container.RegisterTypeAsync<TestType>();

			Assert.IsNotNull(registration);
			Assert.AreEqual(typeof(TestType), registration.ClassType);
		}

		[TestMethod]
		public async Task RegisterTypeNullTest()
		{
			var container = new Container();

			await ThrowsExceptionAsync<ArgumentNullException>(async () =>
			{
				var registration = await container.RegisterTypeAsync(null);
			});
		}

		[TestMethod]
		public async Task RegisterTypeInterfaceTest()
		{
			var container = new Container();

			await ThrowsExceptionAsync<NotAClassException>(async () =>
			{
				var registration = await container.RegisterTypeAsync(typeof(ITestType1));
			});
		}

		[TestMethod]
		public async Task RegisterTypeInterfaceGenericTest()
		{
			var container = new Container();

			await ThrowsExceptionAsync<NotAClassException>(async () =>
			{
				var registration = await container.RegisterTypeAsync<ITestType1>();
			});
		}

		[TestMethod]
		public async Task RegisterTypeValueTypeTest()
		{
			var container = new Container();

			await ThrowsExceptionAsync<NotAClassException>(async () =>
			{
				var registration = await container.RegisterTypeAsync(typeof(int));
			});
		}

		[TestMethod]
		public async Task GetRegistrationAsyncNoTypeRegistrationFoundTest()
		{
			var container = new Container();

			await ThrowsExceptionAsync<NoTypeRegistrationFoundException>(async () =>
			{
				var registration = await container.GetRegistrationAsync(typeof(ITestType1));
			});
		}
	}
}
