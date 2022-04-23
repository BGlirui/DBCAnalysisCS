using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis
{
    class KeyWords
    {
        public const string VERSION = "VERSION "; //版本
        public const string NEW_SYMBOLS = "_NS ";//新符号
        public const string BIT_TIMING = "BS_"; //波特率定义，但是通常为空（通常不适用）
        public const string NETWORK_NODE = "BU_"; //网络节点*
        public const string VALUE_TABLE_DEFINITIONS = "VAL_TABLE"; //值表定义，（通常不使用）
        public const string MESSAGE_DEFINITIONS = "BO_"; //报文帧*
        public const string SIGNAL_DEFINITIONS = "SG_"; // 信号*
        public const string ENVIRONMENT_VARIABLE = "EV_"; // 环境变量,主要用于仿真（通常不使用）
        public const string SIGNAL_TYPE = "SGTYPE"; // 信号类型（通常不使用）
        public const string COMMENT_DEFINITIONS = "CM_";// 注解定义，可以对BU_(节点)、BO_(报文帧)、SG_(信号)、EV_(环境变量)*
        public const string ATTRIBUTE_DEFINITIONS = "BA_DEF_"; // 属性定义，可以定义BU_(节点)、BO_(报文帧)、SG_(信号)、EV_(环境变量)*
        public const string ATTRIBUTE_DEFAULT = "BA_DEF_DEF_"; // 属性值定义*
        public const string ATTRIBUTE_VALUE = "BA_";
    }
}
