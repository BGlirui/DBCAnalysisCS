using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.EnvironmentVariableDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.EnvironmentVariableDefinitions
{
    class EnvironmentVariableDataAnalysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            EnvironmentVariableDataAnalysisMachine environmentVariableDataAnalysisMachine = new EnvironmentVariableDataAnalysisMachine();
            environmentVariableDataAnalysisMachine.AnalysisExecute("ENVVAR_DATA_ env_var_name : data_size;");
            base.Print(environmentVariableDataAnalysisMachine.GetBaseKeyModelOpe());
            return true;
        }
    }
}
