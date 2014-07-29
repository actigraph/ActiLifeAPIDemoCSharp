using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ActiLifeAPITester
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Trace.Listeners.Add(new ConsoleTraceListener(false));

			Console.WriteLine("Logging all TRACE statements from APILibrary.");
			Console.WriteLine("Starting Test GUI...");

			#region GUI Buildup

			// pretty forms
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			// Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
			// Add the event handler for handling UI thread exceptions to the event.
			Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
			// Add the event handler for handling non-UI thread exceptions to the event.
			AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

			#endregion GUI Buildup

			using (ActiLifeAPILibrary.ActiLifeAPIConnection api = new ActiLifeAPILibrary.ActiLifeAPIConnection())
			{
				using (TestForm t = new TestForm())
				{
					t.SetAPI(api);
					Application.Run(t);
				}
			}

			Console.WriteLine("Press any key to continue....");
			Console.ReadKey();
		}

		#region Unhandled Exception Catching

		// Handle the UI exceptions by showing a dialog box, and asking the user whether
		// or not they wish to abort execution.
		public static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			HandleUnhandledException(e.Exception);
		}
		/// <summary>
		/// Handles any unhandles CLR exceptions. Note that in .NET 2.0 unless you set
		/// <legacyUnhandledExceptionPolicy enabled="1"/> in the app.config file your
		/// application will exit no matter what you do here anyway. The purpose of this
		/// eventhandler is not forcing the application to continue but rather logging
		/// the exception and enforcing a clean exit where all the finalizers are run
		/// (releasing the resources they hold)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		public static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			//http://kenneththorman.blogspot.com/2010/10/windows-forms-net-handling-unhandled.html

			HandleUnhandledException(e.ExceptionObject);
		}
		private static void HandleUnhandledException(object e)
		{
			Exception ex = e as Exception;

			Trace.WriteLine("UNHANDLED EXCEPTION: " + ex.ToString());

			if (ex != null)
			{
				if (MessageBox.Show(ex.ToString(), "Unhandled Exception.  Continue?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) != DialogResult.Yes)
				{
					Application.Exit();
					Environment.Exit(-1);
				}
			}
			else
				Environment.Exit(-1);
		}

		#endregion Unhandled Exception Catching
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
							FileInputPath = System.IO.Path.Combine(assemblyDir, "input.agd"),
							UseWTVData = true,
							UseLogDiaries = false,
							CalculateEnergyExpenditure = true,
							CalculateMETs = true,
							CalculateCutPoints = true,
							CalculateBouts = true,
							CalculateSedentaryAnalysis = true,
							IncludeExtraStatistics = true,
							IncludeDailyResults = false,
							IncludeHourlyResults = false
						}
					};
				}
			}
		}
	}
}