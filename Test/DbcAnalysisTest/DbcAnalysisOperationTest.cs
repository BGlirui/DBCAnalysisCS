using DBCAnalysis.DbcAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest
{
    class DbcAnalysisOperationTest : BaseTest
    {
        public override bool TestExcute()
        {
            DbcAnalysisOperation dbcAnalysisOperation = new DbcAnalysisOperation();
            dbcAnalysisOperation.DbcMessageAnalysisToResultObject("a",new List<string>() { " a  a   a    a     " });
            return true;
        }
    }
}
