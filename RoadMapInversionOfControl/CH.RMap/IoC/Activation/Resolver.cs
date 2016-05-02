using CH.RMap.IoC.Exceptions;
using CH.RMap.IoC.Registrations.RegistrationManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using static CH.HogLib.Core.Validation.InputValidation;

namespace CH.RMap.IoC.Activation
{
	internal class Resolver
	{
		private RegistrationActivator _activator;
		private IContainer _container;

		public Resolver(IContainer container)
		{
			_activator = new RegistrationActivator();
			_container = container;
		}

		public object ResolveSingle<T>() where T : class
		{
			return ResolveSingle(typeof(T));
		}

		public IEnumerable<object> Resolve<T>() where T : class
		{
			return Resolve(typeof(T));
		}

		private object ResolveSingle(Type type)
		{
			var registration = _container.GetSourceTypes(type).Single();
			IsNotNull(registration, nameof(registration));
			return _activator.Activate(registration, ResolveConstructorParameters(registration));
		}

		private IEnumerable<object> Resolve(Type type)
		{
			var registrations = _container.GetSourceTypes(type);
			IsNotNull(registrations, nameof(registrations));
			return registrations.Select(r => _activator.Activate(r, ResolveConstructorParameters(r)));
		}

		private object[] ResolveConstructorParameters(Type type)
		{
			var constructors = type.GetConstructors();
			var parameterCollections = new List<ParameterCollection>();

			foreach (var constructor in constructors.OrderByDescending(c => c.GetParameters().Count()))
			{
				var parameterCollection = ResolveConstructorParameters(constructor);

				if (parameterCollection.IsComplete)
				{
					return parameterCollection.Parameters.ToArray();
				}

				parameterCollections.Add(parameterCollection);
			}

			throw new ResolverException(type, parameterCollections);
		}

		private ParameterCollection ResolveConstructorParameters(ConstructorInfo constructor)
		{
			var parameterCollection = new ParameterCollection(constructor);

			foreach (var parameter in constructor.GetParameters())
			{
				var parameterType = parameter.ParameterType;
				try
				{
					ResolveConstructorParameter(parameterType, parameterCollection.AddParameter);
				}
				catch (Exception)
				{
					parameterCollection.AddParameter(null);
				}
			}

			return parameterCollection;
		}

		private void ResolveConstructorParameter(Type parameterType, Action<object> addParameter)
		{
			IsReferenceType(parameterType);

			if (typeof(IEnumerable<>).IsAssignableFrom(parameterType))
			{
				var genericType = parameterType.GenericTypeArguments.Single();
				IsReferenceType(genericType);
				addParameter(Resolve(genericType));
				return;
			}

			addParameter(ResolveSingle(parameterType));
		}
	}
}
