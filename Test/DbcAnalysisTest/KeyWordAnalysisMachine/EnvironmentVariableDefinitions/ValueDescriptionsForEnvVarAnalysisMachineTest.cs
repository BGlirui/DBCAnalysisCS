using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.EnvironmentVariableDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.EnvironmentVariableDefinitions
{
    class ValueDescriptionsForEnvVarAnalysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            ValueDescriptionsForEnvVarAnalysisMachine valueDescriptionsForEnvVarAnalysisMachine = new ValueDescriptionsForEnvVarAnalysisMachine();
            valueDescriptionsForEnvVarAnalysisMachine.AnalysisExecute("VAL_ env_var_aname value_description1 value_description2 ;");
            base.Print(valueDescriptionsForEnvVarAnalysisMachine.GetBaseKeyModelOpe());
            return true;
        }
    }
}
