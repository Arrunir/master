using CH.HogLib.Test.Utility.TestTypes;
using CH.RMap.IoC.Activation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH.RMap.Test.IoC.Activation
{
	[TestClass]
	public class RegistrationActivatorTest
	{
		[TestMethod]
		public void ActivateTest()
		{
			var activator = new RegistrationActivator();
			var testTypeInstance = activator.Activate(typeof(TestType), null);
			Assert.IsNotNull(testTypeInstance);
			Assert.AreEqual(typeof(TestType), testTypeInstance.GetType());
		}
	}
}
