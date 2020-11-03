using System;
using System.Collections.Generic;
using System.Text;

namespace Dreamlines.Domain.Exceptions
{
	/// <summary>
	/// A baseclass for exceptions
	/// </summary>
	public abstract class DreamlinesException : Exception
	{
		/// <summary>
		/// The unique identifier for the exception
		/// </summary>
		public Guid ReferenceNumber { get; } = Guid.NewGuid();
		public string UserErrorMessage { get; }
		public DreamlinesException(string userErrorMessage, Exception innerException) : base(userErrorMessage, innerException)
		{
			UserErrorMessage = userErrorMessage;
		}
	}
}
