using CH.RMap.IoC.Exceptions;
using System;
using System.Collections.Concurrent;
using static CH.RMap.Core.InputValidation;

namespace CH.RMap.IoC
{
	public class Container
	{
		private ConcurrentDictionary<Type, Type> _registrations;

		public Container()
		{
			_registrations = new ConcurrentDictionary<Type, Type>();
		}

		public TypeRegistration RegisterType(Type type)
		{
			IsNotNull(type, nameof(type));
			IsClass(type);
			return new TypeRegistration(this, type);
		}

		public TypeRegistration RegisterType<TType>() where TType : class
		{
			IsClass(typeof(TType));
			return new TypeRegistration(this, typeof(TType));
		}

		internal void AddRegistration(Type classType, Type interfaceType)
		{
			_registrations.AddOrUpdate(interfaceType, key => classType, (key, oldValue) => classType);
		}

		internal Type GetRegistration(Type type)
		{
			Type registration;
			if (!_registrations.TryGetValue(type, out registration))
			{
				throw new NoTypeRegistrationFoundException(type);
			}
			return registration;
		}
	}
}
