//using CH.RMap.Core.Exceptions;
//using CH.RMap.IoC;
//using CH.RMap.Test.Utility.TestTypes;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System;
//using System.Threading.Tasks;
//using static CH.RMap.Test.Utility.AsyncTestHelper;

//namespace CH.RMap.Test.IoC
//{
//	[TestClass]
//	public class TypeRegistrationTest
//	{
//		[TestMethod]
//		public async Task AsTest()
//		{
//			var container = new Container();
//			var registration = new TypeRegistration(container, typeof(TestType));
//			await registration.AsAsync(typeof(ITestType1));

//			var classType = await container.GetRegistrationAsync(typeof(ITestType1));
//			Assert.AreEqual(typeof(TestType), classType);
//		}

//		[TestMethod]
//		public async Task AsGenericTest()
//		{
//			var container = new Container();
//			var registration = new TypeRegistration(container, typeof(TestType));
//			await registration.AsAsync<ITestType1>();

//			var classType = await container.GetRegistrationAsync(typeof(ITestType1));
//			Assert.AreEqual(typeof(TestType), classType);
//		}

//		[TestMethod]
//		public async Task AsContainerNullTest()
//		{
//			await ThrowsExceptionAsync<ArgumentNullException>(async () =>
//			{
//				await Task.Run(() => new TypeRegistration(null, typeof(TestType)));
//			});
//		}

//		[TestMethod]
//		public async Task AsClassTypeNullTest()
//		{
//			await ThrowsExceptionAsync<ArgumentNullException>(async () =>
//			{
//				await Task.Run(() => new TypeRegistration(new Container(), null));
//			});
//		}

//		[TestMethod]
//		public async Task AsNullTest()
//		{
//			var container = new Container();
//			var registration = new TypeRegistration(container, typeof(TestType));

//			await ThrowsExceptionAsync<ArgumentNullException>(async () =>
//			{
//				await registration.AsAsync(null);
//			});
//		}

//		[TestMethod]
//		public async Task AsClassTest()
//		{
//			var container = new Container();
//			var registration = new TypeRegistration(container, typeof(TestType));

//			await ThrowsExceptionAsync<NotAnInterfaceException>(async () =>
//			{
//				await registration.AsAsync(typeof(TestType));
//			});
//		}

//		[TestMethod]
//		public async Task AsClassGenericTest()
//		{
//			var container = new Container();
//			var registration = new TypeRegistration(container, typeof(TestType));

//			await ThrowsExceptionAsync<NotAnInterfaceException>(async () =>
//			{
//				await registration.AsAsync<TestType>();
//			});
//		}

//		[TestMethod]
//		public async Task AsValueTypeTest()
//		{
//			var container = new Container();
//			var registration = new TypeRegistration(container, typeof(TestType));

//			await ThrowsExceptionAsync<NotAnInterfaceException>(async () =>
//			{
//				await registration.AsAsync(typeof(int));
//			});
//		}
//	}
//}
