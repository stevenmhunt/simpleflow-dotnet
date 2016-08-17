/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;

namespace Simpleflow
{
	/// <summary>
	/// Describes an object which maintains a state.
	/// </summary>
	public interface IStateful<TState>	
	{
		/// <summary>
		/// The state of the object.
		/// </summary>
		TState State { get; set; }
	}
}