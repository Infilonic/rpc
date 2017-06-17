using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using System.Xml;

namespace RPCMaster.Message
{
    [XmlType("Parameter")]
    public class Parameter
    {
        [XmlElement("Type")]
        public string Type;
        [XmlElement("Value")]
        public object Value;

        public Parameter() { }

        public Parameter(Object value)
        {
            this.Type = value.GetType().ToString();
            this.Value = value;
        }
    }
}
