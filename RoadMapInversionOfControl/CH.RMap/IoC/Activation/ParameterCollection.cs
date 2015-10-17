using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CH.RMap.IoC.Activation
{
	internal class ParameterCollection
	{
		private ConstructorInfo _constructor;
		private IList<object> _parameters;

		public ParameterCollection(ConstructorInfo constructor)
		{
			_constructor = constructor;
			_parameters = new List<object>();
		}

		public bool IsComplete => VerifyParameters();

		public IEnumerable<object> Parameters => _parameters;

		public void AddParameter(object parameter)
		{
			_parameters.Add(parameter);
		}

		internal IEnumerable<Tuple<Type, bool>> GetMatchedParameters()
		{
			var constructorParameters = _constructor.GetParameters();

			for (int i = 0; i < constructorParameters.Count(); i++)
			{
				yield return new Tuple<Type, bool>(constructorParameters[i].ParameterType, _parameters[i] != null);
			}
		}

		private bool VerifyParameters()
		{
			var constructorParameters = _constructor.GetParameters();

			if (constructorParameters.Count() != _parameters.Count)
			{
				return false;
			}

			for (int i = 0; i < constructorParameters.Count(); i++)
			{
				if (_parameters[i] == null || !constructorParameters[i].ParameterType.IsAssignableFrom(_parameters[i].GetType()))
				{
					return false;
				}
			}

			return true;
		}
	}
}
