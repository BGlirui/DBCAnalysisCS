using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Core.BeanManage;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.EnvironmentVariableDefinitions;
using DBCAnalysis.Result;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.EnvironmentVariableDefinitions
{
    public class ValueDescriptionsForEnvVarAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.EnvironmentVariableDefinitions.ValueDescriptionsForEnvVarAnalysisMachine";

        private ValueDescriptionsForEnvVar _valueDescriptionsForEnvVar;
        private ResultObjectOpe _resultObjectOpe;
        private DbcAnalysisMachinePoolOpe _dbcAnalysisMachinePool;

        public ValueDescriptionsForEnvVarAnalysisMachine()
        {
            this._resultObjectOpe = BeanOpe.GetBeanOpe().GetObject<ResultObjectOpe>();
            this._dbcAnalysisMachinePool = BeanOpe.GetBeanOpe().GetObject<DbcAnalysisMachinePoolOpe>();
        }
        public override bool AnalysisExecute(string line)
        {
            this._valueDescriptionsForEnvVar = new ValueDescriptionsForEnvVar();

            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 去除关键字
            subLine = line.Replace(ValueDescriptionsForEnvVar.KEY_WORD, "");
            // 去除首尾关键字
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            // 获取EnvVarName信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            string envVarName = subLine.Substring(subLineStartIndex, subLineStartLength);

            // 判断是否符合本解析器的条件
            if(!this.judgeAnalysisMachine(envVarName))
            {
                return false;
            }

            // 添加EnvVarName信息
            this._valueDescriptionsForEnvVar.GetSubKeyWordListMap().Add(ValueDescriptionsForEnvVar.ENV_VAR_ANAME
                , new string[] { envVarName});
            // 获取ValueDescription信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(';', subLineStartIndex) - subLineStartIndex;
            subLine = subLine.Substring(subLineStartIndex, subLineStartLength);
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            this._valueDescriptionsForEnvVar.GetSubKeyWordListMap().Add(ValueDescriptionsForEnvVar.VALUE_DESCRIPTION
                , subLine.Split(' '));

            return true;
        }

        private bool judgeAnalysisMachine(string envVarName)
        {
            /***
             * 判断条件为，查看关键字后的第一个字段是否为EnvVarName
             * */
            if (this._resultObjectOpe == null)
            {
                return false;
            }
            if (this._dbcAnalysisMachinePool == null)
            {
                return false;
            }
            Dictionary<string,AnalysisMachine> analysisMachines = this._dbcAnalysisMachinePool.GetAnalysisMachine(EnvironmentVariable.KEY_WORD);
            if (analysisMachines == null)
            {
                return false;
            }
            if (analysisMachines.Count < 1)
            {
                return false;
            }
            List<BaseKeyModelOpe> baseKeyModelOpes = this._resultObjectOpe
                .GetCurrentBaseKeyModelOpesByClassFullName(analysisMachines.Last().Value.GetClassFullName());
            foreach (BaseKeyModelOpe temp in baseKeyModelOpes)
            {
                if (!temp.GetSubKeyWordListMap().ContainsKey(EnvironmentVariable.ENV_VAR_NAME))
                {
                    return false;
                }
                if (envVarName.Equals(temp.GetSubKeyWordListMap()[EnvironmentVariable.ENV_VAR_NAME][0]))
                {
                    return true;
                }
            }
            return false;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._valueDescriptionsForEnvVar;
        }

        public override string GetClassFullName()
        {
            return ValueDescriptionsForEnvVarAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return ValueDescriptionsForEnvVar.KEY_WORD;
        }
    }
}
