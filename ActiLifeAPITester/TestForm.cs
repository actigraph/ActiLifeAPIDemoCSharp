﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
					grpTests.Enabled = true;
					btnConnect.Enabled = false;
				}
				else
				{
					if (_api != null && _api.IsConnecting)
						lblConnectionStatus.Text = "Connecting...";
					else
						lblConnectionStatus.Text = "Disconnected.";

					pnlSendReceive.Enabled = false;
					grpTests.Enabled = false;
					btnConnect.Enabled = true;
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
				catch (Exception ex) { MessageBox.Show(this, ex.ToString(), "Issue Connecting To ActiLife", MessageBoxButtons.OK, MessageBoxIcon.Error); }
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
				catch (Exception ex) { MessageBox.Show(this, ex.ToString(), "Issue Sending Request", MessageBoxButtons.OK, MessageBoxIcon.Error); return; }

                //determine if response was successful
			    try
			    {
                    JObject j = JsonConvert.DeserializeObject<JObject>(response);
                    JToken jtoken;
                    if (j.TryGetValue("Success", StringComparison.CurrentCultureIgnoreCase, out jtoken))
                    {
                        bool successful = false;
                        try { successful = (bool)jtoken; }
                        catch { }
                        lblResponseStatus.Text = successful ? "Successfully Sent" : "Unuccessfully Sent";
                    }
			    }
			    catch (Exception ex)
			    {
                    MessageBox.Show(this, ex.ToString(), "Issue Parsing Request", MessageBoxButtons.OK, MessageBoxIcon.Error); return;
			    }
			    

			    txtResponse.AppendText("RESPONSE: \r\n" + GetPrettyPrintedJson(response));
				txtResponse.SelectionStart = txtResponse.TextLength - 1;
			};

            #region response right click menu
            
            var contextMenuStrip = new ContextMenuStrip();
            var clearLogMenu = new ToolStripMenuItem { Text = "&Clear Log" };
            var saveLogMenu = new ToolStripMenuItem { Text = "&Save Log to File..." };
            clearLogMenu.Click += (obj, sender) => txtResponse.Clear();
            saveLogMenu.Click += (obj, sender) =>
            {
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "TXT Files (*.txt)|*.txt";
				    saveFileDialog.Title = "Save to a text File";
                    var result = saveFileDialog.ShowDialog();
                    if (result != DialogResult.OK)
                        return;

                    using (StreamWriter s = new StreamWriter(saveFileDialog.FileName))
                        s.Write(txtResponse.Text);

                    Process.Start(saveFileDialog.FileName);
                }
            };
            contextMenuStrip.Items.AddRange(new ToolStripItem[] { clearLogMenu, saveLogMenu });
            
            txtResponse.ContextMenuStrip = contextMenuStrip;
            txtResponse.MouseUp += (o, e) =>
            {
                if (e.Button == MouseButtons.Right)
                    contextMenuStrip.Show(txtResponse, new Point(e.X, e.Y));
            };
            
            #endregion response right click menu

			this.HandleCreated += (o, e) => { FillAPITests(); btnConnect.Focus(); };
			btnPopulateTest.Click += (o, e) => PopulateAPITestSelected();
		}

		ActiLifeAPILibrary.ActiLifeAPIConnection _api;

		public void SetAPI(ActiLifeAPILibrary.ActiLifeAPIConnection api)
		{
			_api = api;
		}

		public string GetPrettyPrintedJson(string json)
		{
			dynamic parsedJson = JsonConvert.DeserializeObject(json);
			return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
		}


		#region "Unit Tests"

		void FillAPITests()
		{
			comboBox1.FormattingEnabled = true;
			comboBox1.Format += (s, args) =>
			{
				if (args.DesiredType != typeof(string)) return;

				args.Value = args.Value.GetType().Name;
			};

			foreach (var tests in (from t in System.Reflection.Assembly.GetExecutingAssembly().GetTypes()
								   where t.GetInterfaces().Contains(typeof(Tests.IApiTest))
										&& t.GetConstructor(Type.EmptyTypes) != null && t.IsClass && !t.IsAbstract
								   select Activator.CreateInstance(t) as Tests.IApiTest))
				comboBox1.Items.Add(tests);

			if (comboBox1.Items.Count != 0)
				comboBox1.SelectedIndex = 0;
		}

		void PopulateAPITestSelected()
		{
			if (comboBox1.Items.Count == 0) return;
			if (comboBox1.SelectedItem == null) return;

			Tests.IApiTest test = comboBox1.SelectedItem as Tests.IApiTest;
			if (test == null) return;

			txtRequest.Text = test.GetJSON();
			txtRequest.Focus();
		}

		#endregion "Unit Tests"

		/// <summary>
		/// Allows the TextBox to handle CTRL+Backspace (delete word), CTRL+Enter (send command), CTRL-A (select all text)
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
                case Keys.F5:
					e.SuppressKeyPress = true;
					btnSend.PerformClick();
					break;
                case (Keys.Control | Keys.A):
			        e.SuppressKeyPress = true;
                    TextBox txtBox = (TextBox)sender;
                    txtBox.SelectAll();
			        break;
			}
		}
	}
}
