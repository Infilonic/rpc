using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPC.Attributes;

namespace RPCClient
{
    class Application
    {
        public static void Main()
        {

        }

        [RPCCall(Function = "test")]
        public void test()
        {

        }
    }
}
