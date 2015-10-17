using CH.RMap.IoC.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using static CH.HogLib.Core.Validation.InputValidation;

namespace CH.RMap.IoC.Registrations.RegistrationManagement
{
	internal class Container : IContainer, IRegistrationFinisher
	{
		private ICollection<IStartedRegistration> _startedRegistrations;
		private HashSet<FinishedRegistration> _finishedRegistrations;

		internal Container()
		{
			_startedRegistrations = new List<IStartedRegistration>();
			_finishedRegistrations = new HashSet<FinishedRegistration>();
		}

		public void FinishRegistration(Type targetType, IStartedRegistration subject)
		{
			IsReferenceType(targetType);
			ValidateIsTargetAssignableFromSource(targetType, subject.SourceType);

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

		public IEnumerable<Type> GetSourceTypes(Type targetType)
		{
			ValidateAllRegistrationsFinished();
			if (_finishedRegistrations.Any(f => f.Target.Equals(targetType)))
			{
				return _finishedRegistrations.Where(f => f.Target == targetType).Select(f => f.Source);
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

		private void ValidateIsTargetAssignableFromSource(Type target, Type source)
		{
			if (!target.IsAssignableFrom(source))
			{
				throw new InvalidOperationException($"Source type '{source.FullName}' is not assignable to '{target.FullName}'");
			}
		}
	}
}
