using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace RPCMaster {
	public class StateObject
	{
		public Socket workSocket = null;
		public const int BufferSize = 1024;
		public byte[] buffer = new byte[BufferSize];
		public StringBuilder sb = new StringBuilder();
	}

	public class Server : Runtime
	{
		public Server() : this(IPAddress.Any.ToString()) { }

		public Server(string host) : this(host, 27900) { }

		public Server(string host, int port) : this(IPAddress.Parse(host), port) { }

		public Server(IPAddress ipAddress, int port) : base(ipAddress, port) {
			try {
				base._socket.Bind(base._localEndPoint);
			} catch (Exception e) {
				Console.WriteLine("Unexpected exception: {0}", e.ToString());
			}
		}

		public void StartListening() {
			Console.WriteLine("Local address and port: {0}", base._localEndPoint.ToString());

			base._socket.Listen(100);
			Console.WriteLine("Listening...");
			Socket handler = base._socket.Accept();
			String data = null;
			byte[] buffer = null;

			while (true) {
				buffer = new byte[1024];
				int bytesReceived = handler.Receive(buffer);
				data += Encoding.ASCII.GetString(buffer, 0, bytesReceived);
				if (data.IndexOf("<EOF>") > -1) {
					break;
				}
			}

			Console.WriteLine("Message received: {0}", data);
			handler.Send(Encoding.ASCII.GetBytes("OK"));
			handler.Shutdown(SocketShutdown.Both);
			handler.Close();
		}

		private void AcceptCallback(IAsyncResult ar) {
			//
		}


	}
}
