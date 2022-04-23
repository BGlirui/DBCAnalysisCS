using DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine.UserDefinedAttributeDefinitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.DbcAnalysisTest.UserDefinedAttributeDefinitions
{
    class AttributeDefinitionAnalysisMachineTest : BaseTest
    {
        public override bool TestExcute()
        {
            Console.WriteLine("普通属性——————————————");
            AttributeDefinitionAnalysisMachine attributeDefinitionAnalysisMachine = new AttributeDefinitionAnalysisMachine();
            attributeDefinitionAnalysisMachine.AnalysisExecute("BA_DEF_ attribute_name STRING ;");
            base.Print(attributeDefinitionAnalysisMachine.GetBaseKeyModelOpe());

            Console.WriteLine("BU_属性——————————————");
            AttributeDefinitionAnalysisMachine attributeDefinitionAnalysisMachineBU = new AttributeDefinitionAnalysisMachine();
            attributeDefinitionAnalysisMachine.AnalysisExecute("BA_DEF_ BU_ attribute_name STRING ;");
            base.Print(attributeDefinitionAnalysisMachine.GetBaseKeyModelOpe());

            Console.WriteLine("BO_属性——————————————");
            AttributeDefinitionAnalysisMachine attributeDefinitionAnalysisMachineBO = new AttributeDefinitionAnalysisMachine();
            attributeDefinitionAnalysisMachine.AnalysisExecute("BA_DEF_ BO_ attribute_name STRING ;");
            base.Print(attributeDefinitionAnalysisMachineBO.GetBaseKeyModelOpe());

            Console.WriteLine("SG_属性——————————————");
            AttributeDefinitionAnalysisMachine attributeDefinitionAnalysisMachineSG = new AttributeDefinitionAnalysisMachine();
            attributeDefinitionAnalysisMachine.AnalysisExecute("BA_DEF_ SG_ attribute_name STRING ;");
            base.Print(attributeDefinitionAnalysisMachineSG.GetBaseKeyModelOpe());

            Console.WriteLine("EV_属性——————————————");
            AttributeDefinitionAnalysisMachine attributeDefinitionAnalysisMachineEV = new AttributeDefinitionAnalysisMachine();
            attributeDefinitionAnalysisMachine.AnalysisExecute("BA_DEF_ EV_ attribute_name STRING ;");
            base.Print(attributeDefinitionAnalysisMachine.GetBaseKeyModelOpe());
            return true;
        }
    }
}
