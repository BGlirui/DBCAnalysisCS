using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.NodeDefinitions;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.NodeDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.NodeDefinitions
{
    class NodeAnalysisMachineTest : ITest
    {
        public bool TestExcute()
        {
            NodeAnalysisMachine nodeAnalysisMachine = new NodeAnalysisMachine();
            nodeAnalysisMachine.AnalysisExecute("BU_: DCDC VCU");
            BaseKeyModelOpe node = nodeAnalysisMachine.GetBaseKeyModelOpe();
            Console.WriteLine("Node.NODE_NAME的字节数为：" + node.GetSubKeyWordList(Node.NODE_NAME).Length);
            for(int i =0;i<node.GetSubKeyWordList(Node.NODE_NAME).Length;i++)
            {
                Console.WriteLine(node.GetSubKeyWordList(Node.NODE_NAME)[i]);
            }
            return true;
        }
    }
}
