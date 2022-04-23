using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.UserDefinedAttributeDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.UserDefinedAttributeDefinitions
{
    class AttributeValueForObjectAnalysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            Console.WriteLine("普通注释信息---------");
            AttributeValueForObjectAnalysisMachine commentAnalysisMachine = new AttributeValueForObjectAnalysisMachine();
            commentAnalysisMachine.AnalysisExecute("BA_ attribute_name attribute_value ;");
            base.Print(commentAnalysisMachine.GetBaseKeyModelOpe());
            Console.WriteLine("Node注释信息---------");
            AttributeValueForObjectAnalysisMachine commentAnalysisMachineNode = new AttributeValueForObjectAnalysisMachine();
            commentAnalysisMachineNode.AnalysisExecute("BA_ attribute_name BU_ node_name attribute_value ;");
            base.Print(commentAnalysisMachineNode.GetBaseKeyModelOpe());
            Console.WriteLine("Message注释信息---------");
            AttributeValueForObjectAnalysisMachine commentAnalysisMachineMessage = new AttributeValueForObjectAnalysisMachine();
            commentAnalysisMachineMessage.AnalysisExecute("BA_ attribute_name BO_ message_id attribute_value ;");
            base.Print(commentAnalysisMachineMessage.GetBaseKeyModelOpe());
            Console.WriteLine("Signal注释信息---------");
            AttributeValueForObjectAnalysisMachine commentAnalysisMachineSignal = new AttributeValueForObjectAnalysisMachine();
            commentAnalysisMachineSignal.AnalysisExecute("BA_ attribute_name SG_ message_id signal_name attribute_value ;");
            base.Print(commentAnalysisMachineSignal.GetBaseKeyModelOpe());
            Console.WriteLine("EnvVarName注释信息---------");
            AttributeValueForObjectAnalysisMachine commentAnalysisMachineEnv = new AttributeValueForObjectAnalysisMachine();
            commentAnalysisMachineEnv.AnalysisExecute("BA_ attribute_name EV_ env_var_name attribute_value ;");
            base.Print(commentAnalysisMachineEnv.GetBaseKeyModelOpe());

            return true;
        }
    }
}
