using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.Models.DbcContent.NodeDefinitions
{
    /// <summary>
    /// Node部分定义了所有参与的节点名，这些节点名在该部分中应该是唯一的
    /// </summary>
    public class Node : BaseKeyModelOpe
    {
        /// <summary>
        /// Node的关键字
        /// </summary>
        public const string KEY_WORD = "BU_";
        /// <summary>
        /// node_name字段，该字段可以出现零次或多次
        /// </summary>
        public const string NODE_NAME = "node_name";

        public override string GetKeyWord()
        {
            return Node.KEY_WORD;
        }
    }
}
