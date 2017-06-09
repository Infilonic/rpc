using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPC.Message
{
    public class ResponseMessage : IProcedureMessage
    {
        private string function;
        private List<Parameter> returnValues;

        public ResponseMessage(string function, List<Parameter> returnValues)
        {
            this.function = function;
            this.returnValues = returnValues;
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
