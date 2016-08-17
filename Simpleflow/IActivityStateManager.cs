/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;

namespace Simpleflow
{
	/// <summary>
	/// Descibes an activity state manager, which can trigger state changes using activities.
	/// </summary>
	public interface IActivityStateManager<TState, TActivity>
		: IStateManager<TState, TActivity>
	{
		ActivityResult Execute(IStateful<TState> obj, TActivity activity, params object[] args);
	}
}