using CH.RMap.IoC.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using static CH.HogLib.Core.Validation.InputValidation;

namespace CH.RMap.IoC.RegistrationManagement
{
	internal class RegistrationManager : IRegistrationManager, IRegistrationFinisher
	{
		private ICollection<StartedRegistration> _startedRegistrations;
		private HashSet<FinishedRegistration> _finishedRegistrations;

		internal RegistrationManager()
		{
			_startedRegistrations = new List<StartedRegistration>();
			_finishedRegistrations = new HashSet<FinishedRegistration>();
		}

		public void FinishRegistration(Type targetType, StartedRegistration subject)
		{
			IsReferenceType(targetType);

			if (_startedRegistrations.Contains(subject))
			{
				_startedRegistrations.Remove(subject);
				_finishedRegistrations.Add(new FinishedRegistration(subject.SourceType, targetType));
				return;
			}

			throw new InvalidOperationException($"Cannot finish the registration of type '{subject.SourceType.FullName}' because it has never been started.");
		}

		public StartedRegistration StartRegistration(Type source)
		{
			var registration = new StartedRegistration(this, source);
			_startedRegistrations.Add(registration);
			return registration;
		}

		public Type GetSourceType(Type targetType)
		{
			ValidateAllRegistrationsFinished();
			if (_finishedRegistrations.Any(f => f.Target.Equals(targetType)))
			{
				return _finishedRegistrations.Single(f => f.Target == targetType).Source;
			}
			throw new NoTypeRegistrationFoundException(targetType);
		}

		private void ValidateAllRegistrationsFinished()
		{
			var unfinishedRegistration = _startedRegistrations.FirstOrDefault();
			if (unfinishedRegistration != null)
			{
				throw new IncompleteRegistrationFoundException(unfinishedRegistration);
			}
		}
	}
}
