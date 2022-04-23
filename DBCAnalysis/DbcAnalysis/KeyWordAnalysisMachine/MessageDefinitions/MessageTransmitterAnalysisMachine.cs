using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.MessageDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions
{
    public class MessageTransmitterAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions.MessageTransmitterAnalysisMachine";

        private MessageTransmitter _messageTransmitter;
        public override bool AnalysisExecute(string line)
        {
            this._messageTransmitter = new MessageTransmitter();

            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 删除关键字
            subLine = line.Replace(MessageTransmitter.KEY_WORD,"");
            // 清除首尾关键字
            subLine = base.removeBlankStringFromStartAndEnd(subLine);

            // 获取MessageId信息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(':',subLineStartIndex) - subLineStartIndex ;
            this._messageTransmitter.GetSubKeyWordListMap().Add(MessageTransmitter.MESSAGE_ID
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取Transmitter信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(';', subLineStartIndex) - subLineStartIndex;
            subLine = base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength));
            this._messageTransmitter.GetSubKeyWordListMap().Add(MessageTransmitter.TRANSMITTER
                , subLine.Split(' '));

            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._messageTransmitter;
        }

        public override string GetClassFullName()
        {
            return MessageTransmitterAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return MessageTransmitter.KEY_WORD;
        }
    }
}
