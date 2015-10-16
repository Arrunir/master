using CH.HogLib.Test.Utility.TestTypes;
using CH.RMap.IoC;
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

			container.RegisterType<TestType>().As<ITestType1>();
			container.RegisterType<TestType>().As<ITestType2>();
			container.RegisterType<TestType>().As<ITestType3>();

			Assert.AreEqual(typeof(TestType), container.GetSourceType(typeof(ITestType1)));
			Assert.AreEqual(typeof(TestType), container.GetSourceType(typeof(ITestType2)));
			Assert.AreEqual(typeof(TestType), container.GetSourceType(typeof(ITestType3)));
		}
	}
}
