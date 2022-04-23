using DBCAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest
{
    class DbcFileAnalysisTest : BaseTest
    {
        public override bool TestExcute()
        {

            DbcFileAnalysis dbcFileAnalysis = new DbcFileAnalysis();
            string path = "D:\\Project\\Test\\DBC\\THJS-TXXY-0118.dbc";//Console.ReadLine();
            dbcFileAnalysis.SetDbcFile(path);
            dbcFileAnalysis.Execute();
            return true;
        }
    }
}
