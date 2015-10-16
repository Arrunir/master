using System;
using System.Threading.Tasks;
using static CH.RMap.Core.InputValidation;

namespace CH.RMap.IoC
{
	public class TypeRegistration
	{
		public TypeRegistration(Container container, Type classType)
		{
			IsNotNull(container, nameof(container));
			IsNotNull(classType, nameof(classType));
			Container = container;
			ClassType = classType;
		}

		public Container Container { get; }
		public Type ClassType { get; }

		public async Task<TypeRegistration> AsAsync(Type interfaceType)
		{
			await IsNotNullAsync(interfaceType, nameof(interfaceType));
			await IsInterfaceAsync(interfaceType).ConfigureAwait(false);
			await Container.AddRegistration(ClassType, interfaceType).ConfigureAwait(false);
			return this;
		}

		public async Task<TypeRegistration> AsAsync(Type interfaceType, Func<TypeRegistration, Task<TypeRegistration>> continuation)
		{
			await AsAsync(interfaceType).ConfigureAwait(false);
			await continuation(this).ConfigureAwait(false);
			return this;
		}

		public async Task<TypeRegistration> AsAsync<TInterface>() where TInterface : class
		{
			await IsInterfaceAsync(typeof(TInterface)).ConfigureAwait(false);
			await Container.AddRegistration(ClassType, typeof(TInterface)).ConfigureAwait(false);
			return this;
		}

		public async Task<TypeRegistration> AsAsync<TInterface>(Func<TypeRegistration, Task<TypeRegistration>> continuation) where TInterface : class
		{
			await AsAsync<TInterface>().ConfigureAwait(false);
			await continuation(this).ConfigureAwait(false);
			return this;
		}
	}
}