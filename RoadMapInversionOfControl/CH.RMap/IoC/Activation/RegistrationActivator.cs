using System;

namespace CH.RMap.IoC.Activation
{
	internal class RegistrationActivator
	{
		public object Activate(Type type, object[] args)
		{
			var instance = Activator.CreateInstance(type, args: args, activationAttributes: new object[] { });
			return instance;
		}
	}
}
