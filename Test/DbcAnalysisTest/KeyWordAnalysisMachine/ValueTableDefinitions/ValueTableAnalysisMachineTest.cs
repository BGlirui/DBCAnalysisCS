using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.ValueTableDefinitions;
using DBCAnalysis.Models.DbcContent;
using DBCAnalysis.Models.DbcContent.ValueTableDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.ValueTableDefinitions
{
    class ValueTableAnalysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            ValueTableAnalysisMachine valueTableAnalysisMachine = new ValueTableAnalysisMachine();
            valueTableAnalysisMachine.AnalysisExecute("VAL_TABLE_ value_table_name value_description1 value_description2 value_description3 ;");
            base.Print(valueTableAnalysisMachine.GetBaseKeyModelOpe());
            return true;
        }

        
    }
}
