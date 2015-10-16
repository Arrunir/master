using System;

namespace CH.HogLib.Core.Exceptions
{
	[Serializable]
	public class NotAnInterfaceException : Exception
	{
		internal NotAnInterfaceException(Type type) : base(GetMessage(type))
		{
		}
		internal NotAnInterfaceException(Type type, Exception innerException) : base(GetMessage(type), innerException)
		{
		}

		private static string GetMessage(Type type) => $"The type '{type.FullName}' is not an interface";
	}
}
