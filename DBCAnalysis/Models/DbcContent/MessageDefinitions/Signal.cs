using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.MessageDefinitions
{
    /// <summary>
    /// 消息的信号部分列出了放置在消息上的所有信号、它们在消息数据字段中的位置及其属性。
    /// 结构为：signal = 'SG_' signal_name multiplexer_indicator ':' start_bit '|'
    ///                  signal_size '@' byte_order value_type '(' factor ',' offset ')'
    ///                  '[' minimum '|' maximum ']' unit receiver {',' receiver };
    /// </summary>
    public class Signal : BaseKeyModelOpe
    {
        /// <summary>
        /// Signal的关键字
        /// </summary>
        public const string KEY_WORD = "SG_";

        /// <summary>
        /// 信号所属消息的MessageId
        /// </summary>
        public const string MESSAGE_ID = "message_id";
        /// <summary>
        /// signal_name字段，类型为C_identifier，出现一次。
        /// 这里定义的名称对于单个消息的信号必须是唯一的。
        /// </summary>
        public const string SIGNAL_NAME = "signal_name";

        /// <summary>
        /// multiplexer_indicator字段，结构为' ' | 'M' | m multiplexer_switch_value，出现一次。
        /// 多路复用指示器定义信号是正常信号、多路复用信号的多路开关还是多路复用信号。
        /// 一个'M'(大写)字符将信号定义为多路开关。在一个消息中只有一个信号可以是多路开关。
        /// 后跟无符号整数的'm'(小写)字符将信号定义为被多路复用开关复用。如果多路复用信号的开关值等于它的multiplex_switch_value，则多路复用信号在消息中被传输
        /// </summary>
        public const string MULTIPLEXER_INDICATOR = "multiplexer_indicator";

        /// <summary>
        /// start_bit字段，类型为unsigned_integer，出现一次。
        /// start_bit值指定了信号在帧的数据字段中的位置。
        /// 对于具有字节顺序因特尔(小端序)的信号，给出了最低有效位的位置。
        /// 对于字节顺序为Motorola(大端序)的信号，给出了最高有效位的位置。
        /// 比特以锯齿的方式计数。开始位必须在0到(8 * message_size - 1)的范围内。
        /// </summary>
        public const string START_BIT = "start_bit";

        /// <summary>
        /// signal_size字段，类型为unsigned_integer，出现一次。
        /// signal_size以比特为单位指定信号的大小。
        /// </summary>
        public const string SIGNAL_SIZE = "signal_size";

        /// <summary>
        /// byte_order字段，结构为'0' | '1' ; (* 0=little endian, 1=big endian *)，出现一次。
        /// 如果信号的字节顺序是Intel(小端序)，则byte_format为0;如果信号的字节顺序是Motorola(大端序)，则byte_format为1。
        /// </summary>
        public const string BYTE_ORDER = "byte_order";

        /// <summary>
        /// value_type字段，结构为'+' | '-' ; (* +=unsigned, -=signed *)，出现一次。
        /// value_type将信号定义为unsigned(-)或signed(-)类型。
        /// </summary>
        public const string VALUE_TYPE = "value_type";

        /// <summary>
        /// factor字段，类型为double，出现一次。
        /// 定义了因子。
        /// </summary>
        public const string FACTOR = "factor";

        /// <summary>
        /// offset字段，类型为double，出现一次。
        /// 定义了偏移量。
        /// </summary>
        public const string OFFSET = "offset";

        /// <summary>
        /// minimum字段，类型为double，出现一次。
        /// 有效物理值的最小值
        /// </summary>
        public const string MINIMUM = "minimum";

        /// <summary>
        /// maximum字段，类型为double，出现一次。
        /// 有效物理值的最大值
        /// </summary>
        public const string MAXIMUM = "maximum";

        /// <summary>
        /// unit字段，类型为char_string，出现一次。
        /// 物理量单位的标识。
        /// </summary>
        public const string UNIT = "unit";

        /// <summary>
        /// receiver字段，结构为node_name | 'Vector__XXX'，出现一次或多次。
        /// 接收器名称指定信号的接收器。必须在节点部分的节点名称集合中定义接收方名称。如果信号没有接收器，则必须在这里给出字符串'Vector__XXX'。
        /// </summary>
        public const string RECEIVER = "receiver";

        public override string GetKeyWord()
        {
            return Signal.KEY_WORD;
        }
    }
}
