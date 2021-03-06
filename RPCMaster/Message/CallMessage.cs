﻿/* This class represents a call for the receiver to run
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

using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace RPCMaster.Message
{
    [XmlRoot("Call")]
    public class CallMessage : AbstractMessage<CallMessage>
    {
        [XmlElement("Function")]
        public string FullQualifiedFunctionName;
        [XmlArray("Parameters")]
        [XmlArrayItem("Parameter")]
        public List<Variable> Parameters;

        public CallMessage() { }

        public CallMessage(string fullQualifiedFunctionName, List<Variable> parameters) {
            this.FullQualifiedFunctionName = fullQualifiedFunctionName;
            this.Parameters = parameters != null ? parameters : new List<Variable>();
        }

        public override object[] GetVariableArray() {
            object[] paramArray = new object[this.Parameters.Count];
            int i = 0;
            foreach (Variable v in this.Parameters) {
                paramArray[i] = v.Value;
                i++;
            }
            return paramArray;
        }
    }
}
