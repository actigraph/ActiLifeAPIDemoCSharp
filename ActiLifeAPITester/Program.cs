using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ActiLifeAPITester
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Trace.Listeners.Add(new ConsoleTraceListener(false));

			APITest api = new APITest();
			api.RunTests();

			Console.WriteLine("Press any key to continue....");
			Console.ReadKey();
		}
	}

	internal class APITest
	{
		private NamedPipeClientStream _pipe = null;

		private void Connect()
		{
			Trace.WriteLine("Connecting to ActiLife...");

			_pipe = new NamedPipeClientStream(".", "actilifeapi", PipeDirection.InOut);
			_pipe.Connect();
			_pipe.ReadMode = PipeTransmissionMode.Message; //important!

			Trace.WriteLine("Connected!");
		}

		public bool IsConnected
		{
			get { return _pipe != null && _pipe.IsConnected; }
		}

		public void RunTests()
		{
			Trace.WriteLine("Running Tests...");

			if (!IsConnected) Connect();

			List<ActiLifeAPITester.API.IApiTest> tests = new List<API.IApiTest>
			{
				 new API.Tests.ActiLifeVersionTest(),
				 new API.Tests.APIVersionTest(),
				 new API.Tests.ActiLifeMinimize(),
				 new API.Tests.ActiLifeRestore(),
				 //new API.Tests.ActiLifeNHANESWtv(),
				 new API.Tests.ActiLifeDataScoring(),
				 new API.TestWaitForConsolePrompt(),
				 new API.Tests.ActiLifeQuit()
			};

			for (int i = 0; i < tests.Count; i++)
			{
				var t = tests[i];

				Trace.WriteLine(string.Format("Running test {0} of {1}: \"{2}\"", i, tests.Count, t.Name));
				Trace.Indent();

				bool passed = false;

				var testjson = t.GetJSON();
				if (testjson != null)
				{
					SendData(GetJSON(testjson));
					passed = t.IsValidResponse(ReceiveData());
				}
				else 
					passed = t.IsValidResponse(null);

				Trace.Unindent();
				Trace.WriteLine("Test " + (passed ? "passed" : "failed"));
			}
		}

		private string GetJSON(dynamic d)
		{
			return JsonConvert.SerializeObject(d);
		}

		private bool SendData(string json)
		{
			if (_pipe != null && _pipe.IsConnected)
			{
				Trace.WriteLine("Sending " + json);

				//going to assume unicode here because we might have out of US customers using the API
				byte[] replyBytes = Encoding.UTF8.GetBytes(json);

				_pipe.Write(replyBytes, 0, replyBytes.Length);
				_pipe.WaitForPipeDrain();

				return true;
			}
			return false;
		}

		private JObject ReceiveData()
		{
			StringBuilder mb = new StringBuilder();

			// read one message from the server
			int byteCount = 0;
			byte[] buff = new byte[1024];
			do
			{
				byteCount = _pipe.Read(buff, 0, buff.Length);

				if (byteCount != 0)
					mb.Append(System.Text.Encoding.UTF8.GetString(buff, 0, byteCount));
			} while (!_pipe.IsMessageComplete && _pipe.IsConnected);

			Trace.WriteLine("Received " + mb.ToString());

			if (_pipe.IsConnected)
				return JObject.Parse(mb.ToString());
			return null;
		}
	}

	namespace API
	{
		internal interface IApiTest
		{
			string Name { get; }

			dynamic GetJSON();

			bool IsValidResponse(JObject d);
		}

		public class TestWaitForConsolePrompt : IApiTest
		{

			#region IApiTest Members

			public string Name
			{
				get { return "Waiting To Send Next Command..."; }
			}

			public dynamic GetJSON() {
				Console.WriteLine("Press any key to continue...");
				Console.ReadKey();

				return null;
			}

			public bool IsValidResponse(JObject d) { return true; }

			#endregion
		}

		public class TestBase : IApiTest
		{

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

			public virtual dynamic GetJSON()
			{
				if (_json == null)
					throw new NotImplementedException();
				return _json;
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
				public ActiLifeVersionTest()
					: base(new {Action = "ActiLifeVersion"}) { }

				protected override bool IsValidPayload(JToken payload)
				{
					return GetValueFromJToken<string>(payload, "version", null) != null;
				}
			}

			public class APIVersionTest : TestBase
			{
				public APIVersionTest()
					: base(new {Action = "APIVersion"}) { }

				protected override bool IsValidPayload(JToken payload)
				{
					return GetValueFromJToken<string>(payload, "version", null) != null;
				}
			}

			public class ActiLifeRestore : TestBase
			{
				public ActiLifeRestore()
					: base(new {Action = "ActiLifeRestore"}) { }
			}

			public class ActiLifeMinimize : TestBase
			{
				public ActiLifeMinimize()
					: base(new {Action = "ActiLifeMinimize"}) { }
			}

			public class ActiLifeQuit : TestBase
			{
				public ActiLifeQuit()
					: base(new {Action = "ActiLifeQuit"}) { }
			}

			public class ActiLifeNHANESWtv : TestBase
			{
				public ActiLifeNHANESWtv()
					: base("nhaneswtv")  { }

				public override dynamic GetJSON()
				{
					var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

					return new
					{
						Action = "nhaneswtv",
						args = new {filename = System.IO.Path.Combine(assemblyDir, "input.gt3x")}
					};
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
				public ActiLifeDataScoring()
					: base("datascoring") { }

				public override dynamic GetJSON()
				{
					var assemblyDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

					return new
					{
						Action = "datascoring",
						args = new 
						{ 
							filename = System.IO.Path.Combine(assemblyDir, "input.agd"),
							ee = true,
							mets = true,
							cutPoints = true,
							bouts = true,
							sedentary = true,
							stats = true
						}
					};
				}
			}
		}
	}
}