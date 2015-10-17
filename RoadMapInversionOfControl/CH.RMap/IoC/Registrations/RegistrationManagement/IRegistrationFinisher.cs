using System;

namespace CH.RMap.IoC.Registrations.RegistrationManagement
{
	public interface IRegistrationFinisher
	{
		void FinishRegistration(Type targetType, IStartedRegistration subject);
	}
}
