using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.SignalTypeAndSignalGroupDefinitions
{
    /// <summary>
    /// 结构为：'SGTYPE_' signal_type_name ':' signal_size '@' byte_order value_type '(' factor ',' offset ')' '[' minimum '|' maximum ']' unit default_value ',' value_table ';' 
    /// 描述：信号类型用于定义多个信号的公共属性。它们通常不在DBC文件中使用
    /// </summary>
    public class SignalType : BaseKeyModelOpe
    {
        /// <summary>
        /// SignalType的关键字
        /// </summary>
        public const string KEY_WORD = "SGTYPE_";

        /// <summary>
        /// signal_type_name字段，类型为C_identifier，该字段表示信号类型名称。
        /// </summary>
        public const string SIGNAL_TYPE_NAME = "signal_type_name";

        /// <summary>
        /// signal_size字段，该字段为信号尺寸
        /// </summary>
        public const string SIGNAL_SIZE = "signal_size";

        /// <summary>
        /// byte_order字段，值为'0' | '1' ，该字段表示信号的大小端。
        /// </summary>
        public const string BYTE_ORDER = "byte_order";

        /// <summary>
        /// value_type字段，该字段表示值类型。
        /// </summary>
        public const string VALUE_TYPE = "value_type";

        /// <summary>
        /// factor字段，该字段表示信号的因数。
        /// </summary>
        public const string FACTOR = "factor";

        /// <summary>
        /// offset字段，该字段表示信号的偏移量。
        /// </summary>
        public const string OFFSET = "offset";

        /// <summary>
        /// minimum字段，该字段表示信号的最小值。
        /// </summary>
        public const string MINIMUM = "minimum";

        /// <summary>
        /// maximum字段，该字段表示信号的最大值。
        /// </summary>
        public const string MAXIMUM = "maximum";

        /// <summary>
        /// unit字段，该字段表示信号的单位。
        /// </summary>
        public const string UNIT = "unit";

        /// <summary>
        /// default_value字段，该字段表示信号的默认值。
        /// </summary>
        public const string DEFAULT_VALUE = "default_value";

        /// <summary>
        /// value_table字段，该字段表示信号的值表。
        /// </summary>
        public const string VALUE_TABLE = "value_table";

        public override string GetKeyWord()
        {
            return SignalType.KEY_WORD;
        }
    }
}
