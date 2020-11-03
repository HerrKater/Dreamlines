using System;

namespace Dreamlines.Domain.Exceptions
{
	/// <summary>
	/// An exception to represent unexpected errors
	/// </summary>
	public class DreamlinesTechnicalIssue : DreamlinesException
	{
		public DreamlinesTechnicalIssue(string userErrorMessage, Exception innerException) : base(userErrorMessage, innerException)
		{
			if (string.IsNullOrWhiteSpace(userErrorMessage))
			{
				userErrorMessage = $"Ooops, an unexpected error happened. The error's details can be found under the following ID : {ReferenceNumber}";
			}
		}
	}
}
