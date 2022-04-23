using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.SignalTypeAndSignalGroupDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.SignalTypeAndSignalGroupDefinitions
{
    class SignalTypeRefAnalysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            SignalTypeRefAnalysisMachine signalTypeRefAnalysisMachine = new SignalTypeRefAnalysisMachine();
            signalTypeRefAnalysisMachine.AnalysisExecute("SGTYPE_ message_id  signal_name : signal_type_name;");
            base.Print(signalTypeRefAnalysisMachine.GetBaseKeyModelOpe());
            return true;
        }
    }
}
