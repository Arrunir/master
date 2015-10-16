using System;

namespace CH.RMap.IoC.RegistrationManagement
{
	internal interface IRegistrationManager : IRegistrationFinisher
	{
		StartedRegistration StartRegistration(Type t);
		Type GetSourceType(Type targetType);
	}
}
