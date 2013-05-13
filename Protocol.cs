using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Comm
{
	class Protocol
	{
		public delegate void ReceiveMessage(string msg);

		private ReceiveMessage _rmsg;

		public Protocol(ReceiveMessage rmsg)
		{
			_rmsg = rmsg;
		}

		public void HandleData(string data)
		{
			switch(data[0]){
				case 'M':
					_rmsg(data.Substring(1));
					break;
				default:
					Console.WriteLine("Received unknown message type {0}", data[0]);
					break;
			}
		}

		public void SendMessage(string msg, SocketWrap sw)
		{
			sw.SendData('M' + msg);
		}
	}
}
