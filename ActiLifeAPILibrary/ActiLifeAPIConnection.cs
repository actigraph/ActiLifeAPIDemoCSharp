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
			await TaskEx.Run(() =>
			{
				Trace.WriteLine("Connecting to ActiLife...");
				try
				{
					lock (_lock)
					{
						if (_pipe == null)
						{
							_pipe = new NamedPipeClientStream(".", "actilifeapi", PipeDirection.InOut);
							_pipe.ReadMode = PipeTransmissionMode.Message; //important!
						}
						_pipe.Connect();
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
				return _pipe != null && _pipe.IsConnected;
			}
		}

		public async Task<string> SendData(string json)
		{
			if (IsConnected)
			{
				await TaskEx.Run(() =>
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
				});

				return await ReceiveData();
			}
			return null;
		}

		private async Task<string> ReceiveData()
		{
			return await TaskEx.Run<string>(() =>
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
