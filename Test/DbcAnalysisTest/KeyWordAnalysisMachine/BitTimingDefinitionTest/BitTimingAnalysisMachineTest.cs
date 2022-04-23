using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.BitTimingDefinition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.BitTimingDefinitionTest
{
    class BitTimingAnalysisMachineTest : ITest
    {
        BitTimingAnalysisMachine bitTimingAnalysisMachine = new BitTimingAnalysisMachine();

        public bool TestExcute()
        {
            this.bitTimingAnalysisMachine.AnalysisExecute("BS_: a:b,c");
            return true;
        }
    }
}
