using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ActiLifeAPILibrary
{
	public class Exceptions
	{
		/// <summary>
		/// Exception thrown for all API Connection exceptions.
		/// </summary>
		public class APIConnectionException : System.IO.IOException
		{
			public APIConnectionException() : base()
			{

			}
			public APIConnectionException(string message) : base(message)	
			{

			}
			public APIConnectionException(string message, Exception innerException):base(message, innerException)
			{

			}
		}
	}
}
