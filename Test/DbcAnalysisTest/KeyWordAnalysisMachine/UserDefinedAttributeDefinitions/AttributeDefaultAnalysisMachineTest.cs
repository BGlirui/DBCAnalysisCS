using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.UserDefinedAttributeDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.UserDefinedAttributeDefinitions
{
    class AttributeDefaultAnalysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            AttributeDefaultAnalysisMachine attributeDefaultAnalysisMachine = new AttributeDefaultAnalysisMachine();
            attributeDefaultAnalysisMachine.AnalysisExecute("BA_DEF_DEF_ attribute_name attribute_value ;");
            base.Print(attributeDefaultAnalysisMachine.GetBaseKeyModelOpe());
            return true;
        }
    }
}
