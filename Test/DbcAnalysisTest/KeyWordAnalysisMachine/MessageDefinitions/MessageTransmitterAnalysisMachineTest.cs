using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.MessageDefinitions
{
    class MessageTransmitterAnalysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            MessageTransmitterAnalysisMachine messageTransmitterAnalysisMachine = new MessageTransmitterAnalysisMachine();
            messageTransmitterAnalysisMachine.AnalysisExecute("BO_TX_BU_ DCDC_VCU_Status_Message1: A B C D;");
            base.Print(messageTransmitterAnalysisMachine.GetBaseKeyModelOpe());
            return true;
        }
    }
}
