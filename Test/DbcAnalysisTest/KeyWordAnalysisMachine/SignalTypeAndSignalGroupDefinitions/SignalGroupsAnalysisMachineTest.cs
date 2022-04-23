using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.SignalTypeAndSignalGroupDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.SignalTypeAndSignalGroupDefinitions
{
    class SignalGroupsAnalysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            SignalGroupsAnalysisMachine signalGroupsAnalysisMachine = new SignalGroupsAnalysisMachine();
            signalGroupsAnalysisMachine.AnalysisExecute("SIG_GROUP_ message_id signal_group_name repetitions : signal_name1 signal_name2 signal_name3;");
            base.Print(signalGroupsAnalysisMachine.GetBaseKeyModelOpe());
            return true;
        }
    }
}
