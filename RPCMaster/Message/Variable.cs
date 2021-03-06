﻿/* This class represents a parameter for a methodcall or a returnvalue
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

using System;
using System.Xml.Serialization;
using System.Xml;

namespace RPCMaster.Message
{
    [XmlType("Variable")]
    public class Variable
    {
        [XmlElement("Type")]
        public string Type;
        [XmlElement("Value")]
        public object Value;

        public Variable() { }

        public Variable(Object value) {
            this.Type = value != null ? value.GetType().ToString() : "NULL";
            this.Value = value;
        }
    }
}
