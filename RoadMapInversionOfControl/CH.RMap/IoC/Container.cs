using CH.RMap.IoC.Exceptions;
using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;
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

		public async Task<TypeRegistration> RegisterTypeAsync(Type type)
		{
			await IsNotNullAsync(type, nameof(type)).ConfigureAwait(false);
			await IsClassAsync(type).ConfigureAwait(false);
			return await Task.Run(() => new TypeRegistration(this, type)).ConfigureAwait(false);
		}

		public async Task RegisterTypeAsync(Type type, Func<TypeRegistration, Task<TypeRegistration>> continuation)
		{
			var registration = await RegisterTypeAsync(type).ConfigureAwait(false);
			await continuation(registration).ConfigureAwait(false);
		}

		public async Task<TypeRegistration> RegisterTypeAsync<TType>() where TType : class
		{
			await IsClassAsync(typeof(TType)).ConfigureAwait(false);
			return await Task.Run(() => new TypeRegistration(this, typeof(TType))).ConfigureAwait(false);
		}

		public async Task RegisterTypeAsync<TType>(Func<TypeRegistration, Task<TypeRegistration>> continuation) where TType : class
		{
			var registration = await RegisterTypeAsync<TType>().ConfigureAwait(false);
			await continuation(registration).ConfigureAwait(false);
		}

		internal async Task AddRegistration(Type classType, Type interfaceType)
		{
			await Task.Run(() => 
			{
				_registrations.AddOrUpdate(interfaceType, key => classType, (key, oldValue) => classType);
			}).ConfigureAwait(false);
		}

		internal async Task<Type> GetRegistrationAsync(Type type)
		{
			return await Task.Run(() =>
			{
				Type registration;
				if(!_registrations.TryGetValue(type, out registration))
				{
					throw new NoTypeRegistrationFoundException(type);
				}
				return registration;
			}).ConfigureAwait(false);
		}
	}
}
