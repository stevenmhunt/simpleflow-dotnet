/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;

namespace Simpleflow
{
	/// <summary>
	/// Describes an activity runner, whih can execute activities against a stateful object.
	/// </summary>
	public interface IActivityRunner<TState, TActivity>
	{
		/// <summary>
		/// Occurs when an activity is starting.
		/// </summary>
		event EventHandler<ActivityStartingEventArgs<TState, TActivity>> ActivityStarting;

		/// <summary>
		/// Occurs when an activity has started.
		/// </summary>
		event EventHandler<ActivityStartedEventArgs<TState, TActivity>> ActivityStarted;

		/// <summary>
		/// Occurs after an activity has ended.
		/// </summary>
		event EventHandler<ActivityEndedEventArgs<TState, TActivity>> ActivityEnded;

		/// <summary>
		/// Given a stateful object, an activity and arguments, executes the activity and any state change against the object.
		/// </summary>
		/// <param name="obj">The stateful object.</param>
		/// <param name="activity">The activity to execute.</param>
		/// <param name="args">Arguments to provide to the activity.</param>
		ActivityResult Execute(IStateful<TState> obj, TActivity activity, params object[] args);
	}

	/// <summary>
	/// Describes the possible activity result values.
	/// </summary>
	public enum ActivityResult
	{
		/// <summary>
		/// Indicates that the activity was completed successfully.
		/// </summary>
		Success,
		/// <summary>
		/// Indicates that a ActivityStarting event handler cancelled the activity.
		/// </summary>
		Cancelled,
		/// <summary>
		/// Indicates that the request activity was not found.
		/// </summary>
		ActivityNotFound
	}
}

