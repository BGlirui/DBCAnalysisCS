using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.VersionAndNewSymbolSpecification
{
    /// <summary>
    /// 通过CANdb editor编辑器可以将Version设置为空或String类型参数.格式模板为：['VERSION' '"' { CANdb_version_string } '"' ]
    /// </summary>
    class Version : BaseKeyModelOpe
    {
        
        /// <summary>
        /// Version的关键字
        /// </summary>
        public const string KEY_WORD = "VERSION";
        /// <summary>
        /// CANdb_version_string字段，该字段可以出现零次或多次
        /// </summary>
        public const string VERSION_CANDB_VERSION_STRING = "CANdb_version_string";

        public override string GetKeyWord()
        {
            return Version.KEY_WORD;
        }
    }
}
