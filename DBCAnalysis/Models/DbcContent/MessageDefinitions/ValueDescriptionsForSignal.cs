using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.MessageDefinitions
{
    /// <summary>
    /// 结构为：'VAL_' message_id signal_name { value_description } ';'
    /// 描述：信号值描述定义特定信号原始值的编码
    /// </summary>
    public class ValueDescriptionsForSignal : BaseKeyModelOpe
    {
        /// <summary>
        /// ValueDescriptionsForSignal的关键字
        /// </summary>
        public const string KEY_WORD = "VAL_";

        /// <summary>
        /// message_id字段，该字段表示帧ID。出现一次
        /// </summary>
        public const string MESSAGE_ID = "message_id";

        /// <summary>
        /// signal_name字段，该字段表示信号名。出现一次
        /// </summary>
        public const string SIGNAL_NAME = "signal_name";

        /// <summary>
        /// value_description字段，该字段为值描述信息。出现零次或多次
        /// </summary>
        public const string VALUE_DESCRIPTION = "value_description";

        public override string GetKeyWord()
        {
            return ValueDescriptionsForSignal.KEY_WORD;
        }
    }
}
