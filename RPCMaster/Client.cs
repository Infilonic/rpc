using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace RPCMaster {
	public class Client : Runtime {
		public Client() : this(IPAddress.Any.ToString()) { }

		public Client(string host) : this(host, 27900) { }

		public Client(string host, int port) : this(IPAddress.Parse(host), port) { }

		public Client(IPAddress ipAddress, int port) : base(ipAddress, port) { }

		public static void StartSending() {
			Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
		}
	}
}
