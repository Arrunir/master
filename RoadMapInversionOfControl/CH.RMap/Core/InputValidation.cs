using CH.RMap.Core.Exceptions;
using System;
using System.Runtime.CompilerServices;

namespace CH.RMap.Core
{
	public static class InputValidation
	{
		public static void IsNotNull(object o, [CallerMemberName]string memberName = null)
		{
			if (o == null)
			{
				throw new ArgumentNullException(memberName);
			}
		}

		public static void IsClass(Type type)
		{
			if (!type.IsClass)
			{
				throw new NotAClassException(type);
			}
		}

		public static void IsInterface(Type type)
		{
			if (!type.IsInterface)
			{
				throw new NotAnInterfaceException(type);
			}
		}

		public static void IsReferenceType(Type type)
		{
			if(!type.IsClass && !type.IsInterface)
			{
				throw new NotAReferenceTypeException(type);
			} 
		}
	}
}
