/* This abstract class is the base for every message sent from server to client and vice versa
 * Copyright(C) 2017  Infilonic

 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.

 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
 * GNU General Public License for more details.

 * You should have received a copy of the GNU General Public License
 * along with this program.If not, see<http://www.gnu.org/licenses/>
 */

using System.IO;
using System.Xml.Serialization;

namespace RPCMaster.Message
{
    public abstract class AbstractMessage<T> : IProcedureMessage<T>
    {

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
                deserializedObject = (T)serializer.Deserialize(sReader);
            }
            return deserializedObject;
        }

        public abstract object[] GetVariableArray();
    }
}
