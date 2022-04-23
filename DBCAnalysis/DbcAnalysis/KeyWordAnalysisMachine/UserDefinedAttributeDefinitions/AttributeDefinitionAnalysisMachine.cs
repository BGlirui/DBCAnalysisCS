using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.UserDefinedAttributeDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.UserDefinedAttributeDefinitions
{
    public class AttributeDefinitionAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.UserDefinedAttributeDefinitions.AttributeDefinitionAnalysisMachine";

        private AttributeDefinition _attributeDefinition;
        private HashSet<string> _subKeyWordHashSet = new HashSet<string>() { "BU_", "BO_", "SG_", "EV_" };
        
        public override bool AnalysisExecute(string line)
        {
            this._attributeDefinition = new AttributeDefinition();

            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 去掉关键字信息
            subLine = line.Replace(AttributeDefinition.KEY_WORD, "");
            // 去掉首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            // 获取objectType信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            string objectType = subLine.Substring(subLineStartIndex, subLineStartLength);
            if(this._subKeyWordHashSet.Contains(objectType))
            {
                this._attributeDefinition.GetSubKeyWordListMap().Add(AttributeDefinition.OBJECT_TYPE
                , new string[] { objectType });
            }
            else
            {
                subLineStartLength = -1;
            }
            // 获取attribute_name信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._attributeDefinition.GetSubKeyWordListMap().Add(AttributeDefinition.ATTRIBUTE_NAME
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });

            // 获取attribute_value_type信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(';', subLineStartIndex) - subLineStartIndex;
            subLine = base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength));
            analysisAttributeValueType(subLine);
            return true;
        }

        private void analysisAttributeValueType(string line)
        {
            string subLine = line;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            string[] attributeValueTypeArray = null;
            // 获取AttributeValueType子关键字
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            string subKeyWord = null;
            if (subLineStartLength < 1)
            {
                subKeyWord = base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex));
            }
            else
            {
                subKeyWord = subLine.Substring(subLineStartIndex, subLineStartLength);
            }
            switch(subKeyWord)
            {
                case "INT":
                    attributeValueTypeArray = new string[3];
                    attributeValueTypeArray[0] = subKeyWord;

                    subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
                    subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
                    attributeValueTypeArray[1] = subLine.Substring(subLineStartIndex, subLineStartLength);

                    subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
                    attributeValueTypeArray[2] = base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex));
                    break;
                case "HEX":
                    attributeValueTypeArray = new string[3];
                    attributeValueTypeArray[0] = subKeyWord;

                    subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
                    subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
                    attributeValueTypeArray[1] = subLine.Substring(subLineStartIndex, subLineStartLength);

                    subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
                    attributeValueTypeArray[2] = base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex));
                    break;
                case "FLOAT":
                    attributeValueTypeArray = new string[3];
                    attributeValueTypeArray[0] = subKeyWord;

                    subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
                    subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
                    attributeValueTypeArray[1] = subLine.Substring(subLineStartIndex, subLineStartLength);

                    subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
                    attributeValueTypeArray[2] = base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex));
                    break;
                case "STRING":
                    attributeValueTypeArray = new string[1];
                    attributeValueTypeArray[0] = subKeyWord;
                    break;
                case "ENUM":
                    subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
                    subLine = base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex));
                    string[] charStringArray = subLine.Split(',');
                    attributeValueTypeArray = new string[charStringArray.Length + 1];
                    attributeValueTypeArray[0] = subKeyWord;
                    for(int i =0;i<charStringArray.Length;i++)
                    {
                        attributeValueTypeArray[i + 1] = charStringArray[i];
                    }
                    break;
            }
            if(attributeValueTypeArray != null)
            {
                this._attributeDefinition.GetSubKeyWordListMap().Add(AttributeDefinition.ATTRIBUTE_VALUE_TYPE
                , attributeValueTypeArray);
            }
            
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._attributeDefinition;
        }

        public override string GetKeyWord()
        {
            return AttributeDefinition.KEY_WORD;
        }

        public override string GetClassFullName()
        {
            return AttributeDefinitionAnalysisMachine.CLASS_FULL_NAME;
        }
    }
}
