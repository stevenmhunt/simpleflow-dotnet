/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;

namespace Simpleflow.Events
{
	/// <summary>
	/// Event arguments for the ActivityStarted event.
	/// </summary>
	public class ActivityStartedEventArgs<TState, TActivity>
		: StatefulEventArgs<TState>
	{
		/// <summary>
		/// The activity that was started.
		/// </summary>
		public TActivity Activity { get; set; }

		/// <summary>
		/// The arguments provided to the activity.
		/// </summary>
		public object[] Arguments { get; set; }
	}
}