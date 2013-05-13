using System;
using System.IO;
using System.Net;
using System.Net.Sockets;

namespace Comm
{
	class SocketWrap
	{
		public delegate void ConnectCallback();
		public delegate void ListenCallback();
		public delegate void DisconnectCallback();
		public delegate void ReceiveCallback(string data);
		public delegate void ErrorCallback(Exception errdesc);

		private Socket          _sock, _outSock;
		private ConnectCallback _ccb;
		private ReceiveCallback _rcb;
		private ErrorCallback   _ecb;
		private ListenCallback  _lcb;
		private DisconnectCallback _dcb;
		private byte[]          _recvBuf;

		public SocketWrap(
			ConnectCallback ccb,
			ListenCallback lcb, 
			ReceiveCallback rcb,
			DisconnectCallback dcb,
			ErrorCallback ecb)
		{
			_ccb = ccb;
			_rcb = rcb;
			_ecb = ecb;
			_lcb = lcb;
			_dcb = dcb;
			_recvBuf = new byte[1024];
		}

		public EndPoint RemoteAddr
		{
			get
			{
				return _outSock.RemoteEndPoint;
			}
		}

		void ReceiveData(IAsyncResult iar)
		{
			if(!_outSock.Connected){
				Disconnect();
				return;
			}

			int len;
			try{
				len = _outSock.EndReceive(iar);
			}catch(Exception){
				Disconnect();
				return;
			}
			if(len == 0)
				return;
			
			char[] str = new char[len];
			for(int i = 0; i < len; i++)
				str[i] = (char)_recvBuf[i];

			_rcb(new string(str));

			StartRecv();
		}

		void StartRecv()
		{
			_outSock.BeginReceive(
				_recvBuf, 0, _recvBuf.Length,
				SocketFlags.None,
				ReceiveData,
				null);
		}

		void Connected(IAsyncResult iar)
		{
			try{
				_sock.EndConnect(iar);
				_outSock = _sock;

				StartRecv();

				_ccb();
			}catch(Exception e){
				_ecb(e);
			}
		}

		public void Lookup(string addr, short port, out EndPoint ep, out Socket sock)
		{
			 ep   = new IPEndPoint(Dns.GetHostEntry(addr).AddressList[0], port);
			 sock = new Socket(ep.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
		}

		public void Connect(string addr, short port)
		{
			EndPoint end;
			Lookup(addr, port, out end, out _sock);
			_sock.BeginConnect(end, Connected, null);
		}

		void Accept(IAsyncResult ar)
		{
			if(_sock == null)
				return;
			
			try{
				_outSock = _sock.EndAccept(ar);
			}catch(Exception e){
				_outSock = null;
				if(_sock != null){
					_sock.Close();
					_sock = null;
				}
				_ecb(e);
				return;
			}

			_sock.Close();
			_sock = null;

			StartRecv();
			_lcb();
		}

		public void Listen(short port)
		{
			EndPoint end;

			Lookup("localhost", port, out end, out _sock);

			_sock.Bind(end);
			_sock.Listen(1);
			_sock.BeginAccept(Accept, null);
		}

		public void Disconnect()
		{
			if(_outSock != null){
				_outSock.Disconnect(/*reuse=*/true);
				_outSock.Close();
				_outSock = null;
				_dcb(); // only disconnected in this case
			}else if(_sock != null){
				_sock.Close();
				_sock = null;
			}
		}

		public void SendData(string line)
		{
			char[] chArr = line.ToCharArray();
			int bufLen = chArr.Length;
			byte[] buffer = new byte[bufLen];

			for(int i = 0; i < bufLen; i++)
				buffer[i] = (byte)chArr[i];
			
			_outSock.Send(buffer, 0, bufLen, SocketFlags.None);
		}
	}
}
