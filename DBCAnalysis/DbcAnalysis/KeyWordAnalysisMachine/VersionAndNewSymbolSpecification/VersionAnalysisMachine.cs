using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.VersionAndNewSymbolSpecification
{
    public class VersionAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.VersionAndNewSymbolSpecification.VersionAnalysisMachine";

        private Models.DbcContent.VersionAndNewSymbolSpecification.Version _version;

        #region IAnalysisMachine接口函数
        public override bool AnalysisExecute(string line)
        {
            /***
             * 1.先创建关键字对象、映射关系表
             * 2.解析子关键字内容到关系映射表中
             * */
            this._version = new Models.DbcContent.VersionAndNewSymbolSpecification.Version();

            // 获取candbVersionString子字符串，并去除首尾空字符。但是如果字符为空则 直接返回。
            int subLineStartIndex = line.IndexOf('"');
            int subLineStartLength = line.LastIndexOf('"') - subLineStartIndex - 1;
            if(subLineStartLength == 0)
            {
                return true;
            }
            string candbVersionString = line.Substring(subLineStartIndex, subLineStartLength);
            candbVersionString =  base.removeBlankStringFromStartAndEnd(candbVersionString);
            string[] candbVersionStringArray = candbVersionString.Split(' ');

            this._version.GetSubKeyWordListMap().Add(Models.DbcContent.VersionAndNewSymbolSpecification.Version.VERSION_CANDB_VERSION_STRING
                , candbVersionStringArray);


            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._version;
        }

        public override string GetClassFullName()
        {
            return VersionAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return Models.DbcContent.VersionAndNewSymbolSpecification.Version.KEY_WORD;
        }
        #endregion

    }
}
