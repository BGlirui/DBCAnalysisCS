using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.SignalTypeAndSignalGroupDefinitions
{
    /// <summary>
    /// 结构：'SIG_GROUP_' message_id signal_group_name repetitions ':' { signal_name } ';'
    /// 描述：信号组用于定义一个消息中的一组信号，例如，定义一组信号必须共同更新。
    /// </summary>
    public class SignalGroups : BaseKeyModelOpe
    {
        /// <summary>
        /// SignalGroups的关键字
        /// </summary>
        public const string KEY_WORD = "SIG_GROUP_";

        /// <summary>
        /// message_id字段，该字段描述了报文的ID。
        /// </summary>
        public const string MESSAGE_ID = "message_id";

        /// <summary>
        /// signal_group_name字段，类型为C_identifier，该字段描述了信号组名称。
        /// </summary>
        public const string SIGNAL_GROUP_NAME = "signal_group_name";

        /// <summary>
        /// repetitions字段，类型为unsigned_integer，该字段描述了重复次数。
        /// </summary>
        public const string REPETITIONS = "repetitions";

        /// <summary>
        /// signal_name字段，该字段描述了信号名。
        /// </summary>
        public const string SIGNAL_NAME = "signal_name";

        public override string GetKeyWord()
        {
            return SignalGroups.KEY_WORD;
        }
    }
}
