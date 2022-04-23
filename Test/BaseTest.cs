using DBCAnalysis.Models.DbcContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    abstract class BaseTest : ITest
    {
        public abstract bool TestExcute();

        public void Print(BaseKeyModelOpe baseKeyModelOpe)
        {
            foreach (KeyValuePair<string, string[]> kvp in baseKeyModelOpe.GetSubKeyWordListMap())
            {
                Console.WriteLine(kvp.Key + "的内容数:" + kvp.Value.Length);
                for (int i = 0; i < kvp.Value.Length; i++)
                {
                    Console.WriteLine("--:" + kvp.Value[i]);
                }
            }
        }
    }
}
