using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.MessageDefinitions
{
    /// <summary>
    /// Message部分定义了集群中所有帧的名称以及它们的属性和帧上传输的信号.结构为：BO_ message_id message_name ':' message_size transmitter {signal} ;
    /// </summary>
    public class Message : BaseKeyModelOpe
    {
        /// <summary>
        /// Message的关键字
        /// </summary>
        public const string KEY_WORD = "BO_";

        /// <summary>
        /// message_id字段，类型为unsigned_integer，出现一次.
        /// 消息的CAN-ID。在DBC文件中，CAN-ID必须是唯一的。如果设置了CAN-ID的最高有效位，则该ID为扩展CAN ID。扩展的CAN ID可以通过用掩码0xCFFFFFFF屏蔽最高有效位来确定
        /// </summary>
        public const string MESSAGE_ID = "message_id";

        /// <summary>
        /// uint类型的信息字符串。
        /// </summary>
        public const string MESSAGE_ID_UINT = "message_id_uint";

        /// <summary>
        /// 扩展帧标志。
        /// </summary>
        public const string MESSAGE_ID_EXTEND_FLAG = "message_id_extend_flag";

        /// <summary>
        /// message_name字段，类型为C_identifier ，出现一次.
        /// 在本部分中定义的名称，在消息集合中必须是唯一的
        /// </summary>
        public const string MESSAGE_NAME = "message_name";

        /// <summary>
        /// message_size字段，类型为unsigned_integer，出现一次.
        /// message_size以字节为单位指定消息的大小.
        /// </summary>
        public const string MESSAGE_SIZE = "message_size";

        /// <summary>
        /// transmitter字段，出现一次.
        /// 发射器名称指定发送消息的节点名称。发送方名称必须在节点部分的节点名称集中定义。如果该信息没有发送者，则必须在这里给出字符串'Vector__XXX'
        /// </summary>
        public const string TRANSMITTER = "transmitter";

        /// <summary>
        /// signal字段，出现零次或多次，具体信息可参考Signal类
        /// </summary>
        public const string SIGNAL = "signal";

        public override string GetKeyWord()
        {
            return Message.KEY_WORD;
        }
    }
}
