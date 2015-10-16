using System;

namespace CH.RMap.IoC.RegistrationManagement
{
	public interface IRegistrationFinisher
	{
		void FinishRegistration(Type targetType, StartedRegistration subject);
	}
}
