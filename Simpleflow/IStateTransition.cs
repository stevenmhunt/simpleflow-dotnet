/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;

namespace Simpleflow
{
	/// <summary>
	/// Describes a transition from one state to another.
	/// </summary>
	public interface IStateTransition<TState, TActivity>
	{
		/// <summary>
		/// The starting state.
		/// </summary>
		TState From { get; set; }

		/// <summary>
		/// The ending state.
		/// </summary>
		TState To { get; set; }
	}
}

