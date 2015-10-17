using System;
using System.Collections.Generic;

namespace CH.RMap.IoC.Registrations.RegistrationManagement
{
	public interface IContainer : IRegistrationFinisher
	{
		StartedRegistration StartRegistration(Type t);
		IEnumerable<Type> GetSourceTypes(Type targetType);
	}
}
