using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace RPCMaster.Runtime
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
