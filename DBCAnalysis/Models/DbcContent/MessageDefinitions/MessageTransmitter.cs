using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.MessageDefinitions
{
    /// <summary>
    /// 结构为：'BO_TX_BU_' message_id ':' {transmitter} ';'。
    /// 描述：消息发送器部分允许定义单个节点的多个发送器节点。这是用来描述高层协议的通信数据。这不是用来定义CAN第二层通信的
    /// </summary>
    public class MessageTransmitter : BaseKeyModelOpe
    {
        /// <summary>
        /// MessageTransmitter的关键字
        /// </summary>
        public const string KEY_WORD = "BO_TX_BU_";

        /// <summary>
        /// message_id字段，该字段表示帧ID，出现一次
        /// </summary>
        public const string MESSAGE_ID = "message_id";

        /// <summary>
        /// transmitter字段，该字段表示发送节点，出现零次或多次。
        /// </summary>
        public const string TRANSMITTER = "transmitter";

        public override string GetKeyWord()
        {
            return MessageTransmitter.KEY_WORD;
        }
    }
}
