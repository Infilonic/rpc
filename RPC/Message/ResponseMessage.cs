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
    [XmlRoot("Response")]
    public class ResponseMessage : IProcedureMessage<ResponseMessage>
    {
        [XmlElement("Function")]
        private string Function;
        [XmlArray("ReturnTupel")]
        [XmlArrayItem("ReturnValue")]
        private List<Parameter> ReturnValues;

        public ResponseMessage() { }

        public ResponseMessage(string function, List<Parameter> returnValues)
        {
            this.Function = function;
            this.ReturnValues = returnValues;
        }

        public string Serialize()
        {
            string serializedObject;
            XmlSerializer serializer = new XmlSerializer(typeof(ResponseMessage));
            using (StringWriter sWriter = new StringWriter())
            {
                serializer.Serialize(sWriter, this);
                serializedObject = sWriter.ToString();
            }
            return serializedObject;
        }

        public static ResponseMessage Deserialize(string serializedObject)
        {
            ResponseMessage deserializedObject;
            XmlSerializer serializer = new XmlSerializer(typeof(ResponseMessage));
            using (StringReader sReader = new StringReader(serializedObject))
            {
                deserializedObject = (ResponseMessage)serializer.Deserialize(sReader);
            }
            return deserializedObject;
        }
    }
}
