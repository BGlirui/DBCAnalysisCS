using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.EnvironmentVariableDefinitions
{
    /// <summary>
    /// 结构为：'VAL_' env_var_aname { value_description } ';'
    /// 描述：环境变量的值描述提供了变量特定值的文本表示。
    /// </summary>
    public class ValueDescriptionsForEnvVar : BaseKeyModelOpe
    {
        /// <summary>
        /// ValueDescriptionsForEnvVar的关键字
        /// </summary>
        public const string KEY_WORD = "VAL_";

        /// <summary>
        /// env_var_aname字段，该字段表示环境变量名。
        /// </summary>
        public const string ENV_VAR_ANAME = "env_var_aname";

        /// <summary>
        /// value_description字段，该字段表示值描述信息。
        /// </summary>
        public const string VALUE_DESCRIPTION = "value_description";

        public override string GetKeyWord()
        {
            return ValueDescriptionsForEnvVar.KEY_WORD;
        }
    }
}
