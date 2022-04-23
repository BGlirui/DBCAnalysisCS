using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.EnvironmentVariableDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.EnvironmentVariableDefinitions
{
    class EnvironmentVariableAnalysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            EnvironmentVariableAnalysisMachine environmentVariableAnalysisMachine = new EnvironmentVariableAnalysisMachine();
            environmentVariableAnalysisMachine.AnalysisExecute("EV_ env_var_name : 1 [ 0 | 100 ] \"V\" 5 ev_id DUMMY_NODE_VECTORO VECTOR_XXX,A,B;");
            base.Print(environmentVariableAnalysisMachine.GetBaseKeyModelOpe());
            return true;
        }
    }
}
