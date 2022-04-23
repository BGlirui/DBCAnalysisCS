using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.SignalTypeAndSignalGroupDefinitions
{
    /// <summary>
    /// 结构：'SGTYPE_' message_id signal_name ':' signal_type_name ';'。
    /// 描述：信号类型参考
    /// </summary>
    public class SignalTypeRef : BaseKeyModelOpe
    {
        /// <summary>
        /// SignalTypeRef的关键字
        /// </summary>
        public const string KEY_WORD = "SGTYPE_";

        /// <summary>
        /// message_id字段，该字段为报文id。
        /// </summary>
        public const string MESSAGE_ID = "message_id";

        /// <summary>
        /// signal_name字段，该字段为信号名称。
        /// </summary>
        public const string SIGNAL_NAME = "signal_name";

        /// <summary>
        /// signal_type_name字段，该字段为信号类型名称。
        /// </summary>
        public const string SIGNAL_TYPE_NAME = "signal_type_name";

        public override string GetKeyWord()
        {
            return SignalTypeRef.KEY_WORD;
        }
    }
}
