/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;

namespace Simpleflow.Events
{
	/// <summary>
	/// Event arguments for the StateChanged event.
	/// </summary>
	public class StateChangingEventArgs<TState, TActivity>
		: StateChangedEventArgs<TState, TActivity>, 
		  ICancellableEventArgs
	{
		/// <summary>
		/// Indicates whether or not the cancel the activity run.
		/// </summary>
		public bool Cancel { get; set; }
	}
}

