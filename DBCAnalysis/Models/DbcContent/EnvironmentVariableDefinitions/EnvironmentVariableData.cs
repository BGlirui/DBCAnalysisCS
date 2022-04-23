using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.EnvironmentVariableDefinitions
{
    /// <summary>
    /// 结构为：'ENVVAR_DATA_' env_var_name ':' data_size ';' 
    /// 描述：环境变量数据部分中的条目将这里列出的环境定义为数据类型“data”。这种类型的环境变量可以存储给定长度的任意二进制数据。长度以字节为单位。
    /// </summary>
    public class EnvironmentVariableData : BaseKeyModelOpe
    {
        /// <summary>
        /// EnvironmentVariableData的关键字
        /// </summary>
        public const string KEY_WORD = "ENVVAR_DATA_";

        /// <summary>
        /// env_var_name字段，该字段表示环境变量名，出现一次。
        /// </summary>
        public const string ENV_VAR_NAME = "env_var_name";

        /// <summary>
        /// data_size字段，类型为unsigned_integer，该字段表示数据长度，出现一次。
        /// </summary>
        public const string DATA_SIZE = "data_size";

        public override string GetKeyWord()
        {
            return EnvironmentVariableData.KEY_WORD;
        }
    }
}
