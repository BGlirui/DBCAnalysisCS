using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine
{
    public interface IAnalysisMachine
    {
        /// <summary>
        /// 执行解析过程并返回DBC基本关键字对象
        /// </summary>
        /// <returns></returns>
        bool AnalysisExecute(string line);
        BaseKeyModelOpe GetBaseKeyModelOpe();
        /// <summary>
        /// 获取关键字信息
        /// </summary>
        /// <returns></returns>
        string GetKeyWord();

        string GetClassFullName();
    }
}
