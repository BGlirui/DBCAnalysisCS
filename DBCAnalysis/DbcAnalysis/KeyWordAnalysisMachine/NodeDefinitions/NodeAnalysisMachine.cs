using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.NodeDefinitions;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.NodeDefinitions
{
    public class NodeAnalysisMachine : AnalysisMachine
    {
        public const string CLASS_FULL_NAME = "DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.NodeDefinitions.NodeAnalysisMachine";

        private Node _node;

        public override bool AnalysisExecute(string line)
        {
            this._node = new Node();
            string subLine = null;
            int subLineStartIndex = 0;
            int subLineStartLength = 0;
            // 去除关键字
            subLine = line.Replace(Node.KEY_WORD, "");
            // 去除关键字后的“：”
            subLineStartIndex = subLine.IndexOf(':') + 1;
            subLine = subLine.Substring(subLineStartIndex);
            // 去除首尾空格
            subLine = base.removeBlankStringFromStartAndEnd(subLine);
            // 获取NodeName定义数组
            string[] nodeNameArray = subLine.Split(' ');

            // 添加NodeName数组到对象中
            this._node.GetSubKeyWordListMap().Add(Node.NODE_NAME, nodeNameArray);

            return true;
        }

        public override BaseKeyModelOpe GetBaseKeyModelOpe()
        {
            return this._node;
        }

        public override string GetClassFullName()
        {
            return NodeAnalysisMachine.CLASS_FULL_NAME;
        }

        public override string GetKeyWord()
        {
            return Node.KEY_WORD;
        }
    }
}
