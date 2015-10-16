using CH.RMap.Core.Exceptions;
using CH.RMap.Test.Utility.TestTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using static CH.RMap.Core.InputValidation;

namespace CH.RMap.Test.Core
{
	[TestClass]
	public class InputValidationTest
	{
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
