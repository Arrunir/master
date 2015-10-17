using System;

namespace CH.RMap.IoC.Registrations
{
	public interface IStartedRegistration
	{
		Type SourceType { get; }
		void As<TTarget>() where TTarget : class;
	}
}
