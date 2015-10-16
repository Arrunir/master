using CH.RMap.Core.Exceptions;
using CH.RMap.Test.Utility.TestTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using static CH.RMap.Core.InputValidation;
using static CH.RMap.Test.Utility.AsyncTestHelper;

namespace CH.RMap.Test.Core
{
	[TestClass]
	public class InputValidationTest
	{
		[TestMethod]
		public async Task IsNotNullAsyncTest()
		{
			var o = new object();
			await IsNotNullAsync(o, nameof(o));
		}

		[TestMethod]
		public async Task IsNotNullAsyncNullTest()
		{
			await ThrowsExceptionAsync<ArgumentNullException>(async () =>
			{
				await IsNotNullAsync(null, string.Empty);
			});
		}

		[TestMethod]
		public async Task IsClassAsyncTest()
		{
			await IsClassAsync(typeof(TestType));
		}

		[TestMethod]
		public async Task IsClassAsyncInterfaceTest()
		{
			await ThrowsExceptionAsync<NotAClassException>(async () =>
			{
				await IsClassAsync(typeof(ITestType1));
			});
		}

		[TestMethod]
		public async Task IsClassAsyncValueTypeTest()
		{
			await ThrowsExceptionAsync<NotAClassException>(async () =>
			{
				await IsClassAsync(typeof(int));
			});
		}

		[TestMethod]
		public async Task IsInterfaceAsyncTest()
		{
			await IsInterfaceAsync(typeof(ITestType1));
		}

		[TestMethod]
		public async Task IsInterfaceAsyncClassTest()
		{
			await ThrowsExceptionAsync<NotAnInterfaceException>(async () =>
			{
				await IsInterfaceAsync(typeof(TestType));
			});
		}

		[TestMethod]
		public async Task IsInterfaceAsyncValueTypeTest()
		{
			await ThrowsExceptionAsync<NotAnInterfaceException>(async () =>
			{
				await IsInterfaceAsync(typeof(int));
			});
		}

		[TestMethod]
		public void IsNotNullTest()
		{
			var o = new object();
			IsNotNull(o, nameof(o));
		}

		[TestMethod]
		[ExpectedException(typeof(ArgumentNullException))]
		public void IsNotNullNullTest()
		{
			IsNotNull(null, string.Empty);
		}

		[TestMethod]
		public void IsClassTest()
		{
			IsClass(typeof(TestType));
		}

		[TestMethod]
		[ExpectedException(typeof(NotAClassException))]
		public void IsClassInterfaceTest()
		{
			IsClass(typeof(ITestType1));
		}

		[TestMethod]
		[ExpectedException(typeof(NotAClassException))]
		public void IsClassValueTypeTest()
		{
			IsClass(typeof(int));
		}

		[TestMethod]
		public void IsInterfaceTest()
		{
			IsInterface(typeof(ITestType1));
		}

		[TestMethod]
		[ExpectedException(typeof(NotAnInterfaceException))]
		public void IsInterfaceClassTest()
		{
			IsInterface(typeof(TestType));
		}

		[TestMethod]
		[ExpectedException(typeof(NotAnInterfaceException))]
		public void IsInterfaceValueTypeTest()
		{
			IsInterface(typeof(int));
		}
	}
}
