/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;

namespace Simpleflow.Events
{
	/// <summary>
	/// Event arguments which reference a stateful object.
	/// </summary>
	public class StatefulEventArgs<TState> : EventArgs
	{
		/// <summary>
		/// Gets or sets the stateful object.
		/// </summary>
		public IStateful<TState> Obj { get; set; }
	}
}

