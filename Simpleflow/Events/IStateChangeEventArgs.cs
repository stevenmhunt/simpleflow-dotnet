/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;

namespace Simpleflow.Events
{
	/// <summary>
	/// Describes events which contain state change information.
	/// </summary>
	public interface IStateChangeEventArgs<TState>
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