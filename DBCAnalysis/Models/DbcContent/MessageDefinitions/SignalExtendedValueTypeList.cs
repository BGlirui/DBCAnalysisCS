using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.MessageDefinitions
{
    /// <summary>
    /// 值类型为'float'和'double'的信号在signal_valtype_list部分有额外的条目。结构为：'SIG_VALTYPE_' message_id signal_name signal_extended_value_type ';' 
    /// </summary>
    class SignalExtendedValueTypeList : BaseKeyModelOpe
    {
        /// <summary>
        /// SignalExtendedValueTypeList的关键字
        /// </summary>
        public const string KEY_WORD = "SIG_VALTYPE_";

        /// <summary>
        /// message_id字段，该字段表示报文ID，出现一次
        /// </summary>
        public const string MESSAGE_ID = "message_id";

        /// <summary>
        /// signal_name字段，该字段表示信号名，出现一次
        /// </summary>
        public const string SIGNAL_NAME = "signal_name";

        /// <summary>
        /// signal_extended_value_type字段，该字段内容为'0' | '1' | '2' | '3'，
        /// 其中0=signed or unsigned integer, 1=32-bit IEEE-float, 2=64-bit IEEE-double，
        /// 出现一次
        /// </summary>
        public const string SIGNAL_EXTENDED_VALUE_TYPE = "signal_extended_value_type";

        public override string GetKeyWord()
        {
            return SignalExtendedValueTypeList.KEY_WORD;
        }
    }
}
