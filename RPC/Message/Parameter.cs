using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPCMaster.Message
{
    public class Parameter
    {
        private Type type;
        private Object value;

        public Parameter(Object value)
        {
            this.type = value.GetType();
            this.value = value;
        }

        public Type ParameterType
        {
            get { return this.type; }
        }

        public Object Value
        {
            get { return this.value; }
        }
    }
}
