using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.UserDefinedAttributeDefinitions
{
    /// <summary>
    /// 结构：'BA_' attribute_name (attribute_value |
    ///                             'BU_' node_name attribute_value |
    ///                             'BO_' message_id attribute_value |
    ///                             'SG_' message_id signal_name attribute_value |
    ///                             'EV_' env_var_name attribute_value)
    ///       ';' 
    /// </summary>
    public class AttributeValueForObject : BaseKeyModelOpe
    {
        /// <summary>
        /// AttributeValueForObject的关键字
        /// </summary>
        public const string KEY_WORD = "BA_";

        /// <summary>
        /// attribute_name字段，该字段描述了属性名。
        /// </summary>
        public const string ATTRIBUTE_NAME = "attribute_name";

        /// <summary>
        /// attribute_value字段，该字段为属性值。
        /// </summary>
        public const string ATTRIBUTE_VALUE = "attribute_value";

        /// <summary>
        /// sub_key_word字段，该字段为子关键字。
        /// </summary>
        public const string SUB_KEY_WORD = "sub_key_word";

        /// <summary>
        /// node_name字段，该字段为节点名。
        /// </summary>
        public const string NODE_NAME = "node_name";

        /// <summary>
        /// message_id字段，该字段为报文ID。
        /// </summary>
        public const string MESSAGE_ID = "message_id";

        /// <summary>
        /// signal_name字段，该字段为信号名。
        /// </summary>
        public const string SIGNAL_NAME = "signal_name";

        /// <summary>
        /// env_var_name字段，该字段为环境变量名。
        /// </summary>
        public const string ENV_VAR_NAME = "env_var_name";

        public override string GetKeyWord()
        {
            return AttributeValueForObject.KEY_WORD;
        }
    }
}
