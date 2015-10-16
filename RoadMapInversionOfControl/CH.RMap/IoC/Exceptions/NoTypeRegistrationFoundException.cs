using System;

namespace CH.RMap.IoC.Exceptions
{
	[Serializable]
	internal class NoTypeRegistrationFoundException : Exception
	{
		public NoTypeRegistrationFoundException(Type targetType) : base(GetMessage(targetType))
		{
		}

		public NoTypeRegistrationFoundException(Type targetType, Exception innerException) : base(GetMessage(targetType), innerException)
		{
		}

		private static string GetMessage(Type targetType) => $"No registration for the type '{targetType.FullName}' found";
	}
}
