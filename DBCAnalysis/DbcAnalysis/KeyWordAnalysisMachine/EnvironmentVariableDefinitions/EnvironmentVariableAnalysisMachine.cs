using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.EnvironmentVariableDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.EnvironmentVariableDefinitions
{
    public class EnvironmentVariableAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.EnvironmentVariableDefinitions.EnvironmentVariableAnalysisMachine";

        private EnvironmentVariable _environmentVariable;
        public override bool AnalysisExecute(string line)
        {
            this._environmentVariable = new EnvironmentVariable();

            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 清除关键字信息
            subLine = line.Replace(EnvironmentVariable.KEY_WORD, "");
            // 清除首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            // 获取EnvVarName信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(':', subLineStartIndex) - subLineStartIndex;
            this._environmentVariable.GetSubKeyWordListMap().Add(EnvironmentVariable.ENV_VAR_NAME
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取EnvVarType信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf('[', subLineStartIndex) - subLineStartIndex;
            this._environmentVariable.GetSubKeyWordListMap().Add(EnvironmentVariable.ENV_VAR_TYPE
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取Minimum信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf('|', subLineStartIndex) - subLineStartIndex;
            this._environmentVariable.GetSubKeyWordListMap().Add(EnvironmentVariable.MINIMUM
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取Maximum信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(']', subLineStartIndex) - subLineStartIndex;
            this._environmentVariable.GetSubKeyWordListMap().Add(EnvironmentVariable.MAXIMUM
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取Unut信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLine = base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex));
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._environmentVariable.GetSubKeyWordListMap().Add(EnvironmentVariable.UNIT
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            //获取InitialValue信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._environmentVariable.GetSubKeyWordListMap().Add(EnvironmentVariable.INITIAL_VALUE
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取EvId信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._environmentVariable.GetSubKeyWordListMap().Add(EnvironmentVariable.EV_ID
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取AccessType信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._environmentVariable.GetSubKeyWordListMap().Add(EnvironmentVariable.ACCESS_TYPE
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取AccessNode信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(';', subLineStartIndex) - subLineStartIndex;
            subLine = subLine.Substring(subLineStartIndex,subLineStartLength);
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            this._environmentVariable.GetSubKeyWordListMap().Add(EnvironmentVariable.ACCESS_NODE
                , subLine.Split(','));


            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._environmentVariable;
        }

        public override string GetClassFullName()
        {
            return EnvironmentVariableAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return EnvironmentVariable.KEY_WORD;
        }
    }
}
