using Newtonsoft.Json;

namespace ActiLifeAPILibrary.Models.WearTimeValidation
{
	/// <summary>
	/// Basic implementation of IWTVOptions; no actual options other than what's required by the interface.
	/// </summary>
	public class BaseWTVOptions : IWTVOptions
	{
		/// <summary>
		/// The Algorithm name for the wear time validation option
		/// </summary>
		[JsonIgnore]
		public virtual WTVAlgorithm Algorithm
		{
			get;
			set;
		}

		/// <summary>
		/// Returns the WTV Options serialized into JSON.
		/// </summary>
		/// <returns></returns>
		public string GetJSON()
		{
			return JsonConvert.SerializeObject(this);
		}
	}
}
