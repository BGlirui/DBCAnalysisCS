using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.CommentDefinitions;
using DBCAnalysis.Models.DbcContent.EnvironmentVariableDefinitions;
using DBCAnalysis.Models.DbcContent.MessageDefinitions;
using DBCAnalysis.Models.DbcContent.NodeDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.CommentDefinitions
{
    public class CommentAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.CommentDefinitions.CommentAnalysisMachine";

        private Comment _comment;
        private HashSet<string> _subKeyWordHashSet = new HashSet<string>() { "BU_", "BO_", "SG_", "EV_" };

        public override bool AnalysisExecute(string line)
        {
            this._comment = new Comment();
            
            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 去掉关键字
            subLine = line.Replace(Comment.KEY_WORD, "");
            // 去掉首尾空字符
            subLine = base.removeBlankStringFromStartAndEnd(subLine);

            //获取子关键字，其中包括BU_（Node） | BO_（Message） | SG_（Signal） | EV_（EnvironmentVariable）
            subLineStartIndex = 0;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            string[] subStr = new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) };
            if (this._subKeyWordHashSet.Contains(subStr[0]))
            {
                this._comment.GetSubKeyWordListMap().Add(Comment.SUB_KEY_WORD
                    , subStr);
                subLineStartIndex = subLineStartIndex + subLineStartLength;
                subLineStartLength = subLine.IndexOf(';', subLineStartIndex) - subLineStartIndex;
                subLine = subLine.Substring(subLineStartIndex,subLineStartLength);
                subLine = base.removeBlankStringFromStartAndEnd(subLine);
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
            else
            {
                this._comment.GetSubKeyWordListMap().Add(Comment.CHAR_STRING
                    , subStr);
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
            this._comment.GetSubKeyWordListMap().Add(Comment.NODE_NAME
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取CharString信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            this._comment.GetSubKeyWordListMap().Add(Comment.CHAR_STRING
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
            this._comment.GetSubKeyWordListMap().Add(Comment.MESSAGE_ID
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取CharString信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            this._comment.GetSubKeyWordListMap().Add(Comment.CHAR_STRING
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
            this._comment.GetSubKeyWordListMap().Add(Comment.MESSAGE_ID
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取SignalName信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            subLineStartLength = subLine.IndexOf(' ', subLineStartIndex) - subLineStartIndex;
            this._comment.GetSubKeyWordListMap().Add(Comment.SIGNAL_NAME
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取CharString信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            this._comment.GetSubKeyWordListMap().Add(Comment.CHAR_STRING
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
            this._comment.GetSubKeyWordListMap().Add(Comment.ENV_VAR_NAME
                , new string[] { subLine.Substring(subLineStartIndex, subLineStartLength) });
            // 获取CharString信息
            subLineStartIndex = subLineStartIndex + subLineStartLength + 1;
            this._comment.GetSubKeyWordListMap().Add(Comment.CHAR_STRING
                , new string[] { subLine.Substring(subLineStartIndex) });
        }
        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._comment;
        }

        public override string GetKeyWord()
        {
            return Comment.KEY_WORD;
        }

        public override string GetClassFullName()
        {
            return CommentAnalysisMachine.CLASS_FULL_NAME;
        }
    }
}
