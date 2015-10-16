using System;

namespace CH.HogLib.Core.Exceptions
{
	[Serializable]
	public class NotAClassException : Exception
	{
		internal NotAClassException(Type type) : base(GetMessage(type))
		{
		}
		internal NotAClassException(Type type, Exception innerException) : base(GetMessage(type), innerException)
		{
		}

		private static string GetMessage(Type type) => $"The type '{type.FullName}' is not a class";
	}
}
