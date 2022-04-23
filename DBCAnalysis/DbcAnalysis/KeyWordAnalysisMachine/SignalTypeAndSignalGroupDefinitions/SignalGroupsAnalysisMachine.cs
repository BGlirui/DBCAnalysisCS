using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.SignalTypeAndSignalGroupDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.SignalTypeAndSignalGroupDefinitions
{
    public class SignalGroupsAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.SignalTypeAndSignalGroupDefinitions.SignalGroupsAnalysisMachine";

        private SignalGroups _signalGroups;
        public override bool AnalysisExecute(string line)
        {
            this._signalGroups = new SignalGroups();

            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 取消关键字
            subLine = line.Replace(SignalGroups.KEY_WORD, "");
            // 取消首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);

            // 获取MessageId消息
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._signalGroups.GetSubKeyWordListMap().Add(SignalGroups.MESSAGE_ID
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取SingalGroupName
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._signalGroups.GetSubKeyWordListMap().Add(SignalGroups.SIGNAL_GROUP_NAME
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取Repetitions信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(':', subLineStartIndex) - subLineStartIndex;
            this._signalGroups.GetSubKeyWordListMap().Add(SignalGroups.REPETITIONS
                , new string[] { base.removeBlankStringFromStartAndEnd(subLine.Substring(subLineStartIndex, subLineStartLength)) });

            // 获取SignalName信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(';', subLineStartIndex) - subLineStartIndex;
            subLine = subLine.Substring(subLineStartIndex, subLineStartLength);
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            this._signalGroups.GetSubKeyWordListMap().Add(SignalGroups.SIGNAL_NAME
                , subLine.Split(' '));

            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._signalGroups;
        }

        public override string GetClassFullName()
        {
            return SignalGroupsAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return SignalGroups.KEY_WORD;
        }
    }
}
