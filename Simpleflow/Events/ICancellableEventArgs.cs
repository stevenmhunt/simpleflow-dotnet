/**************************************************
 * Simpleflow
 * Written by Steven Hunt
 * MIT License
 **************************************************/

using System;

namespace Simpleflow.Events
{
	/// <summary>
	/// Describes events which can be cancelled.
	/// </summary>
	public interface ICancellableEventArgs
	{
		/// <summary>
		/// Indicates whether or not the cancel the activity run.
		/// </summary>
		bool Cancel { get; set; }
	}
}