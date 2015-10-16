﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace CH.HogLib.Test.Utility
{
	public static class AsyncTestHelper
	{
		public static async Task ThrowsExceptionAsync<TException>(Func<Task> action, bool allowDerivedTypes = true)
		{
			try
			{
				await action();
				Assert.Fail($"Delegate did not throw expected exception {typeof(TException).Name}.");
			}
			catch (Exception ex)
			{
				if (allowDerivedTypes && !(ex is TException))
					Assert.Fail($"Delegate threw exception of type {ex.GetType().Name}, but {typeof(TException).Name} or a derived type was expected.");
				if (!allowDerivedTypes && ex.GetType() != typeof(TException))
					Assert.Fail($"Delegate threw exception of type {ex.GetType().Name}, but {typeof(TException).Name} was expected.");
			}
		}
	}
}