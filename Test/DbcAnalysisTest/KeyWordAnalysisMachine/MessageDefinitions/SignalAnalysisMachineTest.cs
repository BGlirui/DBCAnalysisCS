using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.MessageDefinitions;
using DBCAnalysis.Models.DbcContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.MessageDefinitions
{
    class SignalAnalysisMachineTest : ITest
    {
        public bool TestExcute()
        {
            SignalAnalysisMachine signalAnalysisMachine = new SignalAnalysisMachine();
            signalAnalysisMachine.AnalysisExecute("SG_ DCDC_GeneratrixVol : 47|16@0- (1,0) [0|900] \"V\"  VCU");
            BaseKeyModelOpe baseKeyModelOpe = signalAnalysisMachine.GetBaseKeyModelOpe();
            foreach (KeyValuePair<string,string[]> kvp in baseKeyModelOpe.GetSubKeyWordListMap())
            {
                Console.WriteLine(kvp.Key + "的内容数:"+ kvp.Value.Length);
                for(int i=0;i<kvp.Value.Length;i++)
                {
                    Console.WriteLine("--:"+kvp.Value[i]);
                }
            }
            return true;
        }
    }
}
