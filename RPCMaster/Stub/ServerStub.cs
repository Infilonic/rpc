﻿using System;
using System.Collections.Generic;
using System.Reflection;
using RPCMaster.Message;
using RPCMaster.Attributes;

namespace RPCMaster.Stub {
	public class ServerStub {
		private static List<MethodInfo> _methodList = SetMethodList();

		private static List<MethodInfo> SetMethodList() {
			List<MethodInfo> returnVal = new List<MethodInfo>();
			foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies()) {
				Type[] typeArray = a.GetTypes();
				foreach (Type t in typeArray) {
					foreach (MethodInfo mInfo in t.GetMethods()) {
						if (mInfo.GetCustomAttributes(typeof(RPCCallAttribute), true).Length > 0) {
							returnVal.Add(mInfo);
						}
					}
				}
			}
			return returnVal;
		}

		public static string GetResponse(CallMessage message) {
			string returnVal = String.Empty;
			object ret;
			ResponseMessage rM;
			foreach (MethodInfo mI in _methodList) {
				if ((mI.DeclaringType.FullName + "." + mI.Name) == message.FullQualifiedFunctionName) {
					ret = mI.Invoke(null, message.GetVariableArray());
					rM = new ResponseMessage(message.FullQualifiedFunctionName, new List<Variable>() { new Variable(ret) });
				}
			}
			
			return returnVal;
		}
	}
}
