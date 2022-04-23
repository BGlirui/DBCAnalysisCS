using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.ValueTableDefinitions
{
    /// <summary>
    /// ValueTable部分定义了全局值表。值表中的值描述定义了信号原始值的值编码。
    /// 在常用的DBC文件中，不使用全局值表，但值描述是为每个信号独立定义的
    /// </summary>
    public class ValueTable : BaseKeyModelOpe
    {
        /// <summary>
        /// ValueTable的关键字
        /// </summary>
        public const string KEY_WORD = "VAL_TABLE_";
        /// <summary>
        /// value_table_name字段，该字段出现一次
        /// </summary>
        public const string VALUE_TABLE_NAME = "value_table_name";
        /// <summary>
        /// value_description字段,数据类型为double char_string，该字段出现零次或多次.值描述定义单个值的文本描述。这个值可以是总线上传输的信号原始值，也可以是剩余总线模拟中的环境变量的值。
        /// </summary>
        public const string VALUE_DESCRIPTION = "value_description";

        public override string GetKeyWord()
        {
            return ValueTable.KEY_WORD;
        }
    }
}
