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

			txtRequest.KeyDown += HandleSpecial_KeyDown;

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

				try
				{
					await _api.Connect();
				}
				catch (AggregateException ex) { MessageBox.Show(this, ex.Flatten().ToString(), "Issue Connecting To ActiLife", MessageBoxButtons.OK, MessageBoxIcon.Error); }
			};

			btnSend.Click += async (o, e) =>
			{
				lblResponseStatus.Text = "";

				if (_api == null) return;
				if (txtRequest.TextLength == 0) return;

				txtResponse.AppendText((txtResponse.TextLength != 0 ? "\r\n\r\n" : "") + "REQUEST: \r\n" + txtRequest.Text + "\r\n\r\n");

				string response = "";
				try
				{
					var task = _api.SendData(txtRequest.Text);
					response = await task;

					if (task.IsFaulted || task.IsCanceled)
					{
						if (task.Exception != null)
							MessageBox.Show(this, task.Exception.ToString(), "Issue Sending Request", MessageBoxButtons.OK, MessageBoxIcon.Error);
						else
							lblResponseStatus.Text = "Issue Sending Request!";
						return;
					}
				}
				catch (AggregateException ex) { MessageBox.Show(this, ex.Flatten().ToString(), "Issue Sending Request", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

				txtResponse.AppendText("RESPONSE: \r\n" + response);
				txtResponse.SelectionStart = txtResponse.TextLength - 1;
			};
		}

		ActiLifeAPILibrary.ActiLifeAPIConnection _api;

		public void SetAPI(ActiLifeAPILibrary.ActiLifeAPIConnection api)
		{
			_api = api;
		}

		/// <summary>
		/// Allows the TextBox to handle CTRL+Backspace (delete word) and CTRL+Enter (send command)
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void HandleSpecial_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyData) //http://stackoverflow.com/a/1614438
			{
				case (Keys.Back | Keys.Control):
					e.SuppressKeyPress = true;
					TextBox textbox = (TextBox)sender;
					int i;
					if (textbox.SelectionStart.Equals(0))
					{
						return;
					}
					int space = textbox.Text.LastIndexOf(' ', textbox.SelectionStart - 1);
					int line = textbox.Text.LastIndexOf("\r\n", textbox.SelectionStart - 1);
					if (space > line)
					{
						i = space;
					}
					else
					{
						i = line;
					}
					if (i > -1)
					{
						while (textbox.Text.Substring(i - 1, 1).Equals(' '))
						{
							if (i.Equals(0))
							{
								break;
							}
							i--;
						}
						textbox.Text = textbox.Text.Substring(0, i) + textbox.Text.Substring(textbox.SelectionStart);
						textbox.SelectionStart = i;
					}
					else if (i.Equals(-1))
					{
						textbox.Text = textbox.Text.Substring(textbox.SelectionStart);
					}
					break;
				case (Keys.Enter | Keys.Control):
					e.SuppressKeyPress = true;
					btnSend.PerformClick();
					break;
			}
		}
	}
}
