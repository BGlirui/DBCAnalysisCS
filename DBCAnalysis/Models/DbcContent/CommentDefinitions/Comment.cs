using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.CommentDefinitions
{
    /// <summary>
    /// 结构为：'CM_' (char_string |
    ///         'BU_' node_name char_string |
    ///         'BO_' message_id char_string |
    ///         'SG_' message_id signal_name char_string |
    ///         'EV_' env_var_name char_string)
    ///         ';' 
    /// </summary>
    public class Comment : BaseKeyModelOpe
    {
        /// <summary>
        /// Comment的关键字
        /// </summary>
        public const string KEY_WORD = "CM_";

        /// <summary>
        /// char_string字段，该字段为描述信息。
        /// </summary>
        public const string CHAR_STRING = "char_string";

        /// <summary>
        /// sub_key_word字段，值为BU_ | BO_ | SG_ | EV_，该字段为标识子关键字。
        /// </summary>
        public const string SUB_KEY_WORD = "sub_key_word";

        /// <summary>
        /// node_name字段，该字段描述了节点名
        /// </summary>
        public const string NODE_NAME = "node_name";

        /// <summary>
        /// message_id字段，该字段描述了报文ID。
        /// </summary>
        public const string MESSAGE_ID = "message_id";

        /// <summary>
        /// signal_name字段，该字段藐视了信号名。
        /// </summary>
        public const string SIGNAL_NAME = "signal_name";

        /// <summary>
        /// env_var_name字段，该字段描述了环境变量名。
        /// </summary>
        public const string ENV_VAR_NAME = "env_var_name";

        public override string GetKeyWord()
        {
            return Comment.KEY_WORD;
        }
    }
}
