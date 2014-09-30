using System.ComponentModel;

namespace ActiLifeAPILibrary.Models.WearTimeValidation
{
	/// <summary>
	/// Interface for wear time validation options
	/// </summary>
	internal interface IWTVOptions
	{
		/// <summary>
		/// The Algorithm name for the wear time validation option
		/// </summary>
		WTVAlgorithm Algorithm { get; }

		/// <summary>
		/// Returns the WTV Options serialized into JSON.
		/// </summary>
		/// <returns></returns>
		string GetJSON();
	}

	/// <summary> Denotes the type of WTV Algorithm used. </summary>
	[DefaultValue(Unknown)]
	public enum WTVAlgorithm
	{
		/// <summary> We don't know what the algorithm is! </summary>
		Unknown = -1,

		/// <summary>2007 Troiano Algorithm</summary>
		Troiano = 0,

		/// <summary>2011 Choi Algorithm</summary>
		Choi = 1,

		/// <summary>Custom ActiGraph Algorithm</summary>
		Daily = 2
	}
}
