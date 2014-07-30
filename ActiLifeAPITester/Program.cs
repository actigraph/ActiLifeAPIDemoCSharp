using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ActiLifeAPITester
{
	internal class Program
	{
        [STAThread]
		private static void Main(string[] args)
		{
			Trace.Listeners.Add(new ConsoleTraceListener(false));

			Console.WriteLine("Logging all TRACE statements from APILibrary.");
			Console.WriteLine("Starting Test GUI...");

			#region GUI Buildup

			// pretty forms
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			if (!System.Diagnostics.Debugger.IsAttached)
			{
				// Set the unhandled exception mode to force all Windows Forms errors to go through our handler.
				Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);
				// Add the event handler for handling UI thread exceptions to the event.
				Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
				// Add the event handler for handling non-UI thread exceptions to the event.
				AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
			}

			#endregion GUI Buildup

			using (ActiLifeAPILibrary.ActiLifeAPIConnection api = new ActiLifeAPILibrary.ActiLifeAPIConnection())
			{
				try { api.Connect(); }
				catch { }

				using (TestForm t = new TestForm())
				{
					t.SetAPI(api);
					Application.Run(t);
				}
			}
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
}