using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.EnvironmentVariableDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.EnvironmentVariableDefinitions
{
    public class EnvironmentVariableDataAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.EnvironmentVariableDefinitions.EnvironmentVariableDataAnalysisMachine";

        private EnvironmentVariableData _environmentVariableData;

        public override bool AnalysisExecute(string line)
        {
            this._environmentVariableData = new EnvironmentVariableData();
            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 去除关键字
            subLine = line.Replace(EnvironmentVariableData.KEY_WORD, "");
            // 去除首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            // 获取EnvVarName信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(':', subLineStartIndex) - subLineStartIndex;
            this._environmentVariableData.GetSubKeyWordListMap().Add(EnvironmentVariableData.ENV_VAR_NAME
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });
            // 获取DataSize信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(';', subLineStartIndex) - subLineStartIndex;
            this._environmentVariableData.GetSubKeyWordListMap().Add(EnvironmentVariableData.DATA_SIZE
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._environmentVariableData;
        }

        public override string GetClassFullName()
        {
            return EnvironmentVariableDataAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return EnvironmentVariableData.KEY_WORD;
        }
    }
}
