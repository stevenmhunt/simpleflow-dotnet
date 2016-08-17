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
	/// A state manager which validates the requested state change against the provided transitions.
	/// </summary>
	public class StateTransitionManager<TState, TActivity> 
		: StateManager<TState, TActivity>,
		  IStateTransitionContainer<TState, TActivity>
	{
		/// <summary>
		/// Gets a collection of state transitions.
		/// </summary>
		public IEnumerable<IStateTransition<TState, TActivity>> Transitions { get; private set; }

		/// <summary>
		/// Parameterized constructor.
		/// </summary>
		/// <param name="transitions">A collection of transitions.</param>
		public StateTransitionManager(IEnumerable<IStateTransition<TState, TActivity>> transitions)
		{
			Transitions = transitions;
		}

		/// <summary>
		/// Validates the state change.
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <param name="newState">New state.</param>
		/// <returns>A value indicating whether or not the validation was successful.</returns>
		protected virtual bool ValidateStateChange(IStateful<TState> obj, TState newState)
		{
			return Transitions.Any(i => 
				(i.From == null || i.From.Equals(obj.State)) &&
				(i.To == null || i.To.Equals(newState)));
		}

		/// <summary>
		/// Changes the state.
		/// </summary>
		/// <returns>The state.</returns>
		/// <param name="obj">Object.</param>
		/// <param name="newState">New state.</param>
		public override StateChangeResult ChangeState(IStateful<TState> obj, TState newState)
		{
			if (ValidateStateChange(obj, newState))
			{
				return base.ChangeState(obj, newState);
			}
			return StateChangeResult.ValidationError;
		}
	}
}