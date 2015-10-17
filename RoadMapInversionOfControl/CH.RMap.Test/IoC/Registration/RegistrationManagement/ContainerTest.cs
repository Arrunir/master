using CH.HogLib.Core.Exceptions;
using CH.HogLib.Test.Utility.TestTypes;
using CH.RMap.IoC.Registrations;
using CH.RMap.IoC.Registrations.RegistrationManagement;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CH.RMap.Test.IoC.Registration.RegistrationManagement
{
	[TestClass]
	public class ContainerTest
	{
		[TestMethod]
		public void StartRegistrationTest()
		{
			var container = new Container();
			var registration = container.StartRegistration(typeof(TestType));

			Assert.AreEqual(typeof(TestType), registration.SourceType);
		}

		[TestMethod]
		public void FinishRegistrationTest()
		{
			var container = new Container();
			var registration = container.StartRegistration(typeof(TestType));

			container.FinishRegistration(typeof(ITestType1), registration);

			Assert.AreEqual(typeof(TestType), container.GetSourceType(typeof(ITestType1)));
		}

		[TestMethod]
		public void FinishRegistrationNotAReferenceTypeTest()
		{
			var container = new Container();
			var registration = container.StartRegistration(typeof(TestType));

			try
			{
				container.FinishRegistration(typeof(int), registration);
				Assert.Fail();
			}
			catch (NotAReferenceTypeException)
			{
				return;
			}

			Assert.Fail();
		}

		[TestMethod]
		public void FinishRegistrationTargetNotAssignableFromSourceTest()
		{
			var container = new Container();
			var registration = container.StartRegistration(typeof(TestType));

			try
			{
				container.FinishRegistration(typeof(ITestType4), registration);
				Assert.Fail();
			}
			catch (InvalidOperationException ex)
			{
				StringAssert.Contains(ex.Message, "is not assignable to");
				return;
			}

			Assert.Fail();
		}

		[TestMethod]
		public void FinishRegistrationNotStartedTest()
		{
			var container = new Container();
			var registration = A.Dummy<IStartedRegistration>();
			A.CallTo(() => registration.SourceType).Returns(typeof(TestType));

			try
			{
				container.FinishRegistration(typeof(ITestType1), registration);
				Assert.Fail();
			}
			catch (InvalidOperationException ex)
			{
				StringAssert.Contains(ex.Message, "because it has never been started");
				return;
			}

			Assert.Fail();
		}
	}
}
