using System;

namespace CH.HogLib.Core.Exceptions
{
	[Serializable]
	public class NotAReferenceTypeException : Exception
	{
		internal NotAReferenceTypeException(Type type) : base(GetMessage(type))
		{
		}
		internal NotAReferenceTypeException(Type type, Exception innerException) : base(GetMessage(type), innerException)
		{
		}

		private static string GetMessage(Type type) => $"The type '{type.FullName}' is not a reference type";
	}
}
