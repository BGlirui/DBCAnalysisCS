using DBCAnalysis.Models.DbcContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine
{
    public abstract class AnalysisMachine : IAnalysisMachine, INullKeyWordAnalysis
    {
        /// <summary>
        /// 执行解析过程并返回DBC基本关键字对象
        /// </summary>
        /// <returns></returns>
        public abstract bool AnalysisExecute(string line);

        public abstract string GetKeyWord();

        public abstract BaseKeyModelOpe GetBaseKeyModelOpe();

        public abstract string GetClassFullName();

        protected string removeBlankStringFromStartAndEnd(string line)
        {
            return line.Trim();
        }

        protected string removeBlankStringFromStart(string line)
        {
            return line.TrimStart();
        }

        protected string removeBlankStringFromEnd(string line)
        {
            return line.TrimEnd();
        }

        public bool HaveSubNullKeyWordString()
        {
            return false;
        }

        public bool NullKeyWordAnalysis(string line)
        {
            return false;
        }
    }
}
