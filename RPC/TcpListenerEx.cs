/* This class just wraps the TcpListener, so the protected "Active" property can be used for logical operations outside the namespace and inheritance tree
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
using System.Net;
using System.Net.Sockets;

namespace RPCMaster
{
    public class TcpListenerEx : TcpListener
    {
        public TcpListenerEx(IPAddress localAddress, int port) : base(localAddress, port)
        {

        }

        public new bool Active
        {
            get { return base.Active; }
        }
    }
}
