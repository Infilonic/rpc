/* This class is used as the top layer of the RPC. It handles connections and gives the messages to the according stub to interprete
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;

namespace RPCMaster
{
    public class Runtime
    {
		protected Socket _socket;
		protected IPAddress _ipAddress;
		protected IPEndPoint _localEndPoint;
		protected int _port;

		public Runtime(IPAddress ipAddress, int port) {
			this._ipAddress = ipAddress;
			this._port = port;
			this._localEndPoint = new IPEndPoint(this._ipAddress, this._port);
			this._socket = new Socket(this._ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
		}
	}
}
