using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.MessageDefinitions
{
    class SignalExtendedValueTypeListAnalysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            SignalExtendedValueTypeListAnalysisMachine signalExtendedValueTypeListAnalysisMachine = new SignalExtendedValueTypeListAnalysisMachine();
            signalExtendedValueTypeListAnalysisMachine.AnalysisExecute("SIG_VALTYPE_ Message_id signal_name 1;");
            base.Print(signalExtendedValueTypeListAnalysisMachine.GetBaseKeyModelOpe());
            return true;
        }
    }
}
