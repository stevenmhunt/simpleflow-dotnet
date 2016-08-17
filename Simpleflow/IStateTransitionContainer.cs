/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;
using System.Collections.Generic;

namespace Simpleflow
{
	/// <summary>
	/// A container for state transitions.
	/// </summary>
	public interface IStateTransitionContainer<TState, TActivity>
	{
		/// <summary>
		/// Gets a collection of state transitions.
		/// </summary>
		IEnumerable<IStateTransition<TState, TActivity>> Transitions { get; }
	}
}

