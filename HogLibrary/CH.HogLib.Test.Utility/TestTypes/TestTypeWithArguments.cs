namespace CH.HogLib.Test.Utility.TestTypes
{
	public class TestTypeWithArguments
	{
		public TestTypeWithArguments(ITestType2 type2, ITestType3 type3)
		{
			Type2 = type2;
			Type3 = type3;
		}

		public TestTypeWithArguments(ITestType2 type2, ITestType3 type3, ITestType4 type4)
		{
			Type2 = type2;
			Type3 = type3;
			Type4 = type4;
		}

		public TestTypeWithArguments(ITestType2 type2, ITestType3 type3, ITestType4 type4, int value)
		{
			Type2 = type2;
			Type3 = type3;
			Type4 = type4;
		}

		public ITestType2 Type2 { get; }
		public ITestType3 Type3 { get; }
		public ITestType4 Type4 { get; }
	}
}
