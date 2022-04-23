using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.UserDefinedAttributeDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.UserDefinedAttributeDefinitions
{
    public class AttributeDefaultAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.UserDefinedAttributeDefinitions.AttributeDefaultAnalysisMachine";

        private AttributeDefault _attributeDefault;
        public override bool AnalysisExecute(string line)
        {
            this._attributeDefault = new AttributeDefault();

            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 去除关键字信息
            subLine = line.Replace(AttributeDefault.KEY_WORD,"");
            // 去除首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);

            // 获取attribute_name信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._attributeDefault.GetSubKeyWordListMap().Add(AttributeDefault.ATTRIBUTE_NAME
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });

            // 获取attribute_value信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(';', subLineStartIndex) - subLineStartIndex;
            this._attributeDefault.GetSubKeyWordListMap().Add(AttributeDefault.ATTRIBUTE_VALUE
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._attributeDefault;
        }

        public override string GetClassFullName()
        {
            return AttributeDefaultAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return AttributeDefault.KEY_WORD;
        }
    }
}
