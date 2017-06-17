using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RPCMaster.Message
{
    [XmlRoot("Call")]
    public class CallMessage : IProcedureMessage<CallMessage>
    {
        [XmlElement("Function")]
        public string Function;
        [XmlArray("Parameters")]
        [XmlArrayItem("Parameter")]
        public List<Parameter> Parameters;

        public CallMessage() { }

        public CallMessage(string function, List<Parameter> parameters)
        {
            this.Function = function;
            this.Parameters = parameters;
        }

        public string Serialize()
        {
            string serializedObject;
            XmlSerializer serializer = new XmlSerializer(typeof(CallMessage));
            using(StringWriter sWriter =  new StringWriter())
            {
                serializer.Serialize(sWriter, this);
                serializedObject = sWriter.ToString();
            }
            return serializedObject;
        }

        public static CallMessage Deserialize(string serializedObject)
        {
            CallMessage deserializedObject;
            XmlSerializer serializer = new XmlSerializer(typeof(CallMessage));
            using(StringReader sReader = new StringReader(serializedObject))
            {
                deserializedObject = (CallMessage)serializer.Deserialize(sReader);
            }
            return deserializedObject;
        }
    }
}
