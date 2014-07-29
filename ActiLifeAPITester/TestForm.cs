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

			btnConnect.Click += async (o, e) =>
			{
				if (_api == null) return;

				await _api.Connect();
			};
		}

		ActiLifeAPILibrary.ActiLifeAPIConnection _api;

		public void SetAPI(ActiLifeAPILibrary.ActiLifeAPIConnection api)
		{
			_api = api;
		}
	}
}
