using System;
using RPCMaster.Message;

namespace RPCMaster.Stub
{
    public class ClientStub
    {
        private static Client runtime;

        public static void StartRuntime(string host, int port) {
            runtime = new Client(host, port);
        }
        public static ResponseMessage InvokeRemoteMethod(CallMessage message) {
            try {
                string response = String.Empty;
                runtime.StartSending(message.Serialize(), out response);
                return ResponseMessage.Deserialize(response);
            }
            catch (Exception e) {
                return new ResponseMessage(e.ToString(), null);
            }
        }
    }
}
