using CH.RMap.IoC.Registrations;
using System;

namespace CH.RMap.IoC.Exceptions
{
	[Serializable]
	internal class IncompleteRegistrationFoundException : Exception
	{
		private IStartedRegistration _typeRegistration;

		public IncompleteRegistrationFoundException(IStartedRegistration registration) : base(GetMessage(registration))
		{
			_typeRegistration = registration;
		}

		public IncompleteRegistrationFoundException(IStartedRegistration registration, Exception innerException) : base(GetMessage(registration), innerException)
		{
		}

		public IStartedRegistration TypeRegistration
		{
			get { return _typeRegistration; }
		}

		private static string GetMessage(IStartedRegistration registration) => $"Incomplete registration found for source type '{registration.SourceType}'";
	}
}
