using DBCAnalysis.DbcAnalysis;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.CommentDefinitions;
using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.NodeDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.CoreTest.DbcAnalysisMachineManage
{
    class DbcAnalysisMachinePoolTest : BaseTest
    {
        public override bool TestExcute()
        {
            DbcAnalysisMachinePoolOpe dbcAnalysisMachinePool = new DbcAnalysisMachinePoolOpe();
            dbcAnalysisMachinePool.RegisterAnalysisMachine(new CommentAnalysisMachine());
            dbcAnalysisMachinePool.RegisterAnalysisMachine(new NodeAnalysisMachine());
            List<string> register = dbcAnalysisMachinePool.GetAllRegisteredAnalysisMachineClassFullName();
            foreach(string temp in register)
            {
                Console.WriteLine(temp);
            }

            Console.WriteLine("删除的分割线---------");
            dbcAnalysisMachinePool.RemoveAnalysisMachine(new CommentAnalysisMachine());
            List<string> register1 = dbcAnalysisMachinePool.GetAllRegisteredAnalysisMachineClassFullName();
            foreach (string temp1 in register1)
            {
                Console.WriteLine(temp1);
            }

            return true;
        }
    }
}
