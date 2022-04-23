using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.CommentDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.CommentDefinitions
{
    class CommentAnalysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            Console.WriteLine("普通注释信息---------");
            CommentAnalysisMachine commentAnalysisMachine = new CommentAnalysisMachine();
            commentAnalysisMachine.AnalysisExecute("CM_ char_string ;");
            base.Print(commentAnalysisMachine.GetBaseKeyModelOpe());
            Console.WriteLine("Node注释信息---------");
            CommentAnalysisMachine commentAnalysisMachineNode = new CommentAnalysisMachine();
            commentAnalysisMachineNode.AnalysisExecute("CM_ BU_ node_name char_string ;");
            base.Print(commentAnalysisMachineNode.GetBaseKeyModelOpe());
            Console.WriteLine("Message注释信息---------");
            CommentAnalysisMachine commentAnalysisMachineMessage = new CommentAnalysisMachine();
            commentAnalysisMachineMessage.AnalysisExecute("CM_ BO_ message_id char_string ;");
            base.Print(commentAnalysisMachineMessage.GetBaseKeyModelOpe());
            Console.WriteLine("Signal注释信息---------");
            CommentAnalysisMachine commentAnalysisMachineSignal = new CommentAnalysisMachine();
            commentAnalysisMachineSignal.AnalysisExecute("CM_ SG_ message_id signal_name char_string ;");
            base.Print(commentAnalysisMachineSignal.GetBaseKeyModelOpe());
            Console.WriteLine("EnvVarName注释信息---------");
            CommentAnalysisMachine commentAnalysisMachineEnv = new CommentAnalysisMachine();
            commentAnalysisMachineEnv.AnalysisExecute("CM_ EV_ env_var_name char_string ;");
            base.Print(commentAnalysisMachineEnv.GetBaseKeyModelOpe());

            return true;
        }
    }
}
