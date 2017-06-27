/* This class is used to create a listener for incoming calls
 * Copyright(C) 2017  Infilonic

 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program.If not, see<http://www.gnu.org/licenses/>
 */

using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using RPCMaster.Message;
using RPCMaster.Stub;

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
				base._socket.Bind(base._endPoint);
			} catch (Exception e) {
				Console.WriteLine("Unexpected exception: {0}", e.ToString());
			}
		}

		public void StartListening() {
			Console.WriteLine("Local address and port: {0}", base._endPoint.ToString());

			base._socket.Listen(100);
			Console.WriteLine("Listening...");
			Socket handler;
			String data = null;
			byte[] buffer = null;

			while(true) {
				handler = base._socket.Accept();
				data = null;

				while (true) {
					buffer = new byte[1024];
					int bytesReceived = handler.Receive(buffer);
					data += Encoding.ASCII.GetString(buffer, 0, bytesReceived);
					if (data.IndexOf("\0") > -1) {
						break;
					}
				}

				string responseMessage = ServerStub.GetResponse(CallMessage.Deserialize(data)) + "\0";

				byte[] response = Encoding.ASCII.GetBytes(responseMessage);

				Console.WriteLine("Message received: {0}", data);
				handler.Send(response);
				handler.Shutdown(SocketShutdown.Both);
				handler.Close();
			}
		}
	}
}
