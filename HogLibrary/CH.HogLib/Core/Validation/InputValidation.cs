using CH.HogLib.Core.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace CH.HogLib.Core.Validation
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

		public static void IsNotNull<T>(IEnumerable<T> enumerable, [CallerMemberName]string memberName = null)
		{
			if (enumerable == null)
			{
				throw new ArgumentNullException(memberName);
			}

			if (enumerable.Any(i => i == null))
			{
				throw new ArgumentNullException($"{memberName} contains null-elements.");
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
			if (!type.IsClass && !type.IsInterface)
			{
				throw new NotAReferenceTypeException(type);
			}
		}
	}
}
