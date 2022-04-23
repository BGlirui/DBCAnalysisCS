using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.Result;

namespace DBCAnalysis.DbcAnalysis
{
    public interface IDbcAnalysis
    {
        /// <summary>
        /// 对行信息列表进行解析，并返回结果对象
        /// </summary>
        /// <param name="lineMessageList">包含DBC文本信息的行信息列表</param>
        /// <returns>解析结果</returns>
        bool DbcMessageAnalysisToResultObject(string dbcPath, List<string> lineMessageList);
    }
}
