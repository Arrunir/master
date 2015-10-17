using CH.RMap.IoC.Activation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CH.RMap.IoC.Exceptions
{
	public class ResolverException : Exception
	{
		internal ResolverException(Type targetType, IEnumerable<ParameterCollection> parameterCollections) : base(GetMessage(targetType, parameterCollections))
		{
		}

		private static string GetMessage(Type targetType, IEnumerable<ParameterCollection> parameterCollections)
		{
			var builder = new StringBuilder();
			builder.AppendLine($"Cannot resolve type '{targetType.FullName}'. No resolvable constructor found.")
				.AppendLine("Available constructors:")
				.AppendLine();
			foreach (var parameterCollection in parameterCollections)
			{
				builder.AppendLine("----------------------------------------------------------------------------------");

				foreach (var matchedParameter in parameterCollection.GetMatchedParameters())
				{
					builder.Append(matchedParameter.Item2 ? "[X]" : "[ ]").AppendLine($" {matchedParameter.Item1.FullName}");
				}
			}

			return builder.ToString();
		}
	}
}
