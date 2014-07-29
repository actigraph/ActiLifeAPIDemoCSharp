using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiLifeAPILibrary
{
	public partial class ActiLifeAPIConnection : IDisposable
	{
		public ActiLifeAPIConnection()
		{

		}

		private NamedPipeClientStream _pipe = null;
		object _lock = new object();

		public async Task Connect()
		{
			Trace.WriteLine("Connecting to ActiLife...");

			new TaskFactory().StartNew(() =>
			{
				try
				{
					lock (_lock)
					{
						_pipe = new NamedPipeClientStream(".", "actilifeapi", PipeDirection.InOut);
						_pipe.Connect();
						_pipe.ReadMode = PipeTransmissionMode.Message; //important!
					}

					Trace.WriteLine("Connected!");
				}
				catch (Exception ex) { throw new Exceptions.APIConnectionException("Unable to connect. \"" + ex.Message + "\"", ex); }
			});
		}

		public bool IsConnected
		{
			get
			{
				lock (_lock)
					return _pipe != null && _pipe.IsConnected;
			}
		}

		public async Task<string> SendData(string json)
		{
			if (IsConnected)
			{
				Trace.WriteLine("Sending " + json);

				lock (_lock)
				{
					//check status again while in lock
					if (!IsConnected) throw new Exceptions.APIConnectionException("API is not connected!");

					try
					{
						//going to assume unicode here because we might have out of US customers using the API
						byte[] replyBytes = Encoding.UTF8.GetBytes(json);

						_pipe.Write(replyBytes, 0, replyBytes.Length);
						_pipe.WaitForPipeDrain();
					}
					catch (Exception ex) { throw new Exceptions.APIConnectionException("Unable to send data. \"" + ex.Message + "\"", ex); }
				}

				return await ReceiveData();
			}
			return null;
		}

		private Task<string> ReceiveData()
		{
			return new TaskFactory<string>().StartNew(() =>
			{
				StringBuilder mb = new StringBuilder();

				lock (_lock)
				{
					//check status again while in lock
					if (!IsConnected) throw new Exceptions.APIConnectionException("API is not connected!");

					try
					{
						// read one message from the server
						int byteCount = 0;
						byte[] buff = new byte[1024];
						do
						{
							byteCount = _pipe.Read(buff, 0, buff.Length);

							if (byteCount != 0)
								mb.Append(System.Text.Encoding.UTF8.GetString(buff, 0, byteCount));
						} while (IsConnected && !_pipe.IsMessageComplete);
					}
					catch (Exception ex) { throw new Exceptions.APIConnectionException("Unable to send data. \"" + ex.Message + "\"", ex); }
				}
				Trace.WriteLine("Received " + mb.ToString());

				if (IsConnected)
					return mb.ToString();
				throw new Exceptions.APIConnectionException("API is not connected!");
			});
		}

		#region IDisposable Members

		public void Dispose()
		{
			lock (_lock)
				if (_pipe != null)
					_pipe.Dispose();
		}

		#endregion
	}
}
