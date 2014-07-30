using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ActiLifeAPITester.Tests
{
	internal class ApiTests
	{

		//public class TestWaitForConsolePrompt : IApiTest
		//{
		//	#region IApiTest Members

		//	public string Name
		//	{
		//		get { return "Waiting To Send Next Command..."; }
		//	}

		//	public dynamic GetJSON() {
		//		Console.WriteLine("Press any key to continue...");
		//		Console.ReadKey();

		//		return null;
		//	}

		//	public bool IsValidResponse(JObject d) { return true; }

		//	#endregion
		//}

		public abstract class TestBase : IApiTest
		{
			public TestBase()
			{

			}
			public TestBase(dynamic json)
			{
				_json = json;

				if (json != null)
					try { Name = json.Action; }
					catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException) { }
			}

			#region IApiTest Members

			public string Name
			{
				get;
				protected set;
			}

			private dynamic _json = null;

			public virtual string GetJSON()
			{
				if (_json == null)
				{
					if (_json == null)
						throw new NotImplementedException();
				}

				JsonSerializerSettings dateFormattingSettings = new JsonSerializerSettings
				{
					Formatting = Newtonsoft.Json.Formatting.Indented,
					DateFormatHandling = DateFormatHandling.IsoDateFormat,
					DateTimeZoneHandling = DateTimeZoneHandling.Utc,
					Converters = new List<JsonConverter>() { new ActiLifeAPILibrary.Converters.JSONCustomDateConverter() }
				};

				return JsonConvert.SerializeObject(_json, dateFormattingSettings);
			}

			public virtual bool IsValidResponse(JObject d)
			{
				if (d == null) return false;

				if (!GetValueFromJToken<bool>(d, "Success", false)) return false;

				JToken payload;
				if (d.TryGetValue("payload", StringComparison.CurrentCultureIgnoreCase, out payload))
					return IsValidPayload(payload);

				return true;
			}

			protected virtual bool IsValidPayload(JToken payload)
			{
				if (payload == null) return false; return true;
			}

			#endregion IApiTest Members

			public T GetValueFromJToken<T>(Newtonsoft.Json.Linq.JToken j, string key, T defaultValue)
			{
				JToken obj = null;
				if (j is JObject)
					obj = ((JObject)j).GetValue(key, StringComparison.CurrentCultureIgnoreCase);
				else
					obj = j[key.ToLower()];

				if (obj == null) throw new ArgumentException("Unable to locate JSON token: \"" + key + "\"");

				T returnObj = default(T);

				if (obj is Newtonsoft.Json.Linq.JArray)
					returnObj = obj.ToObject<T>();
				else
					returnObj = obj.Value<T>();

				//Convert UTC datetimes back to local system time.  API is ISO8601; UTC is used!
				if (returnObj is DateTime)
					returnObj = Cast<T>(Convert.ToDateTime(returnObj).ToLocalTime());

				return returnObj;
			}

			/// <summary>Method used to dynamically cast (through reflection) one type to another type (object to a correct type).</summary>
			public static T Cast<T>(object o)
			{
				return (T)o;
			}
		}

		public class Tests
		{
			public class ActiLifeVersionTest : TestBase
			{
				public override string GetJSON()
				{
					return new ActiLifeAPILibrary.Models.Request.ActiLifeVersion().ToJson();
				}

				protected override bool IsValidPayload(JToken payload)
				{
					return GetValueFromJToken<string>(payload, "version", null) != null;
				}
			}

			public class APIVersionTest : TestBase
			{
				public override string GetJSON()
				{
					return new ActiLifeAPILibrary.Models.Request.APIVersion().ToJson();
				}

				protected override bool IsValidPayload(JToken payload)
				{
					return GetValueFromJToken<string>(payload, "version", null) != null;
				}
			}

			public class ActiLifeRestore : TestBase
			{
				public override string GetJSON()
				{
					return new ActiLifeAPILibrary.Models.Request.ActiLifeRestore().ToJson();
				}
			}

			public class ActiLifeMinimize : TestBase
			{
				public override string GetJSON()
				{
					return new ActiLifeAPILibrary.Models.Request.ActiLifeMinimize().ToJson();
				}
			}

			public class ActiLifeQuit : TestBase
			{
				public override string GetJSON()
				{
					return new ActiLifeAPILibrary.Models.Request.ActiLifeQuit().ToJson();
				}
			}

			public class ActiLifeNHANESWtv : TestBase
			{
				public ActiLifeNHANESWtv() : base() { }

				public override string GetJSON()
				{
					var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

					return new ActiLifeAPILibrary.Models.Request.NHANESWTV
					{
						Options = new ActiLifeAPILibrary.Models.Actions.NhanesWtv
						{
							Filename = System.IO.Path.Combine(assemblyDir, "input.gt3x")
						}
					}.ToJson();
				}

				protected override bool IsValidPayload(JToken payload)
				{
					if (!base.IsValidPayload(payload)) return false;

					dynamic d = this.GetValueFromJToken<dynamic>(payload, "results", null);

					if (d == null || d.NonWearBouts == null) return false;

					return true;
				}
			}

			public class ActiLifeDataScoring : TestBase
			{
				public ActiLifeDataScoring() : base() { }

				public override string GetJSON()
				{
					var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

					return new ActiLifeAPILibrary.Models.Request.DataScoring
					{
						Options = new ActiLifeAPILibrary.Models.Actions.DataScoring
						{
							FileInputPath = System.IO.Path.Combine(assemblyDir, "input.agd")
						}
					}.ToJson();
				}
			}
		}
	}
}
