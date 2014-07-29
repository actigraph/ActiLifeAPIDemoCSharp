﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiLifeAPILibrary
{
    public class ActiLifeAPIConnection
    {
		public ActiLifeAPIConnection()
		{

		}

		private NamedPipeClientStream _pipe = null;

		public void Connect()
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

		public async Task<string> SendData(string json)
		{
			if (IsConnected)
			{
				Trace.WriteLine("Sending " + json);

				//going to assume unicode here because we might have out of US customers using the API
				byte[] replyBytes = Encoding.UTF8.GetBytes(json);

				_pipe.Write(replyBytes, 0, replyBytes.Length);
				_pipe.WaitForPipeDrain();

				return await ReceiveData();
			}
			return null;
		}

		private Task<string> ReceiveData()
		{
			return new TaskFactory<string>().StartNew(() =>
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
				} while (IsConnected && !_pipe.IsMessageComplete);

				Trace.WriteLine("Received " + mb.ToString());

				if (IsConnected)
					return mb.ToString();
				return null;
			});
		}
    }
}