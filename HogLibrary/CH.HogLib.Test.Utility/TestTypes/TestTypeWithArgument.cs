namespace CH.HogLib.Test.Utility.TestTypes
{
	public class TestTypeWithArgument : ITestType1
	{
		public TestTypeWithArgument(ITestType2 type2)
		{
			Type2 = type2;
		}

		public ITestType2 Type2 { get; }
	}
}
