using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC.MasterMessage
{
    public class CallMessage : IProcedureMessage
    {
        private string function;
        private List<Parameter> parameters;

        public CallMessage(string function, List<Parameter> parameters)
        {
            this.function = function;
            this.parameters = parameters;
        }

        public string Serialize()
        {
            throw new NotImplementedException();
        }

        public IProcedureMessage Deserialize()
        {
            throw new NotImplementedException();
        }
    }
}
