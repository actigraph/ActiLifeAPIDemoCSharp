using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ActiLifeAPITester
{
	public partial class TestForm : Form
	{
		public TestForm()
		{
			InitializeComponent();

			tmrConnected.Tick += (o, e) =>
			{
				if (_api != null && _api.IsConnected)
				{
					lblConnectionStatus.Text = "Connected to ActiLife";
					pnlSendReceive.Enabled = true;
				}
				else
				{
					if (_api != null && _api.IsConnecting)
						lblConnectionStatus.Text = "Connecting...";
					else
						lblConnectionStatus.Text = "Disconnected.";

					pnlSendReceive.Enabled = false;
				}
			};

			txtRequest.TextChanged += (o, e) => { btnSend.Enabled = txtRequest.TextLength != 0; };

			btnConnect.Click += async (o, e) =>
			{
				if (_api == null) return;

				await _api.Connect();
			};

			btnSend.Click += async (o, e) =>
			{
				lblResponseStatus.Text = "";

				if (_api == null) return;
				if (txtRequest.TextLength == 0) return;

				txtResponse.AppendText((txtResponse.TextLength != 0 ? "\r\n\r\n" : "") + "REQUEST: \r\n" + txtRequest.Text + "\r\n\r\n");

				var task = _api.SendData(txtRequest.Text);
				string response = await task;

				if (task.IsFaulted || task.IsCanceled)
				{
					if (task.Exception != null)
						MessageBox.Show(this, task.Exception.ToString(), "Issue Sending Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
					else
						lblResponseStatus.Text = "Issue Sending Request!";
				}

				txtResponse.AppendText("RESPONSE: \r\n" + response);
				txtResponse.SelectionStart = txtResponse.TextLength - 1;
			};
		}

		ActiLifeAPILibrary.ActiLifeAPIConnection _api;

		public void SetAPI(ActiLifeAPILibrary.ActiLifeAPIConnection api)
		{
			_api = api;
		}
	}
}
