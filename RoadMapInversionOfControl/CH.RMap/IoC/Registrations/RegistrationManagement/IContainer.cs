using System;

namespace CH.RMap.IoC.Registrations.RegistrationManagement
{
	internal interface IContainer : IRegistrationFinisher
	{
		StartedRegistration StartRegistration(Type t);
		Type GetSourceType(Type targetType);
	}
}
