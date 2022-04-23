using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.ValueTableDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.ValueTableDefinitions
{
    public class ValueTableAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.ValueTableDefinitions.ValueTableAnalysisMachine";

        private ValueTable _valueTable;

        public override bool AnalysisExecute(string line)
        {
            this._valueTable = new ValueTable();

            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 去除关键字
            subLine = line.Replace(ValueTable.KEY_WORD, "");
            // 去除首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            // 获取value_table_name子关键字内容
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ',subLineStartIndex) - subLineStartIndex;
            this._valueTable.GetSubKeyWordListMap().Add(ValueTable.VALUE_TABLE_NAME, new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取value_description子关键字内容
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(';',subLineStartIndex) - subLineStartIndex ;
            subLine = subLine.Substring(subLineStartIndex,subLineStartLength);
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            this._valueTable.GetSubKeyWordListMap().Add(ValueTable.VALUE_DESCRIPTION, subLine.Split(' '));

            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._valueTable;
        }

        public override string GetClassFullName()
        {
            return ValueTableAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return ValueTable.KEY_WORD;
        }
    }
}
