using System;

namespace CH.RMap.IoC.Exceptions
{
	[Serializable]
	internal class IncompleteRegistrationFoundException : Exception
	{
		private StartedRegistration _typeRegistration;

		public IncompleteRegistrationFoundException(StartedRegistration registration) : base(GetMessage(registration))
		{
			_typeRegistration = registration;
		}

		public IncompleteRegistrationFoundException(StartedRegistration registration, Exception innerException) : base(GetMessage(registration), innerException)
		{
		}

		public StartedRegistration TypeRegistration
		{
			get { return _typeRegistration; }
		}

		private static string GetMessage(StartedRegistration registration) => $"Incomplete registration found for source type '{registration.SourceType}'";
	}
}
