using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.MessageDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions
{
    public class SignalExtendedValueTypeListAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions.SignalExtendedValueTypeListAnalysisMachine";

        private SignalExtendedValueTypeList _signalExtendedValueTypeList;
        public override bool AnalysisExecute(string line)
        {
            this._signalExtendedValueTypeList = new SignalExtendedValueTypeList();

            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 去掉关键字信息
            subLine = line.Replace(SignalExtendedValueTypeList.KEY_WORD, "");
            // 去掉首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            // 获取MessageId信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._signalExtendedValueTypeList.GetSubKeyWordListMap().Add(ValueDescriptionsForSignal.MESSAGE_ID
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });

            // 获取SignalName信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._signalExtendedValueTypeList.GetSubKeyWordListMap().Add(ValueDescriptionsForSignal.SIGNAL_NAME
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });

            // 获取SignalExtendedValueType信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(';', subLineStartIndex) - subLineStartIndex;
            this._signalExtendedValueTypeList.GetSubKeyWordListMap().Add(ValueDescriptionsForSignal.VALUE_DESCRIPTION
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._signalExtendedValueTypeList;
        }

        public override string GetClassFullName()
        {
            return SignalExtendedValueTypeListAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return SignalExtendedValueTypeList.KEY_WORD;
        }
    }
}
