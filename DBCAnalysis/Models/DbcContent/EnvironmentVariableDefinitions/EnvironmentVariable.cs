using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.EnvironmentVariableDefinitions
{
    /// <summary>
    /// 结构为：'EV_' env_var_name ':' env_var_type '[' minimum '|' maximum ']' unit initial_value ev_id access_type access_node {',' access_node } ';'
    /// 描述：在环境变量部分中定义了在系统仿真和其他总线仿真工具中使用的环境变量。
    /// </summary>
    public class EnvironmentVariable : BaseKeyModelOpe
    {
        /// <summary>
        /// EnvironmentVariable的关键字
        /// </summary>
        public const string KEY_WORD = "EV_";
        /// <summary>
        /// env_var_name字段，类型为：C_identifier，表示环境变量名，出现一次
        /// </summary>
        public const string ENV_VAR_NAME = "env_var_name";

        /// <summary>
        /// env_var_type字段，值为：'0' | '1' | '2'，其中0=integer, 1=float, 2=string，表示环境变量名，出现一次
        /// </summary>
        public const string ENV_VAR_TYPE = "env_var_type";

        /// <summary>
        /// minimum字段，类型为double，表示该环境变量的最小值，出现一次
        /// </summary>
        public const string MINIMUM = "minimum";

        /// <summary>
        /// maximum字段，类型为double，表示该环境变量的最大值，出现一次
        /// </summary>
        public const string MAXIMUM = "maximum";

        /// <summary>
        /// unit字段，表示单位。出现一次
        /// </summary>
        public const string UNIT = "unit";

        /// <summary>
        /// initial_value字段，类型为double，表示初始值，出现一次
        /// </summary>
        public const string INITIAL_VALUE = "initial_value";

        /// <summary>
        /// ev_id字段，类型为unsigned_integer，表示环境变量ID，出现一次。
        /// </summary>
        public const string EV_ID = "ev_id";

        /// <summary>
        /// access_type字段，值为'DUMMY_NODE_VECTOR0' | 'DUMMY_NODE_VECTOR1' | 'DUMMY_NODE_VECTOR2' | 'DUMMY_NODE_VECTOR3'，其中0=unrestricted, 1=read, 2=write, 3=readWrite 
        /// </summary>
        public const string ACCESS_TYPE = "access_type";

        /// <summary>
        /// access_node字段，值为node_name | 'VECTOR_XXX'，出现一次或多次。
        /// </summary>
        public const string ACCESS_NODE = "access_node";

        public override string GetKeyWord()
        {
            return EnvironmentVariable.KEY_WORD;
        }
    }
}
