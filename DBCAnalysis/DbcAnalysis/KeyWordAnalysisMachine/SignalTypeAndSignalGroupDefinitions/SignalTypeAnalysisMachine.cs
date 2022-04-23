using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.SignalTypeAndSignalGroupDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.SignalTypeAndSignalGroupDefinitions
{
    public class SignalTypeAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.SignalTypeAndSignalGroupDefinitions.SignalTypeAnalysisMachine";

        private SignalType _signalType;
        public override bool AnalysisExecute(string line)
        {
            this._signalType = new SignalType();

            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 清除关键字信息
            subLine = line.Replace(SignalType.KEY_WORD, "");
            // 去除首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            // 获取SignalTypeName信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(':', subLineStartIndex) - subLineStartIndex;
            this._signalType.GetSubKeyWordListMap().Add(SignalType.SIGNAL_TYPE_NAME
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });
            // 获取SignalSize信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf('@', subLineStartIndex) - subLineStartIndex;
            this._signalType.GetSubKeyWordListMap().Add(SignalType.SIGNAL_SIZE
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取ByteOrder信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLine = subLine.Substring(subLineStartIndex);
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._signalType.GetSubKeyWordListMap().Add(SignalType.BYTE_ORDER
                ,new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取ValueType信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf('(', subLineStartIndex) - subLineStartIndex;
            this._signalType.GetSubKeyWordListMap().Add(SignalType.VALUE_TYPE
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取Factor信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(',', subLineStartIndex) - subLineStartIndex;
            this._signalType.GetSubKeyWordListMap().Add(SignalType.FACTOR
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取OffSet信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(')', subLineStartIndex) - subLineStartIndex;
            this._signalType.GetSubKeyWordListMap().Add(SignalType.OFFSET
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取Minimum信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartIndex = subLine.IndexOf('[', subLineStartIndex) + 1;
            subLineStartLength = subLine.IndexOf('|', subLineStartIndex) - subLineStartIndex;
            this._signalType.GetSubKeyWordListMap().Add(SignalType.MINIMUM
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取Maximum信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(']', subLineStartIndex) - subLineStartIndex;
            this._signalType.GetSubKeyWordListMap().Add(SignalType.MAXIMUM
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取Unit信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLine = subLine.Substring(subLineStartIndex);
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._signalType.GetSubKeyWordListMap().Add(SignalType.UNIT
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取DefaultValue信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(',', subLineStartIndex) - subLineStartIndex;
            this._signalType.GetSubKeyWordListMap().Add(SignalType.DEFAULT_VALUE
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取ValueTable信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(';', subLineStartIndex) - subLineStartIndex;
            this._signalType.GetSubKeyWordListMap().Add(SignalType.VALUE_TABLE
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });
            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._signalType;
        }

        public override string GetClassFullName()
        {
            return SignalTypeAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return SignalType.KEY_WORD;
        }
    }
}
