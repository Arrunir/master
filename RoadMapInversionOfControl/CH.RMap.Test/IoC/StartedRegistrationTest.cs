using CH.HogLib.Core.Exceptions;
using CH.HogLib.Test.Utility.TestTypes;
using CH.RMap.IoC;
using CH.RMap.IoC.RegistrationManagement;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CH.RMap.Test.IoC
{
	[TestClass]
	public class StartedRegistrationTest
	{
		[TestMethod]
		public void AsTest()
		{
			var manager = A.Dummy<IRegistrationFinisher>();
			var registration = new StartedRegistration(manager, typeof(TestType));
			registration.As<ITestType1>();

			A.CallTo(() => manager.FinishRegistration(typeof(ITestType1), registration)).MustHaveHappened(Repeated.Exactly.Once);
		}

		[TestMethod]
		public void AsNotReferenceTypeTest()
		{
			try
			{
				new StartedRegistration(A.Dummy<IRegistrationFinisher>(), typeof(int));
				Assert.Fail();
			}
			catch (NotAReferenceTypeException)
			{
				return;
			}

			Assert.Fail();
		}

		[TestMethod]
		public void AsContainerNullTest()
		{
			try
			{
				new StartedRegistration(null, typeof(TestType));
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
				new StartedRegistration(new RegistrationManager(), null);
				Assert.Fail();
			}
			catch (ArgumentNullException)
			{
				return;
			}

			Assert.Fail();
		}
	}
}
