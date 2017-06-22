using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace RPCMaster.Message {
	public abstract class AbstractMessage : IProcedureMessage<AbstractMessage> {

		public AbstractMessage() { }
		public virtual string Serialize() {
			string serializedObject;
			XmlSerializer serializer = new XmlSerializer(typeof(AbstractMessage));
			using (StringWriter sWriter = new StringWriter()) {
				serializer.Serialize(sWriter, this);
				serializedObject = sWriter.ToString();
			}
			return serializedObject;
		}

		public static AbstractMessage Deserialize(string serializedObject) {
			AbstractMessage deserializedObject;
			XmlSerializer serializer = new XmlSerializer(typeof(AbstractMessage));
			using (StringReader sReader = new StringReader(serializedObject)) {
				deserializedObject = (AbstractMessage) serializer.Deserialize(sReader);
			}
			return deserializedObject;
		}
	}
}
