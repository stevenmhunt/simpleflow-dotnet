/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;

namespace Simpleflow.Events
{
	/// <summary>
	/// Event arguments for the ActivityEnded event.
	/// </summary>
	public class ActivityEndedEventArgs<TState, TActivity>
		: ActivityStartedEventArgs<TState, TActivity>, 
		  IStateChangeEventArgs<TState>
	{
		/// <summary>
		/// The starting state.
		/// </summary>
		public TState From { get; set; }

		/// <summary>
		/// The ending state.
		/// </summary>
		public TState To { get; set; }	
	}
}