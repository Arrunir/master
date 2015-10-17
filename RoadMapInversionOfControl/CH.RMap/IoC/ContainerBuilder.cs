using CH.RMap.IoC.Registrations;
using CH.RMap.IoC.Registrations.RegistrationManagement;
using System;
using static CH.HogLib.Core.Validation.InputValidation;

namespace CH.RMap.IoC
{
	public sealed class ContainerBuilder
	{
		private IContainer _registrationManager;

		public ContainerBuilder()
		{
			_registrationManager = new Container();
		}

		public StartedRegistration RegisterType(Type sourceType)
		{
			IsNotNull(sourceType, nameof(sourceType));
			IsClass(sourceType);
			return _registrationManager.StartRegistration(sourceType);
		}

		public StartedRegistration RegisterType<TType>() where TType : class
		{
			var sourceType = typeof(TType);
			IsClass(sourceType);
			return _registrationManager.StartRegistration(sourceType);
		}
	}
}
