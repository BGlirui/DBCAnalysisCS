using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.SignalTypeAndSignalGroupDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.SignalTypeAndSignalGroupDefinitions
{
    public class SignalTypeRefAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.SignalTypeAndSignalGroupDefinitions.SignalTypeRefAnalysisMachine";

        private SignalTypeRef _signalTypeRef;
        public override bool AnalysisExecute(string line)
        {
            this._signalTypeRef = new SignalTypeRef();

            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;

            // 去除关键字
            subLine = line.Replace(SignalTypeRef.KEY_WORD, "");
            // 去除首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);

            // 获取MessageId信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._signalTypeRef.GetSubKeyWordListMap().Add(SignalTypeRef.MESSAGE_ID
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取SignalName信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(':', subLineStartIndex) - subLineStartIndex;
            this._signalTypeRef.GetSubKeyWordListMap().Add(SignalTypeRef.SIGNAL_NAME
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取SignalTypeName信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(';', subLineStartIndex) - subLineStartIndex;
            this._signalTypeRef.GetSubKeyWordListMap().Add(SignalTypeRef.SIGNAL_TYPE_NAME
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._signalTypeRef;
        }

        public override string GetClassFullName()
        {
            return SignalTypeRefAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return SignalTypeRef.KEY_WORD;
        }
    }
}
