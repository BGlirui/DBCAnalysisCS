using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.UserDefinedAttributeDefinitions
{
    /// <summary>
    /// 结构：'BA_DEF_DEF_' attribute_name attribute_value ';'
    /// 描述：属性定义
    /// </summary>
    public class AttributeDefault : BaseKeyModelOpe
    {
        /// <summary>
        /// AttributeDefault的关键字
        /// </summary>
        public const string KEY_WORD = "BA_DEF_DEF_";

        /// <summary>
        /// attribute_name字段，该字段定义了属性名。
        /// </summary>
        public const string ATTRIBUTE_NAME = "attribute_name";

        /// <summary>
        /// attribute_value字段，值类型为unsigned_integer | signed_integer | double | char_string，
        /// 该字段定义了属性的值。
        /// </summary>
        public const string ATTRIBUTE_VALUE = "attribute_value";

        public override string GetKeyWord()
        {
            return AttributeDefault.KEY_WORD;
        }
    }
}
