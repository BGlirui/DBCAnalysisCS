using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.SignalTypeAndSignalGroupDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.SignalTypeAndSignalGroupDefinitions
{
    class SignalTypeAnalysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            SignalTypeAnalysisMachine signalTypeAnalysisMachine = new SignalTypeAnalysisMachine();
            signalTypeAnalysisMachine.AnalysisExecute("SGTYPE_ signal_type_name:signal_size@ byte_order value_type ( factor,offset ) [minimum | maximum] \"V\" default_value , value_table;");
            base.Print(signalTypeAnalysisMachine.GetBaseKeyModelOpe());
            return true;
        }
    }
}
