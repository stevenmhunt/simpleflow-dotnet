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
	/// A container for activity state transitions,
	/// </summary>
	public interface IActivityStateTransitionContainer<TState, TActivity>
	{
		/// <summary>
		/// A collection of activity state transitions.
		/// </summary>
		IEnumerable<IActivityStateTransition<TState, TActivity>> Transitions { get; }
	}
}

