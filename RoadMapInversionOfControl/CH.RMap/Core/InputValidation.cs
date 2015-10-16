using CH.RMap.Core.Exceptions;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace CH.RMap.Core
{
	public static class InputValidation
	{
		public static async Task IsNotNullAsync(object o, [CallerMemberName]string memberName = null)
		{
			await Task.Run(() => IsNotNull(o, memberName)).ConfigureAwait(false);
		}

		public static void IsNotNull(object o, [CallerMemberName]string memberName = null)
		{
			if (o == null)
			{
				throw new ArgumentNullException(memberName);
			}
		}

		public static async Task IsClassAsync(Type type)
		{
			await Task.Run(() => IsClass(type)).ConfigureAwait(false);
		}

		public static void IsClass(Type type)
		{
			if (!type.IsClass)
			{
				throw new NotAClassException(type);
			}
		}

		public static async Task IsInterfaceAsync(Type type)
		{
			await Task.Run(() => IsInterface(type));
		}

		public static void IsInterface(Type type)
		{
			if (!type.IsInterface)
			{
				throw new NotAnInterfaceException(type);
			}
		}
	}
}
