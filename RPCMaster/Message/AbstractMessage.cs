

using System.IO;
using System.Xml.Serialization;

namespace RPCMaster.Message {
	public abstract class AbstractMessage<T> : IProcedureMessage<T> {

		public AbstractMessage() { }
		public virtual string Serialize() {
			string serializedObject;
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			using (StringWriter sWriter = new StringWriter()) {
				serializer.Serialize(sWriter, this);
				serializedObject = sWriter.ToString();
			}
			return serializedObject;
		}

		public static T Deserialize(string serializedObject) {
			T deserializedObject;
			XmlSerializer serializer = new XmlSerializer(typeof(T));
			using (StringReader sReader = new StringReader(serializedObject)) {
				deserializedObject = (T) serializer.Deserialize(sReader);
			}
			return deserializedObject;
		}
	}
}
