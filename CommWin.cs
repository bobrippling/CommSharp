using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Comm
{
	public partial class CommWin : Form
	{
		const short PORT = 5678;

		enum State
		{
			IDLE, CONNECTING, LISTENING, CONNECTED
		};

		private State _state;
		private State state
		{
			get { return _state; }
			set {
				_state = value;
				UpdateCtrls();
			}
		}

		SocketWrap _wrap;
		Protocol _proto;

		public CommWin()
		{
			InitializeComponent();

			_state = State.IDLE;
			_wrap = new SocketWrap(Connected, Accepted, Received, Disconnected, Error);
			_proto = new Protocol(ReceivedMessage);

			UpdateCtrls();
			this.Show();
		}

		private delegate void UIUpdateMethod();

		void UIUpdate(UIUpdateMethod d)
		{
			// idiotic
			if(InvokeRequired)
				this.Invoke(new MethodInvoker(d));
			else
				d();
		}

		void UpdateCtrls()
		{
			UIUpdate(delegate {
				txtIn.Enabled      = _state == State.CONNECTED;
				btnConnect.Enabled = _state == State.IDLE;
				btnListen.Enabled  = _state == State.IDLE;
				btnDiscon.Enabled  = _state != State.IDLE;
			});
		}

		void AddText(string txt, params object[] args)
		{
			UIUpdate(delegate {
				rtfMain.SelectionStart = rtfMain.TextLength;
				rtfMain.SelectedText = string.Format(txt, args) + '\n';
			});
		}

		void Error(Exception e)
		{
			AddText("Error: {0}", e.ToString());
			state = State.IDLE;
		}

		void Disconnected()
		{
			AddText("Disconnected");
			state = State.IDLE;
		}

		void Accepted()
		{
			AddText("Accepted Connection from {0}", _wrap.RemoteAddr);
			state = State.CONNECTED;
		}

		void Connected()
		{
			AddText("Connected to {0}", _wrap.RemoteAddr);
			state = State.CONNECTED;
		}

		void Received(string data)
		{
			_proto.HandleData(data);
		}

		void ReceivedMessage(string msg)
		{
			AddText("Recv: {0}", msg);
		}

		private void txtIn_KeyPress(object sender, KeyPressEventArgs e)
		{
			char ch = e.KeyChar;
			if(ch == '\n' || ch == '\r') {
				e.Handled = true;

				string txt = txtIn.Text;
				if(txt.Length == 0)
					return;

				_proto.SendMessage(txt, _wrap);
				
				AddText("Sent: " + txt);
				txtIn.Text = "";
			}
		}

		private void btnListen_Click(object sender, EventArgs e)
		{
			_wrap.Listen(PORT);
			
			AddText("Listening...");
			state = State.LISTENING;
		}

		private void btnDiscon_Click(object sender, EventArgs e)
		{
			_wrap.Disconnect();
			
			AddText("Connection Closed");
			state = State.IDLE;
		}

		private void btnConnect_Click(object sender, EventArgs e)
		{
			string addr = Prompt.ShowDialog("Yo", "IP Address", "Connect");
			AddText("Connecting to {0}...", addr);

			_wrap.Connect(addr, PORT);
			state = State.CONNECTING;
		}
	}

	static class Prompt
	{
		public static string ShowDialog(string text, string caption, string action)
		{
			Form window = new Form() { Width = 200, Height = 150, Text = caption };
			Label label = new Label() { Dock = DockStyle.Top, Text = text };
			TextBox textBox = new TextBox() { Dock = DockStyle.Bottom };
			Button go = new Button() { Dock = DockStyle.Right };
			go.Click += (sender, e) => { window.Close(); };

			window.Controls.Add(go);
			window.Controls.Add(label);
			window.Controls.Add(textBox);

			window.ShowDialog();

			return textBox.Text;
		}
	}
}
