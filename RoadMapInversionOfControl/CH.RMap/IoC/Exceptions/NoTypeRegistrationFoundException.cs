using System;

namespace CH.RMap.IoC.Exceptions
{
	[Serializable]
	internal class NoTypeRegistrationFoundException : Exception
	{
		public NoTypeRegistrationFoundException(Type type) : base(GetMessage(type))
		{
		}

		public NoTypeRegistrationFoundException(Type type, Exception innerException) : base (GetMessage(type), innerException)
		{
		}

		private static string GetMessage(Type type) => $"No registration for the type '{type.FullName}' found";
	}
}
