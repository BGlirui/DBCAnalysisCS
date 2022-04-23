using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Core.BeanManage;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.MessageDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions
{
    public class SignalAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions.SignalAnalysisMachine";

        private Signal _signal;
        private MessageAnalysisMachine _messageAnalysisMachine;

        public SignalAnalysisMachine()
        {
            if(BeanOpe.GetBeanOpe().GetObject<DbcAnalysisMachinePoolOpe>().IsRegistered(Message.KEY_WORD))
            {
                this._messageAnalysisMachine = (MessageAnalysisMachine)BeanOpe.GetBeanOpe().GetObject<DbcAnalysisMachinePoolOpe>().GetAnalysisMachine(Message.KEY_WORD).Last().Value;
            }
        }
        public override bool AnalysisExecute(string line)
        {
            this._signal = new Signal();
            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;

            // 去除关键字
            subLine = line.Replace(Signal.KEY_WORD,"");
            // 去除首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            // 获取SignalName信息
            if(this._messageAnalysisMachine == null)
            {
                return false;
            }
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._messageAnalysisMachine.AddSignalToList(subLine.Substring(subLineStartIndex, subLineStartLength));
            // 获取MessageId
            this._signal.GetSubKeyWordListMap().Add(Signal.MESSAGE_ID
                , new string[] { this._messageAnalysisMachine.GetMessageIdUint() });
            // 获取MultiplexerIndicator信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(':', subLineStartIndex) - subLineStartIndex;
            if(subLineStartLength != 0)
            {
                this._signal.GetSubKeyWordListMap().Add(Signal.MULTIPLEXER_INDICATOR
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });
            }
            // 获取StartBit信息
            subLineStartIndex = subLine.IndexOf(':', subLineStartIndex) + 1;
            subLineStartLength = subLine.IndexOf('|', subLineStartIndex) - subLineStartIndex;
            this._signal.GetSubKeyWordListMap().Add(Signal.START_BIT
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取SignalSize信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf('@', subLineStartIndex) - subLineStartIndex;
            this._signal.GetSubKeyWordListMap().Add(Signal.SIGNAL_SIZE
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取ByteOrder信息和ValueType信息，其中ByteOrder的值为0或1，ValueType的值为+或-
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._signal.GetSubKeyWordListMap().Add(Signal.BYTE_ORDER
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, 1)) });
            subLineStartIndex = subLineStartIndex + 1;
            this._signal.GetSubKeyWordListMap().Add(Signal.VALUE_TYPE
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, 1)) });

            // 获取Factor信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(',', subLineStartIndex) - subLineStartIndex;
            this._signal.GetSubKeyWordListMap().Add(Signal.FACTOR
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取Offset信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(')', subLineStartIndex) - subLineStartIndex;
            this._signal.GetSubKeyWordListMap().Add(Signal.OFFSET
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取Minimum信息
            subLineStartIndex = subLine.IndexOf('[', subLineStartIndex) + 1;
            subLineStartLength = subLine.IndexOf('|', subLineStartIndex) - subLineStartIndex;
            this._signal.GetSubKeyWordListMap().Add(Signal.MINIMUM
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取Maxumum信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(']', subLineStartIndex) - subLineStartIndex;
            this._signal.GetSubKeyWordListMap().Add(Signal.MAXIMUM
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取Unit信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLine = base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex));
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._signal.GetSubKeyWordListMap().Add(Signal.UNIT
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取receiver信息数组
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLine = base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex));
            this._signal.GetSubKeyWordListMap().Add(Signal.RECEIVER
                , subLine.Split(','));
            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._signal;
        }

        public override string GetClassFullName()
        {
            return SignalAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return Signal.KEY_WORD;
        }
    }
}
