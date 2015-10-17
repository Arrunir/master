using CH.RMap.IoC.Registrations.RegistrationManagement;
using System;
using static CH.HogLib.Core.Validation.InputValidation;

namespace CH.RMap.IoC.Registrations
{
	public class StartedRegistration : IStartedRegistration
	{
		private IRegistrationFinisher _registrationManager;

		internal StartedRegistration(IRegistrationFinisher registrationManager, Type classType)
		{
			IsNotNull(registrationManager, nameof(registrationManager));
			IsNotNull(classType, nameof(classType));
			IsReferenceType(classType);
			_registrationManager = registrationManager;
			SourceType = classType;
		}

		public Type SourceType { get; }

		public void As<TTarget>() where TTarget : class
		{
			IsReferenceType(typeof(TTarget));
			_registrationManager.FinishRegistration(typeof(TTarget), this);
		}
	}
}