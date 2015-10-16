using CH.RMap.IoC.RegistrationManagement;
using System;
using static CH.HogLib.Core.Validation.InputValidation;

namespace CH.RMap.IoC
{
	public class Container
	{
		private IRegistrationManager _registrationManager;

		public Container()
		{
			_registrationManager = new RegistrationManager();
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

		internal Type GetSourceType(Type targetType)
		{
			return _registrationManager.GetSourceType(targetType);
		}
	}
}
