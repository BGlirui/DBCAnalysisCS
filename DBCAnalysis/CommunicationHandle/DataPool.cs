using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.CommunicationHandle
{
    class DataPool
    {
        private Dictionary<string,UInt64> signalValueMap = new Dictionary<string, ulong>();

        public Dictionary<string,UInt64> SignalValueMap
        {
            get { return signalValueMap; }
            set { signalValueMap = value; }
        }

        private Dictionary<uint,byte[]> messageData = new Dictionary<uint, byte[]>();

        public Dictionary<uint,byte[]> MessageData
        {
            get { return messageData; }
            set { messageData = value; }
        }
        

    }
}
