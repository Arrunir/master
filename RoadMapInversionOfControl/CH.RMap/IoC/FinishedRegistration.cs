using CH.HogLib.Core;
using System;

namespace CH.RMap.IoC
{
	internal class FinishedRegistration
	{
		public FinishedRegistration(Type source, Type target)
		{
			Source = source;
			Target = target;
		}

		public Type Source { get; }
		public Type Target { get; }

		public override bool Equals(object obj)
		{
			return obj.GetHashCode() == GetHashCode();
		}

		public override int GetHashCode()
		{
			return HashCode.Start
				.Hash(Source)
				.Hash(Target);
		}
	}
}
