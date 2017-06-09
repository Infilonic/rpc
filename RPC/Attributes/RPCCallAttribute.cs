using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RPCCallAttribute : Attribute
    {
        private string function;

        public RPCCallAttribute()
        {
        }

        public string Function
        {
            get { return this.function; }
            set { this.function = value; }
        }
    }
}
