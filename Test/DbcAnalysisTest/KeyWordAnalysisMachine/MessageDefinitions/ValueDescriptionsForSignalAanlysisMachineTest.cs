using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.MessageDefinitions
{
    class ValueDescriptionsForSignalAanlysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            ValueDescriptionsForSignalAanlysisMachine valueDescriptionsForSignalAanlysisMachine = new ValueDescriptionsForSignalAanlysisMachine();
            valueDescriptionsForSignalAanlysisMachine.AnalysisExecute("VAL_ message_id signal_name A B C D;");
            base.Print(valueDescriptionsForSignalAanlysisMachine.GetBaseKeyModelOpe());
            return true;
        }
    }
}
