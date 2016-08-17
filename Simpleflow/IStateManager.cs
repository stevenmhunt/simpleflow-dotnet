/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;

namespace Simpleflow
{
	/// <summary>
	/// Describes a state manager, which controls the changing of states within stateful objects.
	/// </summary>
	public interface IStateManager<TState, TActivity>
	{
		/// <summary>
		/// Occurs when the state of an object is changing.
		/// </summary>
		event EventHandler<StateChangingEventArgs<TState, TActivity>> StateChanging;

		/// <summary>
		/// Occurs when the state of an object has changed.
		/// </summary>
		event EventHandler<StateChangedEventArgs<TState, TActivity>> StateChanged;

		/// <summary>
		/// Given a stateful object and a state, changes the state of the object.
		/// </summary>
		/// <returns>The state change result.</returns>
		/// <param name="obj">The stateful object.</param>
		/// <param name="newState">The new state.</param>
		StateChangeResult ChangeState(IStateful<TState> obj, TState newState);
	}

	/// <summary>
	/// Describes the possible state change result values.
	/// </summary>
	public enum StateChangeResult
	{
		/// <summary>
		/// Indicates that the state was changed successfully.
		/// </summary>
		Success,
		/// <summary>
		/// Indicates that a StateChanging event handler cancelled the state change.
		/// </summary>
		Cancelled,
		/// <summary>
		/// Indicates that a validation error occurred before running the state change.
		/// </summary>
		ValidationError,
		/// <summary>
		/// Indicates that a general error occurred before running the state change.
		/// </summary>
		GeneralError
	}
}

