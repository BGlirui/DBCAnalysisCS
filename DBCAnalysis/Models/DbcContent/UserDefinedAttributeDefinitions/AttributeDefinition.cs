using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.UserDefinedAttributeDefinitions
{
    /// <summary>
    /// 结构为：'BA_DEF_' object_type attribute_name attribute_value_type ';' 
    /// 描述：用户定义的属性是扩展DBC文件的对象属性的一种方法。
    ///       必须使用带有属性默认值的属性定义来定义这些附加属性。
    ///       对于每个为属性定义了值的对象，必须定义一个属性值条目。
    ///       如果没有为对象定义属性值条目，则该对象的属性值为该属性的默认值。
    /// </summary>
    public class AttributeDefinition : BaseKeyModelOpe
    {
        /// <summary>
        /// AttributeDefinition的关键字
        /// </summary>
        public const string KEY_WORD = "BA_DEF_";

        /// <summary>
        /// object_type字段，结构为'' | 'BU_' | 'BO_' | 'SG_' | 'EV_'，描述了关键字信息。
        /// </summary>
        public const string OBJECT_TYPE = "object_type";

        /// <summary>
        /// attribute_name字段，结构为'"' C_identifier '"' ，描述了属性名。
        /// </summary>
        public const string ATTRIBUTE_NAME = "attribute_name";

        /// <summary>
        /// attribute_value_type字段，结构为'INT' signed_integer signed_integer |
        ///                                 'HEX' signed_integer signed_integer |
        ///                                 'FLOAT' double double |
        ///                                 'STRING' |
        ///                                 'ENUM' [char_string {',' char_string}]，该字段描述了属性值类型。
        /// </summary>
        public const string ATTRIBUTE_VALUE_TYPE = "attribute_value_type";

        public override string GetKeyWord()
        {
            return AttributeDefinition.KEY_WORD;
        }
    }
}
