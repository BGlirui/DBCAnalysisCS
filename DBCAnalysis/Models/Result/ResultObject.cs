using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.BitTimingDefinition;
using DBCAnalysis.Models.DbcContent.CommentDefinitions;
using DBCAnalysis.Models.DbcContent.EnvironmentVariableDefinitions;
using DBCAnalysis.Models.DbcContent.MessageDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.Result
{
    /// <summary>
    /// 将DBC文本信息解析后的结果对象
    /// </summary>
    class ResultObject
    {
        private Dictionary<string, List<BaseKeyModelOpe>> baseKeyModelOpeMap = new Dictionary<string, List<BaseKeyModelOpe>>();
        /// <summary>
        /// 解析器名称和结果集的映射关系
        /// </summary>
        public Dictionary<string,List<BaseKeyModelOpe>> BaseKeyModelOpeMap
        {
            get { return baseKeyModelOpeMap; }
            set { baseKeyModelOpeMap = value; }
        }
    }
}
