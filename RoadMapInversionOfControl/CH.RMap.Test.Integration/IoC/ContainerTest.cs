using CH.RMap.IoC;
using CH.RMap.Test.Utility.TestTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH.RMap.Test.Integration.IoC
{
	[TestClass]
	public class ContainerTest
	{
		[TestMethod]
		public void RegisterTypeAsInterfaceTest()
		{
			var container = new Container();

			container.RegisterType<TestType>()
				.As<ITestType1>()
				.As<ITestType2>()
				.As<ITestType3>();

			Assert.AreEqual(typeof(TestType), container.GetRegistration(typeof(ITestType1)));
			Assert.AreEqual(typeof(TestType), container.GetRegistration(typeof(ITestType2)));
			Assert.AreEqual(typeof(TestType), container.GetRegistration(typeof(ITestType3)));
		}
	}
}
