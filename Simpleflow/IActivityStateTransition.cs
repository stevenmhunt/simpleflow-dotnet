/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;

namespace Simpleflow.Events
{
	/// <summary>
	/// Describes an activity state transition, which binds an activity to a state change.
	/// </summary>
	public interface IActivityStateTransition<TState, TActivity>
		: IStateTransition<TState, TActivity>
	{
		/// <summary>
		/// The activity associated with the state change.
		/// </summary>
		TActivity Activity { get; set; }
	}
}

