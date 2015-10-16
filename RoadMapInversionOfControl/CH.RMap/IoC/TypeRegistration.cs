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

		public TypeRegistration As(Type interfaceType)
		{
			IsNotNull(interfaceType, nameof(interfaceType));
			IsInterface(interfaceType);
			Container.AddRegistration(ClassType, interfaceType);
			return this;
		}

		public TypeRegistration As(Type interfaceType, Func<TypeRegistration, Task<TypeRegistration>> continuation)
		{
			As(interfaceType);
			continuation(this);
			return this;
		}

		public TypeRegistration As<TInterface>() where TInterface : class
		{
			IsInterface(typeof(TInterface));
			Container.AddRegistration(ClassType, typeof(TInterface));
			return this;
		}

		public TypeRegistration As<TInterface>(Func<TypeRegistration, Task<TypeRegistration>> continuation) where TInterface : class
		{
			As<TInterface>();
			continuation(this);
			return this;
		}
	}
}