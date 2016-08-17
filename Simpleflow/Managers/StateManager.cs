/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;
using System.Collections.Generic;

namespace Simpleflow.Managers
{
	/// <summary>
	/// A basic state manager capable of changing states.
	/// </summary>
	public class StateManager<TState, TActivity>
		: IStateManager<TState, TActivity>
	{
		/// <summary>
		/// Occurs when the state of an object is changing.
		/// </summary>
		public event EventHandler<StateChangingEventArgs<TState, TActivity>> StateChanging;

		/// <summary>
		/// Occurs when the state of an object has changed.
		/// </summary>
		public event EventHandler<StateChangedEventArgs<TState, TActivity>> StateChanged;

		/// <summary>
		/// Raises the state changing event.
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <param name="fromState">From state.</param>
		/// <param name="toState">To state.</param>
		protected virtual bool OnStateChanging(IStateful<TState> obj, TState fromState, TState toState)
		{
			if (StateChanging != null)
			{
				var eventArgs = new StateChangingEventArgs<TState, TActivity>()
				{
					Obj = obj,
					From = fromState,
					To = toState,
					Cancel = false
				};


				StateChanging(this, eventArgs);

				return !eventArgs.Cancel;
			}
			return true;
		}

		/// <summary>
		/// Raises the state changed event.
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <param name="fromState">From state.</param>
		/// <param name="toState">To state.</param>
		protected virtual void OnStateChanged(IStateful<TState> obj, TState fromState, TState toState)
		{
			if (StateChanged != null)
			{
				var eventArgs = new StateChangedEventArgs<TState, TActivity>()
				{
					Obj = obj,
					From = fromState,
					To = toState
				};

				StateChanged(this, eventArgs);
			}
		}

		/// <summary>
		/// Given a stateful object and a state, changes the state of the object.
		/// </summary>
		/// <returns>The state change result.</returns>
		/// <param name="obj">The stateful object.</param>
		/// <param name="newState">The new state.</param>
		public virtual StateChangeResult ChangeState(IStateful<TState> obj, TState newState)
		{
			TState prevState = obj.State;
			if (OnStateChanging(obj, prevState, newState))
			{
				obj.State = newState;
				OnStateChanged(obj, prevState, newState);
				return StateChangeResult.Success;
			}
			return StateChangeResult.Cancelled;
		}
	}
}