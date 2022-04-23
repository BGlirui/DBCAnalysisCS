using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.CoreTest.DbcAnalysisMachineManage;
using Test.DbcAnalysisTest;
using Test.DbcAnalysisTest.CommentDefinitions;
using Test.DbcAnalysisTest.EnvironmentVariableDefinitions;
using Test.DbcAnalysisTest.MessageDefinitions;
using Test.DbcAnalysisTest.NodeDefinitions;
using Test.DbcAnalysisTest.SignalTypeAndSignalGroupDefinitions;
using Test.DbcAnalysisTest.UserDefinedAttributeDefinitions;
using Test.DbcAnalysisTest.ValueTableDefinitions;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //ITest bitTimingAnalysisMachineTest = new BitTimingAnalysisMachineTest();
            //bitTimingAnalysisMachineTest.TestExcute();

            //ITest nodeAnalysisMachineTest = new NodeAnalysisMachineTest();
            //nodeAnalysisMachineTest.TestExcute();

            //ITest valueTableAnalysisMachineTest = new ValueTableAnalysisMachineTest();
            //valueTableAnalysisMachineTest.TestExcute();

            //ITest test = new SignalAnalysisMachineTest();
            //test.TestExcute();\

            //ITest test = new MessageTransmitterAnalysisMachineTest();
            //test.TestExcute();

            //ITest test = new ValueDescriptionsForSignalAanlysisMachineTest();
            //test.TestExcute();

            //ITest test = new SignalExtendedValueTypeListAnalysisMachineTest();
            //test.TestExcute();

            //ITest test = new EnvironmentVariableAnalysisMachineTest();
            //test.TestExcute();

            //ITest test = new EnvironmentVariableDataAnalysisMachineTest();
            //test.TestExcute();
            //ITest test = new ValueDescriptionsForEnvVarAnalysisMachineTest();
            //test.TestExcute();
            //ITest test = new SignalTypeAnalysisMachineTest();
            //test.TestExcute();
            //ITest test = new SignalTypeRefAnalysisMachineTest();
            //test.TestExcute();

            //ITest test = new SignalGroupsAnalysisMachineTest();
            //test.TestExcute();

            //ITest test = new CommentAnalysisMachineTest();
            //test.TestExcute();

            //ITest test = new AttributeDefaultAnalysisMachineTest();
            //test.TestExcute();

            //ITest test = new AttributeDefinitionAnalysisMachineTest();
            //test.TestExcute();

            //ITest test = new AttributeValueForObjectAnalysisMachineTest();
            //test.TestExcute();

            //ITest test = new DbcAnalysisMachinePoolTest();
            //test.TestExcute();

            //ITest test = new DbcFileAnalysisTest();
            //test.TestExcute();
            int[] a = new int[] { 1, 2, 3 };
            for(int i=0;i<3;i++)
            {
                Console.Write(a[i] + ",");
            }
            Console.Write("\r\n");
            test(a);
            for (int i = 0; i < 3; i++)
            {
                Console.Write(a[i] + ",");
            }
            Console.Write("\r\n");
            Console.ReadKey();
        }
        private static void test(int[] a)
        {
            a[0] = 3;
        }
    }
}
