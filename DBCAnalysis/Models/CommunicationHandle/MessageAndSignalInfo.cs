using DBCAnalysis.Models.DbcContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.CommunicationHandle
{
    class MessageAndSignalInfo
    {
        public uint MessageId { get; set; }

        public BaseKeyModelOpe MessageModel { get; set; }

        public List<BaseKeyModelOpe> SignalModelList { get; set; }
    }
}
