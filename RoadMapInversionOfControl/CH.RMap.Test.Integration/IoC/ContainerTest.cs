using CH.RMap.IoC;
using CH.RMap.Test.Utility.TestTypes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace CH.RMap.Test.Integration.IoC
{
	[TestClass]
	public class ContainerTest
	{
		[TestMethod]
		public async Task RegisterTypeAsInterfaceTest()
		{
			var container = new Container();

			await container.RegisterTypeAsync<TestType>(
				f => f.AsAsync<ITestType1>(
					s => s.AsAsync<ITestType2>(
						t => t.AsAsync<ITestType3>())));
			
			Assert.AreEqual(typeof(TestType), await container.GetRegistrationAsync(typeof(ITestType1)));
			Assert.AreEqual(typeof(TestType), await container.GetRegistrationAsync(typeof(ITestType2)));
			Assert.AreEqual(typeof(TestType), await container.GetRegistrationAsync(typeof(ITestType3)));
		}
	}
}
