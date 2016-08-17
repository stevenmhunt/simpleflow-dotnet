/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;

namespace Simpleflow
{
	/// <summary>
	/// A state manager capable of initiating state changes based on the running activity.
	/// </summary>
	public class ActivityStateTransitionManager<TState, TActivity>
		: StateTransitionManager<TState, TActivity>, 
		  IActivityRunner<TState, TActivity>,
		  IActivityStateTransitionContainer<TState, TActivity>
	{
		/// <summary>
		/// Occurs when an activity is starting.
		/// </summary>
		public event EventHandler<ActivityStartingEventArgs<TState, TActivity>> ActivityStarting;

		/// <summary>
		/// Occurs when an activity has started.
		/// </summary>
		public event EventHandler<ActivityStartedEventArgs<TState, TActivity>> ActivityStarted;

		/// <summary>
		/// Occurs after an activity has ended.
		/// </summary>
		public event EventHandler<ActivityEndedEventArgs<TState, TActivity>> ActivityEnded;

		/// <summary>
		/// Raises the activity starting event.
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <param name="activity">Activity.</param>
		/// <param name="args">Arguments.</param>
		protected virtual bool OnActivityStarting(IStateful<TState> obj, TActivity activity, object[] args)
		{
			if (ActivityStarting != null)
			{
				var eventArgs = new ActivityStartingEventArgs<TState, TActivity>()
				{
					Obj = obj,
					Activity = activity,
					Arguments = args,
					Cancel = false
				};

				ActivityStarting(this, eventArgs);

				return !eventArgs.Cancel;
			}
			return true;		
		}

		/// <summary>
		/// Raises the activity started event.
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <param name="activity">Activity.</param>
		/// <param name="args">Arguments.</param>
		protected virtual void OnActivityStarted(IStateful<TState> obj, TActivity activity, object[] args)
		{
			if (ActivityStarted != null)
			{
				var eventArgs = new ActivityStartedEventArgs<TState, TActivity>()
				{
					Obj = obj,
					Activity = activity,
					Arguments = args
				};

				ActivityStarted(this, eventArgs);
			}
		}	

		/// <summary>
		/// Raises the activity ended event.
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <param name="fromState">From state.</param>
		/// <param name="toState">To state.</param>
		/// <param name="activity">Activity.</param>
		/// <param name="args">Arguments.</param>
		protected virtual void OnActivityEnded(IStateful<TState> obj, TState fromState, TState toState, TActivity activity, object[] args)
		{
			if (ActivityEnded != null)
			{
				var eventArgs = new ActivityEndedEventArgs<TState, TActivity>()
				{
					Obj = obj,
					Activity = activity,
					Arguments = args,
					From = fromState,
					To = toState
				};

				ActivityEnded(this, eventArgs);
			}
		}

		/// <summary>
		/// Gets the activity state transitions.
		/// </summary>
		/// <returns>The activity state transitions.</returns>
		private IEnumerable<IActivityStateTransition<TState, TActivity>> GetActivityStateTransitions()
		{
			return Transitions.Cast<IActivityStateTransition<TState, TActivity>>();
		}

		/// <summary>
		/// Gets the transitions.
		/// </summary>
		/// <value>The transitions.</value>
		IEnumerable<IActivityStateTransition<TState, TActivity>> IActivityStateTransitionContainer<TState, TActivity>.Transitions
		{
			get { return GetActivityStateTransitions(); }
		}

		/// <summary>
		/// Parameterized constructor.
		/// </summary>
		/// <param name="transitions">Transitions.</param>
		public ActivityStateTransitionManager(IEnumerable<IActivityStateTransition<TState, TActivity>> transitions)
			: base(transitions)
		{
		}

		/// <summary>
		/// Gets the state to transition to.
		/// </summary>
		/// <param name="obj">Object.</param>
		/// <param name="activity">Activity.</param>
		/// <param name="args">Arguments.</param>
		/// <returns>The next state.</returns>
		protected virtual TState GetNextState(IStateful<TState> obj, TActivity activity, params object[] args)

		{
			return GetActivityStateTransitions()
				.Where(i => (i.From == null || i.From.Equals(obj.State)) &&
					i.Activity .Equals(activity))
				.Select(i => i.To)
				.FirstOrDefault();
		}

		/// <summary>
		/// Given a stateful object, an activity and arguments, executes the activity and any state change against the object.
		/// </summary>
		/// <param name="obj">The stateful object.</param>
		/// <param name="activity">The activity to execute.</param>
		/// <param name="args">Arguments to provide to the activity.</param>
		public ActivityResult Execute(IStateful<TState> obj, TActivity activity, params object[] args)
		{
			if (OnActivityStarting(obj, activity, args))
			{
				OnActivityStarted(obj, activity, args);
				TState prevState = obj.State, 
				nextState = GetNextState(obj, activity, args);
				if (nextState == null || nextState.Equals(default(TState)))
				{
					return ActivityResult.ActionNotFound;
				}
				ChangeState(obj, nextState);
				OnActivityEnded(obj, prevState, nextState, activity, args);
			}
			return ActivityResult.Cancelled;
		}
	}
}

