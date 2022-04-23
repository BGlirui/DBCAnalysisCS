using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBCAnalysis.DbcAnalysis.KeyWordAnalysisMachine
{
    interface INullKeyWordAnalysis
    {

        bool HaveSubNullKeyWordString();

        bool NullKeyWordAnalysis(string line);
    }
}
