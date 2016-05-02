using System.Collections.Generic;

namespace CH.HogLib.Core
{
	public struct HashCode
	{
		private readonly int _hashCode;

		private HashCode(int hashCode)
		{
			_hashCode = hashCode;
		}

		public static HashCode Start
		{
			get { return new HashCode(17); }
		}

		public static implicit operator int (HashCode hashCode)
		{
			return hashCode.GetHashCode();
		}

		public HashCode Hash<T>(T obj)
		{
			var c = EqualityComparer<T>.Default;
			var h = c.Equals(obj, default(T)) ? 0 : obj.GetHashCode();
			unchecked { h += _hashCode * 31; }
			return new HashCode(h);
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}
	}
}
