using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ActiLifeAPITester
{
	class Program
	{
		static void Main(string[] args)
		{
			Trace.Listeners.Add(new ConsoleTraceListener(false));

			APITest api = new APITest();
			api.RunTests();


			Console.WriteLine("Press any key to continue....");
			Console.ReadKey();
		}
	}

	class APITest
	{
		NamedPipeClientStream _pipe = null;

		void Connect()
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
				 new API.Tests.ActiLifeRestore()
			};

			for (int i = 0; i < tests.Count; i++)
			{
				var t = tests[i];

				Trace.WriteLine(string.Format("Running test {0} of {1}: \"{2}\"", i, tests.Count, t.Name));
				Trace.Indent();

				SendData(GetJSON(t.GetJSON()));

				bool passed = t.IsValidResponse(ReceiveData());

				Trace.Unindent();
				Trace.WriteLine("Test " + (passed ? "passed" : "failed"));
			}
		}


		string GetJSON(dynamic d)
		{
			return JsonConvert.SerializeObject(d);
		}
		bool SendData(string json)
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

		JObject ReceiveData()
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
		interface IApiTest
		{
			string Name { get; }
			dynamic GetJSON();
			bool IsValidResponse(JObject d);
		}

		public class TestBase : IApiTest
		{
			public TestBase(string name)
			{
				Name = name;
			}
			public TestBase(string name, dynamic json)
			{
				Name = name;
				_json = json;
			}

			#region IApiTest Members

			public string Name
			{
				get;
				protected set;
			}

			dynamic _json = null;
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
			protected virtual bool IsValidPayload(JToken payload) { if (payload == null) return false; return true; }

			#endregion

			public T GetValueFromJToken<T>(Newtonsoft.Json.Linq.JToken j, string key, T defaultValue)
			{
				JToken obj = null;
				if (j is JObject)
					obj = ((JObject)j).GetValue(key, StringComparison.CurrentCultureIgnoreCase);
				else
					obj = j[key.ToLower()];

				if (obj == null) return defaultValue;

				if (obj is Newtonsoft.Json.Linq.JArray)
					return obj.ToObject<T>();
				else
					return obj.Value<T>();
			}
		}

		public class Tests
		{
			public class ActiLifeVersionTest : TestBase
			{
				public ActiLifeVersionTest()
					: base("ActiLifeVersion", new { Action = "ActiLifeVersion" })
				{ }

				protected override bool IsValidPayload(JToken payload)
				{
					return GetValueFromJToken<string>(payload, "version", null) != null;
				}
			}
			public class APIVersionTest : TestBase
			{
				public APIVersionTest()
					: base("APIVersion", new { Action = "APIVersion" })
				{

				}
				protected override bool IsValidPayload(JToken payload)
				{
					return GetValueFromJToken<string>(payload, "version", null) != null;
				}
			}
			public class ActiLifeRestore : TestBase
			{
				public ActiLifeRestore()
					: base("ActiLifeRestore", new { Action ="ActiLifeRestore"})
				{

				}
			}
			public class ActiLifeMinimize : TestBase
			{
				public ActiLifeMinimize()
					:base ("ActiLifeMinimize", new { Action = "ActiLifeMinimize"})
				{

				}
			}
		}
	}
}
