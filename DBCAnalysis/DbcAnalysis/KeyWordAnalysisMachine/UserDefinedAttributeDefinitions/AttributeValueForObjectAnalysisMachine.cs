using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.EnvironmentVariableDefinitions;
using DBCAnalysis.Models.DbcContent.MessageDefinitions;
using DBCAnalysis.Models.DbcContent.NodeDefinitions;
using DBCAnalysis.Models.DbcContent.UserDefinedAttributeDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.UserDefinedAttributeDefinitions
{
    public class AttributeValueForObjectAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.UserDefinedAttributeDefinitions.AttributeValueForObjectAnalysisMachine";

        private AttributeValueForObject _attributeValueForObject;
        private HashSet<string> _subKeyWordHashSet = new HashSet<string>() { "BU_", "BO_", "SG_", "EV_" };
        public override bool AnalysisExecute(string line)
        {
            this._attributeValueForObject = new AttributeValueForObject();
            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 去除关键字
            subLine = line.Replace(AttributeValueForObject.KEY_WORD, "");
            // 去除首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            // 获取attribute_name信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._attributeValueForObject.GetSubKeyWordListMap().Add(AttributeValueForObject.ATTRIBUTE_NAME
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });

            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            // 判断是否不在包含子信息
            if(subLineStartLength<0)
            {
                this._attributeValueForObject.GetSubKeyWordListMap().Add(AttributeValueForObject.ATTRIBUTE_VALUE
                    , new string[] { subLine.Substring(subLineStartIndex) });
                return true;
            }
            //获取子关键字，其中包括BU_（Node） | BO_（Message） | SG_（Signal） | EV_（EnvironmentVariable）
            string[] subStr = new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) };
            if (this._subKeyWordHashSet.Contains(subStr[0]))
            {
                this._attributeValueForObject.GetSubKeyWordListMap().Add(AttributeValueForObject.SUB_KEY_WORD
                    , subStr);
                subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
                subLineStartLength = subLine.IndexOf(';', subLineStartIndex) - subLineStartIndex;
                subLine = base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength));
                switch(subStr[0])
                {
                    case Node.KEY_WORD:
                        this.nodeAnalysis(subLine);
                        break;
                    case Message.KEY_WORD:
                        this.messageAnalysis(subLine);
                        break;
                    case Signal.KEY_WORD:
                        this.signalAnalysis(subLine);
                        break;
                    case EnvironmentVariable.KEY_WORD:
                        this.environmentVariable(subLine);
                        break;
                }
            }
            return true;
        }

        private void nodeAnalysis(string line)
        {
            string subLine = line;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 获取NodeName信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._attributeValueForObject.GetSubKeyWordListMap().Add(AttributeValueForObject.NODE_NAME
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取CharString信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            this._attributeValueForObject.GetSubKeyWordListMap().Add(AttributeValueForObject.ATTRIBUTE_VALUE
                , new string[] { subLine.Substring(subLineStartIndex) });
        }

        private void messageAnalysis(string line)
        {
            string subLine = line;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 获取MessageId信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._attributeValueForObject.GetSubKeyWordListMap().Add(AttributeValueForObject.MESSAGE_ID
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取CharString信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            this._attributeValueForObject.GetSubKeyWordListMap().Add(AttributeValueForObject.ATTRIBUTE_VALUE
                , new string[] { subLine.Substring(subLineStartIndex) });
        }

        private void signalAnalysis(string line)
        {
            string subLine = line;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 获取MessageId信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._attributeValueForObject.GetSubKeyWordListMap().Add(AttributeValueForObject.MESSAGE_ID
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取SignalName信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._attributeValueForObject.GetSubKeyWordListMap().Add(AttributeValueForObject.SIGNAL_NAME
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取CharString信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            this._attributeValueForObject.GetSubKeyWordListMap().Add(AttributeValueForObject.ATTRIBUTE_VALUE
                , new string[] { subLine.Substring(subLineStartIndex) });
        }

        private void environmentVariable(string line)
        {
            string subLine = line;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 获取EnvVarName信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._attributeValueForObject.GetSubKeyWordListMap().Add(AttributeValueForObject.ENV_VAR_NAME
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取CharString信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            this._attributeValueForObject.GetSubKeyWordListMap().Add(AttributeValueForObject.ATTRIBUTE_VALUE
                , new string[] { subLine.Substring(subLineStartIndex) });
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._attributeValueForObject;
        }

        public override string GetKeyWord()
        {
            return AttributeValueForObject.KEY_WORD;
        }

        public override string GetClassFullName()
        {
            return AttributeValueForObjectAnalysisMachine.CLASS_FULL_NAME;
        }
    }
}
