using System;
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
			sourceType = classType;
		}

		public Container Container { get; }

		public Type sourceType { get; }

		public TypeRegistration As(Type targetType)
		{
			IsNotNull(targetType, nameof(targetType));
			IsReferenceType(targetType);
			Container.AddRegistration(sourceType, targetType);
			return this;
		}

		public TypeRegistration As<TTarget>() where TTarget : class
		{
			IsReferenceType(typeof(TTarget));
			Container.AddRegistration(sourceType, typeof(TTarget));
			return this;
		}
	}
}